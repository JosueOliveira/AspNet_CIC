using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using GerenciadorDeProjetos.Module.BusinessObjects.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeProjetos.Module.Views
{
    #region Rules
    [NonPersistent]     
    #endregion
    public partial class VersionarProjeto : XPBaseObject
    {

        #region Private Properties
        private Projeto _projeto;
        private string _novaVersao;
        private SubTarefa _subTarefa;
        private XPCollection<Tarefa> _tarefas; 
        #endregion
        public VersionarProjeto (Session session) : base(session) { }
        [DataSourceCriteria("!StatusProjeto = 'Cancelado' && !StatusProjeto = 'Finalizado'")]
        public Projeto Projeto
        {
            get
            {
                return _projeto;
            }
            set
            {
                SetPropertyValue("Projeto", ref _projeto,  value);
            }
        }
        #region Rules
        [ImmediatePostData] 
        #endregion
        public string NovaVersao
        {
            get 
            {
                return _novaVersao;
            }

            set
            {
                SetPropertyValue("NovaVersao", ref _novaVersao, value);
            }
        }
        #region Rules
        //[Appearance("Desabilita Vazio", Criteria = "Tarefas = null", Visibility = ViewItemVisibility.Hide)]
         
        #endregion
        public XPCollection<Tarefa> Tarefas
        {
            get
            {
                return _tarefas;
            }

            set
            {
                SetPropertyValue("Tarefas", ref _tarefas, value);
            }
        }

    }
}
