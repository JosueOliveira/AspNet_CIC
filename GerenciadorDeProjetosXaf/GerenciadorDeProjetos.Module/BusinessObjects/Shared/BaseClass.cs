using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using GerenciadorDeProjetos.Module.BusinessObjects.ClassUtils;
using System.ComponentModel;

namespace GerenciadorDeProjetos.Module.BusinessObjects.Shared
{
    [NonPersistent]
    public abstract class BaseClass : BaseObject
    {
        [NonPersistent]
        [Browsable(false)]
        public bool IsNewObject
        {
            get
            {
                return Session.IsNewObject(this);
            }
        }

        public BaseClass(Session session) : base(session) { }

        


    }
}
