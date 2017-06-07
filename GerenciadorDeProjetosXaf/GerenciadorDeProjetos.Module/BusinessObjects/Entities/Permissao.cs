using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using DevExpress.Xpo;

namespace GerenciadorDeProjetos.Module.BusinessObjects.Entities
{
    public class Permissao : PermissionPolicyRole
    {
        #region Associations
        [Association("PerfilPermissao")]
        public XPCollection<PerfilUsuario> PerfilRelacionado
        {
            get { return GetCollection<PerfilUsuario>("PerfilRelacionado"); }
        } 
        #endregion

        #region Builders
        public Permissao(Session session) : base(session) { } 
        #endregion

    }
}
