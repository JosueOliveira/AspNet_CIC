using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Utils;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.Xpo.DB.Exceptions;
using DevExpress.Xpo.Metadata;
using GerenciadorDeProjetos.Module.BusinessObjects.Entities;
using GerenciadorDeProjetos.Module.BusinessObjects.Shared;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading;

namespace GerenciadorDeProjetos.Module.BusinessObjects.ClassUtils
{
    public class SequenceGenerator : IDisposable
    {
        public const int MaxGenerationAttemptsCount = 10;
        public const int MinGenerationAttemptsDelay = 100;
        private static volatile IDataLayer defaultDataLayer;
        private static object syncRoot = new Object();
        private ExplicitUnitOfWork euow;
        private Sequence seq;
        public SequenceGenerator(Dictionary<string, bool> lockedSequenceTypes) 
        {
            int count = MaxGenerationAttemptsCount;
            while (true)
            {
                try
                {
                    euow = new ExplicitUnitOfWork(DefaultDataLayer);
                    seq = euow.FindObject<Sequence>(new InOperator("TypeName", lockedSequenceTypes.Keys));
                    //XPCollection<Sequence> sequences = new XPCollection<Sequence>(euow, new InOperator("TypeName", lockedSequenceTypes.Keys), new SortProperty("TypeName", DevExpress.Xpo.DB.SortingDirection.Ascending));
                    //foreach (Sequence seq in sequences)
                    if (seq == null) throw new LockingException();
                    seq.Save();
                    euow.FlushChanges();
                    break;
                }
                catch (LockingException)
                {
                    Close();
                    count--;
                    if (count <= 0)
                        throw;
                    Thread.Sleep(MinGenerationAttemptsDelay * count);
                }
            }
        }
        public void Accept()
        {
            euow.CommitChanges();
        }
        public void Close()
        {
            if (euow != null)
            {
                if (euow.InTransaction)
                    euow.RollbackTransaction();
                euow.Dispose();
                euow = null;
            }
        }
        public void Dispose()
        {
            Close();
        }

        public long GetNextSequence(XPClassInfo classInfo)
        {
            if (classInfo == null)
                throw new ArgumentNullException("classInfo");
            XPClassInfo ci = classInfo;
            while (ci.BaseClass != null && ci.BaseClass.IsPersistent)
            {
                ci = ci.BaseClass;
            }

            CriteriaOperator criteria = CriteriaOperator.Parse("TypeName = ? ", ci.FullName);
            seq = euow.FindObject<Sequence>(criteria, true);
            if (seq == null)
            {
                throw new InvalidOperationException(string.Format("Sequence for the {0} type was not found.", ci.FullName));
            }
            long nextSequence = seq.NextSequence;

            seq.NextSequence++;
            euow.FlushChanges();
            return nextSequence;
        }

        public static void RegisterSequences(IEnumerable<ITypeInfo> persistentTypes)
        {
            if (persistentTypes != null)
                using (UnitOfWork uow = new UnitOfWork(DefaultDataLayer))
                {
                    XPCollection<Sequence> sequenceList = new XPCollection<Sequence>(uow);
                    Dictionary<string, bool> typeToExistsMap = new Dictionary<string, bool>();
                    
                    foreach (ITypeInfo typeInfo in persistentTypes)
                    {
                        ITypeInfo ti = typeInfo;
                        while (ti.Base != null && ti.Base.IsPersistent)
                        {
                            ti = ti.Base;
                        }
                        string typeName = ti.FullName;

                        if (ti.IsInterface && ti.IsPersistent)
                        {
                            Type generatedEntityType = XpoTypesInfoHelper.GetXpoTypeInfoSource().GetGeneratedEntityType(ti.Type);
                            if (generatedEntityType != null)
                                typeName = generatedEntityType.FullName;
                        }

                        if (ti.IsPersistent)
                        {
                            typeToExistsMap[typeName] = true;
                            Sequence seq = new Sequence(uow);
                            seq.TypeName = typeName;
                            seq.NextSequence = 1;
                        }
                    }
                    uow.CommitChanges();
                }
        }





        public static IDataLayer DefaultDataLayer
        {
            get
            {
                if (defaultDataLayer == null)
                    throw new ArgumentNullException("DefaultDataLayer");
                return defaultDataLayer;
            }
            set
            {
                lock (syncRoot)
                    defaultDataLayer = value;
            }
        }



        public class Sequence : XPBaseObject
        {
            public Sequence(Session session)
                : base(session)
            {
            }

            
            private Guid oid;
            [Key(autoGenerate: true)]
            public Guid Oid
            {
                get { return oid; }
                set { SetPropertyValue("Oid", ref oid, value); }
            }
            private string typeName;
            [Size(1024)]

            public string TypeName
            {
                get { return typeName; }
                set { SetPropertyValue("TypeName", ref typeName, value); }
            }

            private long nextSequence;
            public long NextSequence
            {
                get { return nextSequence; }
                set { SetPropertyValue("NextSequence", ref nextSequence, value); }
            }
        }

        public interface ISupportSequentialNumber
        {
            long SequentialNumber { get; set; }
        }
        public static class SequenceGeneratorInitializer
        {
            private static XafApplication application;
            private static XafApplication Application { get { return application; } }
            public static void Register(XafApplication app)
            {
                application = app;

                if (application != null)
                    application.LoggedOn += new EventHandler<LogonEventArgs>(application_LoggedOn);
            }
            private static void application_LoggedOn(object sender, LogonEventArgs e)
            {
                Initialize();
            }
            //Dennis: It is important to set the SequenceGenerator.DefaultDataLayer property to the main application data layer.
            //If you use a custom IObjectSpaceProvider implementation, ensure that it exposes a working IDataLayer.
            public static void Initialize()
            {

                Guard.ArgumentNotNull(Application, "Application");
                XPObjectSpaceProvider provider = Application.ObjectSpaceProvider as XPObjectSpaceProvider;
                if (provider != null)
                {
                    Guard.ArgumentNotNull(provider, "provider");
                    if (provider.DataLayer == null)
                    {
                        provider.CreateObjectSpace();
                    }
                    if (provider.DataLayer is ThreadSafeDataLayer)
                    {
                        SequenceGenerator.DefaultDataLayer = XpoDefault.GetDataLayer(
                            ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString,
                            XpoTypesInfoHelper.GetXpoTypeInfoSource().XPDictionary,
                            DevExpress.Xpo.DB.AutoCreateOption.None);
                    }
                    else
                    {
                        SequenceGenerator.DefaultDataLayer = provider.DataLayer;
                    }
                }
            }

        }
    }
}
