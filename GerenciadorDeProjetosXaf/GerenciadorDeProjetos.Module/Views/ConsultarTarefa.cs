using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Editors;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using GerenciadorDeProjetos.Module.BusinessObjects.Entities;
using GerenciadorDeProjetos.Module.BusinessObjects.Shared;
using System.ComponentModel;

namespace GerenciadorDeProjetos.Module.Views
{
    #region Anotations
    [NonPersistent]
    [NavigationItem("Tarefas")] 

    #endregion
    public partial class ConsultarTarefa : XPBaseObject
    {
        #region Private Properties
        private Tarefa _tarefa;
        private Projeto _projeto;
        private Usuario _usuario;         
        private PerfilUsuarioEnum _contemEm;
        private XPCollection<Tarefa> tarefas;
        private StatusTarefaEnum _status;
        #endregion

        #region Builders
        public ConsultarTarefa(Session session) : base(session) { }
        #endregion

        #region Public Properties
        [Browsable(false)]
        public Tarefa Tarefa
        {
            get
            {
                return _tarefa;
            }

            set
            {
                SetPropertyValue("Tarefa", ref _tarefa, value);
            }
        }
        //Desabilita List Antes do CLic pesquisar//, Criteria = "Tarefas = null"
        //[Appearance("Esconde Lsita Vazia", Criteria = "null", Visibility = ViewItemVisibility.Hide)]
        public XPCollection<Tarefa> Tarefas
        {
            get
            {
                return tarefas;
            }
            set
            {
                SetPropertyValue("Tarefas", ref tarefas, value);
            }
        }

        #endregion

        public StatusTarefaEnum Status
        {
            get
            {
                return _status;
            }

            set
            {
                SetPropertyValue("Status", ref _status, value);
            }
        }

        public Projeto Projeto
        {
            get
            {
                return _projeto;
            }

            set
            {
                SetPropertyValue("Projeto", ref _projeto, value);
            }
        }

        public Usuario Usuario
        {
            get
            {
                return _usuario;
            }

            set
            {
                _usuario = value;
            }
        }

        #region Rules
        [XafDisplayName("Contém Em")] 
        #endregion
        public PerfilUsuarioEnum ContemEm
        {
            get
            {
                return _contemEm;
            }

            set
            {
                SetPropertyValue("ContemEm", ref _contemEm, value);
            }
        }
     
        

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            Status = StatusTarefaEnum.Todos;
            ContemEm = PerfilUsuarioEnum.Todos;
        }
    }
}
