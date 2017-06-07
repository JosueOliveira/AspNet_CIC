using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using GerenciadorDeProjetos.Module.BusinessObjects.Shared;
using System;

namespace GerenciadorDeProjetos.Module.BusinessObjects.Entities
{
    #region Anotations
    [DefaultClassOptions] 
    #endregion
    public class ComentarioTeste : BaseClass
    {
        #region Private Properties
        private SubTarefa _subTarefa;
        private DateTime _dataHora;
        private string _Comentario;
        #endregion

        #region Builders
        public ComentarioTeste(Session session) : base(session) { }
        #endregion

        #region Public Properties
        [Association("SubTarefa_ComentarioTeste")]
        public SubTarefa SubTarefa
        {
            get
            {
                return _subTarefa;
            }

            set
            {
                SetPropertyValue("SubTarefa", ref _subTarefa, value);
            }
        }

        public DateTime DataHora
        {
            get
            {
                return _dataHora;
            }

            set
            {
                SetPropertyValue("DataHora", ref _dataHora, value);
            }
        }
        [Size(512)]
        public string Comentario
        {
            get
            {
                return _Comentario;
            }

            set
            {
                SetPropertyValue("Comentario", ref _Comentario, value);
            }
        } 
        #endregion
    }
}
