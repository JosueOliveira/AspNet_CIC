using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using GerenciadorDeProjetos.Module.BusinessObjects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeProjetos.Module.Views
{
    [NonPersistent]
    [DomainComponent]
    public class ComentarioAdd : BaseObject
    {
        private SubTarefa _subTarefa;

        public SubTarefa SubTarefa
        {
            get { return _subTarefa; }
            set { _subTarefa = value; }
        }

        private string _motivo;

        public ComentarioAdd(Session session) : base(session)
        {
        }

        [Size(-1)]
        public string Motivo
        {
            get { return _motivo; }
            set { _motivo = value; }
        }


    }
}
