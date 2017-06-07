using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using GerenciadorDeProjetos.Module.BusinessObjects.Shared;
using System;

namespace GerenciadorDeProjetos.Module.BusinessObjects.Entities
{
    #region Anotations
    [DefaultClassOptions] 
    #endregion
    public class TempoTarefa : BaseClass
    {
        #region Private Properties
        private DateTime _data;
        private TimeSpan _horaInicio;
        private TimeSpan _horaFim;
        private Usuario _user;
        private SubTarefa _subTarefa;
        #endregion

        #region Builders
        public TempoTarefa(Session session) : base(session) { }
        #endregion

        #region Public Properties

        #region Data
        public DateTime Data
        {
            get
            {
                return _data;
            }

            set
            {
                SetPropertyValue("Data", ref _data, value);
            }
        }
        #endregion

        #region Hora Inicio
        public TimeSpan HoraInicio
        {
            get
            {
                return _horaInicio;
            }

            set
            {
                SetPropertyValue("HoraInicio", ref _horaInicio, value);
            }
        }
        #endregion

        #region Hora Fim
        public TimeSpan HoraFim
        {
            get
            {
                return _horaFim;
            }

            set
            {
                SetPropertyValue("HoraFim", ref _horaFim, value);
            }
        }
        #endregion

        #region Usuario
        public Usuario User
        {
            get
            {
                return _user;
            }

            set
            {
                SetPropertyValue("User", ref _user, value);
            }
        } 
        #endregion

        #endregion

        #region Associations And Enum
        #region Rules
        [Association("tempoTarefa")] 
        #endregion
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
        #endregion

        #region Calculo Tempo Tarefa
        public static TimeSpan GetTempoTotal(SubTarefa subT)
        {
            TimeSpan resultado = TimeSpan.MinValue;
            resultado = TimeSpan.Parse("00:00:00");
            foreach (var item in subT.HistoricoTempo)
            {
                TimeSpan total = new TimeSpan(item.HoraFim.Ticks - item.HoraInicio.Ticks);

                if (item.HoraFim > TimeSpan.Parse("00:00:00"))
                {
                    resultado += total;
                }
            }
            return resultado;
        } 
        #endregion
    }
}
