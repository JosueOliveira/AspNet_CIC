using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using GerenciadorDeProjetos.Module.BusinessObjects.Shared;

namespace GerenciadorDeProjetos.Module.BusinessObjects.Entities
{
    #region Anotations
    [NavigationItem("Tarefas")DefaultClassOptions] 
    [XafDefaultProperty("NumVersao")]    
    #endregion
    public class Versao : BaseClass
    {
        #region Private Properties
        private Projeto _projeto;                
        private string _versao;
        #endregion
        #region Builders
        public Versao(Session session) : base(session) { }
        #endregion
        #region Public Properties
        [XafDisplayName("Versão")]
        public string NumVersao
        {
            get
            {
                return _versao;
            }

            set
            {
                SetPropertyValue("NumVersao", ref _versao, value);
            }
        }
        [Association("Vesao")]
        public Projeto Projeto 
        {
            get
            {
                return _projeto; ;
            }

            set
            {
                SetPropertyValue("Projeto", ref _projeto, value);
            }
        }       
        #endregion
    }
}