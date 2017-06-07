using DevExpress.Data.Filtering;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.Editors;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using GerenciadorDeProjetos.Module.BusinessObjects.Entities;
using GerenciadorDeProjetos.Module.BusinessObjects.NonPersistent;
using System;
using System.ComponentModel;

namespace GerenciadorDeProjetos.Module.Views
{
    #region Anotations
    [NonPersistent]
    [NavigationItem("Projetos")] 
    #endregion
    public partial class ConsultaProjeto : XPBaseObject
    {
        #region Private Properties
        private DateTime _dataInicio;
        private DateTime _dataFim;
        private Usuario _gerente;
        private StatusProjetoEnum _status;

        private Projeto _projeto;
        private XPCollection<Projeto> projetos;
        #endregion
        #region Builders
        public ConsultaProjeto(Session session) : base(session) { }
        #endregion
        #region Public Properties       
      

        public DateTime DataInicio
        {
            get
            {
                return _dataInicio;
            }

            set
            {
                SetPropertyValue("DataInicio", ref _dataInicio, value);
            }
        }

        public DateTime DataFim
        {
            get
            {
                return _dataFim;
            }

            set
            {
                SetPropertyValue("DataFim", ref _dataFim, value);
            }
        }
        
        [DataSourceProperty("RetornaGerente")]
        [DataSourceCriteria("IsActive")]                
        public Usuario Gerente
        {
            get
            {
                return _gerente;
            }

            set
            {
                SetPropertyValue("Gerente", ref _gerente, value);
            }
        }

        public StatusProjetoEnum Status
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
        #endregion

        #region Properties Associations
        [Browsable(false)]
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
        //Esconde GRid = Null
        //[Appearance("Escode Grid se For null", Criteria = "", Visibility = ViewItemVisibility.Hide)]
         
        public XPCollection<Projeto> Projetos
        {
            get
            {
                return projetos;
            }

            set
            {
                SetPropertyValue("Projetos", ref projetos, value);
            }
        } 
        #endregion
        [Browsable(false)]
        public XPCollection<PermissionPolicyUser> RetornaGerente
        {
            get
            {
               Permissao role = Session.FindObject<Permissao>(BinaryOperator.Parse("Name = 'CadastrarProjeto'"));
                if(role != null)
                {
                    return role.Users;
                }else
                {
                    return null;
                }                
            }
        }

        public override void AfterConstruction()
        {
            
            base.AfterConstruction();
            Status = StatusProjetoEnum.Todos;
        }
    }
}
