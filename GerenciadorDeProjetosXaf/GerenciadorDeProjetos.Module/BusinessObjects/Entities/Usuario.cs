using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using DevExpress.Xpo;
using System.Collections.Generic;

namespace GerenciadorDeProjetos.Module.BusinessObjects.Entities
{
    #region Rules
    [XafDefaultProperty("Nome")]
    [NavigationItem("Usuários e Permissões")DefaultClassOptions] 
    #endregion
    public class Usuario : PermissionPolicyUser
    {
        #region Private Properties
        private string _nome;
        private string _email;
        private PerfilUsuario _perfilUsuario;
        private XPCollection<Permissao> _permissoesAvincular;
        #endregion

        #region Builders
        public Usuario(Session session) : base(session) { } 
        #endregion

        #region Public Properties
        public string Nome
        {
            get
            {
                return _nome;
            }

            set
            {
                SetPropertyValue("Nome", ref _nome, value);
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }

            set
            {
                SetPropertyValue("Email", ref _email, value);
            }
        }
        #region Rules
        [ImmediatePostData]
        [NonPersistent] 
        #endregion
        public PerfilUsuario PerfilUsuario
        {
            get
            {
                return _perfilUsuario;
            }

            set
            {
                SetPropertyValue("PerfilUsuario", ref _perfilUsuario, value);
            }
        }

        #region Rules
        [ImmediatePostData]
        [NonPersistent] 
        #endregion
        public XPCollection<Permissao> PermissoesAVincular
        {
            get
            {

                return _permissoesAvincular;
            }
            set
            {
                SetPropertyValue("PermissoesAVincular", ref _permissoesAvincular, value);
            }
        }

        #endregion

        #region OnChanged OnSaving       
        protected override void OnChanged(string propertyName, object oldValue, object newValue)
        {
            base.OnChanged(propertyName, oldValue, newValue);
            if (propertyName == "PerfilUsuario")
            {
                if (PerfilUsuario != null)
                {
                    PermissoesAVincular = PerfilUsuario.PermissoesPerfil;
                }
                else
                {
                    PermissoesAVincular = new XPCollection<Permissao>(Session, new List<Permissao>());
                }
            }
        }

        protected override void OnSaving()
        {
            if (PermissoesAVincular != null)
            {
                foreach (var item in this.PermissoesAVincular)
                {
                    if (this.Roles.IndexOf(item) < 0)
                    {

                        this.Roles.BaseAdd(item);
                        

                    }
                }
            }
            base.OnSaving();

        } 
        #endregion
    }
}
