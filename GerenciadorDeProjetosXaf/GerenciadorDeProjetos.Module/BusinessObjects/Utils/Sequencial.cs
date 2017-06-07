using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using GerenciadorDeProjetos.Module.BusinessObjects.Entities;
using GerenciadorDeProjetos.Module.BusinessObjects.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GerenciadorDeProjetos.Module.BusinessObjects.ClassUtils.Sequencial;

namespace GerenciadorDeProjetos.Module.BusinessObjects.ClassUtils
{
    [NonPersistent]
    public abstract class Sequencial : BaseClass, ISupportSequentialNumber 
        //TODO implementar interface
    {
        private long _SequentialNumber;
        private static SequenceGenerator sequenceGenerator;
        private static object syncRoot = new object();
        public Sequencial(Session session)
            : base(session)
        {
        }

        [Browsable(false)]
        [Indexed(Unique = false)]
        [Persistent("Codigo")]
        public long SequentialNumber
        {
            get { return _SequentialNumber; }
            set { SetPropertyValue("SequentialNumber", ref _SequentialNumber, value); }
        }
        private void OnSequenceGenerated(long newId)
        {
            SequentialNumber = newId;
        }

        public void GenerateSequence()
        {
            lock (syncRoot)
            {
                Dictionary<string, bool> typeToExistsMap = new Dictionary<string, bool>();
                foreach (object item in Session.GetObjectsToSave())
                    typeToExistsMap[Session.GetClassInfo(item).FullName] = true;
                if (sequenceGenerator == null)
                    sequenceGenerator = new SequenceGenerator(typeToExistsMap);
                SubscribeToEvents();
                OnSequenceGenerated(sequenceGenerator.GetNextSequence(ClassInfo));
            }
        }
        private void AcceptSequence()
        {
            lock (syncRoot)
            {
                if (sequenceGenerator != null)
                {
                    try
                    {
                        sequenceGenerator.Accept();
                    }
                    finally
                    {
                        CancelSequence();
                    }
                }
            }
        }
        public void CancelSequence()
        {
            lock (syncRoot)
            {
                UnSubscribeFromEvents();
                if (sequenceGenerator != null)
                {
                    sequenceGenerator.Close();
                    sequenceGenerator = null;
                }
            }
        }
        private void Session_AfterCommitTransaction(object sender, SessionManipulationEventArgs e)
        {
            AcceptSequence();
        }
        private void Session_AfterRollBack(object sender, SessionManipulationEventArgs e)
        {
            CancelSequence();
        }
        private void Session_FailedCommitTransaction(object sender, SessionOperationFailEventArgs e)
        {
            CancelSequence();
        }
        private void SubscribeToEvents()
        {
            if (!(Session is NestedUnitOfWork))
            {
                Session.AfterCommitTransaction += Session_AfterCommitTransaction;
                Session.AfterRollbackTransaction += Session_AfterRollBack;
                Session.FailedCommitTransaction += Session_FailedCommitTransaction;
            }
        }
        private void UnSubscribeFromEvents()
        {
            if (!(Session is NestedUnitOfWork))
            {
                Session.AfterCommitTransaction -= Session_AfterCommitTransaction;
                Session.AfterRollbackTransaction -= Session_AfterRollBack;
                Session.FailedCommitTransaction -= Session_FailedCommitTransaction;
            }
        }

        public interface ISupportSequentialNumber
        {
            long SequentialNumber { get; set; }
        }
    }
  }
