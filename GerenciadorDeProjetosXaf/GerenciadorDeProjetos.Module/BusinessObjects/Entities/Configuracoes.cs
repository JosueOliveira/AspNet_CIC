using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using GerenciadorDeProjetos.Module.BusinessObjects.Shared;
using GerenciadorDeProjetos.Module.BusinessObjects.ClassUtils;

namespace GerenciadorDeProjetos.Module.BusinessObjects.Entities
{
    #region Anotations
    [NavigationItem("Configurações")DefaultClassOptions] 
    #endregion
    public class Configuracao : BaseClass
    {
        #region Private Properties
        private bool _alertaEmail;
        private string _enviarPara;
        private string _enviardoDe;
        private string _userName;
        private string _senha;
        private string _host;
        private string _porta;
        #endregion
        #region Builders
        public Configuracao(Session session) : base(session) { }
        #endregion
        #region Public Properties

        public bool AlertaEmail
        {
            get
            {
                return _alertaEmail;
            }

            set
            {
                SetPropertyValue("AlertaEmail", ref _alertaEmail, value);
            }
        }

        public string EnviarPara
        {
            get
            {
                return _enviarPara;
            }

            set
            {
                SetPropertyValue("EnviarPara", ref _enviarPara, value);
            }
        }

        public string EnviadoDe
        {
            get
            {
                return _enviardoDe;
            }

            set
            {
                SetPropertyValue("EnviadoDe", ref _enviardoDe, value);
            }
        }

        public string UserName
        {
            get
            {
                return _userName;
            }

            set
            {
                SetPropertyValue("UserName", ref _userName, value);
            }
        }

        public string Senha
        {
            get
            {
                return _senha;
            }

            set
            {
                SetPropertyValue("Senha", ref _senha, value);
            }
        }

        public string Host
        {
            get
            {
                return _host;
            }

            set
            {
                SetPropertyValue("host", ref _host, value);
            }
        }

        public string Porta
        {
            get
            {
                return _porta;
            }

            set
            {
                SetPropertyValue("Porta", ref _porta, value);
            }
        }
        #endregion

        protected override void OnSaved()
        {
            //Atualiza Parametros com Toda Modificação Durante A Aplicação Logada a cada Save do User
            base.OnSaved();
            Parametros.Configuracoes = this;
        }
    }
}
