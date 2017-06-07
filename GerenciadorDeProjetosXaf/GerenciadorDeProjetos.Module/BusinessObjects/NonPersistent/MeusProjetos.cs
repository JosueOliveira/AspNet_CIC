using DevExpress.Xpo;
using GerenciadorDeProjetos.Module.BusinessObjects.Entities;

namespace GerenciadorDeProjetos.Module.BusinessObjects.NonPersistent
{
    #region Anotations
    [NonPersistent]     
    #endregion
    public partial class MeusProjetos : XPBaseObject
    {
        #region Private Properties
        private XPCollection<Projeto> _projetos; 
        #endregion
        #region Builders
        public MeusProjetos(Session session) : base(session) { }
        #endregion
        #region Public Properties

        public XPCollection<Projeto> projetos
        {
            get
            {
                return _projetos;
            }
            set
            {
                SetPropertyValue("projetos", ref _projetos, value);
            }
        } 
        #endregion
    }
}
