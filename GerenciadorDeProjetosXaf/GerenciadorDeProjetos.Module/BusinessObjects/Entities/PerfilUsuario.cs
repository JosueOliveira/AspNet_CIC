using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using GerenciadorDeProjetos.Module.BusinessObjects.Shared;

namespace GerenciadorDeProjetos.Module.BusinessObjects.Entities
{
    #region Anotations
    [XafDefaultProperty("Nome")]
    [NavigationItem("Usuários e Permissões")DefaultClassOptions] 
    #endregion
    public class PerfilUsuario : BaseClass
    {
        #region Private Properties
        private string _nome;
        private XPCollection<Permissao> _permissoesPerfil;
        #endregion
        #region Builders
        public PerfilUsuario(Session session) : base(session) { }
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

        #endregion
        #region Associations
        [ImmediatePostData]
        [Association("PerfilPermissao")]
        public XPCollection<Permissao> PermissoesPerfil
        {
            get
            {
                return GetCollection<Permissao>("PermissoesPerfil");
            }           
        }
        #endregion

    }
}
