using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using GerenciadorDeProjetos.Module.BusinessObjects.Shared;
using System;
using System.ComponentModel;
using System.Web.Security;

using DevExpress.Data.Filtering;
using System.Collections.Generic;

namespace GerenciadorDeProjetos.Module.BusinessObjects.Entities
{
    #region Rules     
    [NavigationItem("Tarefas")DefaultClassOptions]
    [XafDefaultProperty("Titulo")]        
    [RuleCriteria("Restrição de Cadastrar no Mínimo Uma Sub Tarefa", DefaultContexts.Save, "SubTarefa.Count > 0", "ATENÇÃO: É Nescessário Cadastrar no Mínimo Uma Sub Tarefa", SkipNullOrEmptyValues = false)]    
    [Appearance("Desablidita btn UserInRole != de CancelarProjeto", AppearanceItemType.Action, "true", TargetItems = "btnCancelar", Enabled = false, Criteria = "StatusTarefa = 'Cancelado' || !IsCurrentUserInRole('CancelarProjeto') && !IsCurrentUserInRole('admin')")]
    [Appearance("Desabilita Btn User != Role Versionar", AppearanceItemType.Action, "true", TargetItems = "btnVersionar", Enabled = false, Criteria = "!IsCurrentUserInRole('Versionar')")]
    #endregion
    public class Tarefa : SequencialObject
    {

        #region Private Properties        
        private Projeto _projeto;
        private string _titulo;
        private string _descricao;
        private TimeSpan _tempoRealizado;
        private TimeSpan _tempoPrevisto;
        private DateTime _dataInicio;
        private DateTime _dataFim;
        private Versao _versao;        
        private StatusTarefaEnum _statusTarefaEnum;
        #endregion

        #region Builders
        public Tarefa(Session session) : base(session) { }
        #endregion

        #region Public Properties
        
        
        #region Rules
        [ImmediatePostData]
        [Appearance("Desabilita Campo Titulo em Modo Edição", Criteria = "!IsNewObject", Enabled = false)] 
        #endregion
        public string Titulo
        {
            get
            {
                return _titulo;
            }

            set
            {
                SetPropertyValue("Titulo", ref _titulo, value);
            }
        }
        #region Rules
        [Size(512)]
        [Appearance("Desabilita Campo Descricao em Modo Edição", Criteria = "!IsNewObject", Enabled = true)] 
        #endregion
        public string Descricao
        {
            get
            {
                return _descricao;
            }

            set
            {
                SetPropertyValue("Descricao", ref _descricao, value);
            }
        }
        #region Rules
        [NonPersistent]
        [Appearance("Esconde Campo Em Modo Criação", Criteria = "IsNewObject", Visibility = ViewItemVisibility.Hide)] 
        #endregion
        public TimeSpan TempoRealizado
        {
            get
            {
                return _tempoRealizado;
            }

            set
            {
                SetPropertyValue("TempoRealizado", ref _tempoRealizado, value);
            }
        }
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
        #region Rules
        [Appearance("Ensconde Campo DataFim Em Modo Criação", Criteria = "IsNewObject", Visibility = ViewItemVisibility.Hide)] 
        #endregion
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
        #region Rules
        //[Appearance("Desabilita Campo TempoPrevisto Em Tarefa !Pendente", Criteria = "!StatusTarefa = 'Pendente'", Enabled = false)]
        [Appearance("Habilita Campo em Modo Criação", Criteria = "IsNewObject", Enabled = true)] 
        #endregion
        public TimeSpan TempoPrevisto
        {
            get
            {
                return _tempoPrevisto;
            }

            set
            {
                SetPropertyValue("TempoPrevisto", ref _tempoPrevisto, value);
            }
        }
        #region Rules
        [XafDisplayName("Versão")] 
        #endregion
        public Versao IdVersao
        {
            get
            {
                return _versao;
            }

            set
            {
                SetPropertyValue("IdVersao", ref _versao, value);
            }
        }
        #endregion

        #region Associations and Enum
        #region Rules
        [Association("Projeto")]
        [DataSourceCriteriaProperty("IsActive")]
        [DataSourceCriteria("!StatusProjeto = 'Cancelado' && !StatusProjeto = 'Finalizado'")] 
        #endregion
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
        #region Rules
        [DataSourceCriteria("IsActive && IsCurrentUserInRole('Desenvolver') && SubTarefa.EmTeste = true")]
        [Association("Subtarefa")]     
        #endregion
        public XPCollection<SubTarefa> SubTarefa
        {
            get
            {               
                return GetCollection<SubTarefa>("SubTarefa");
            }
        }
         
        #region Rules
        [ImmediatePostData]
        [Appearance("", Criteria = "!IsNewObject", Enabled = false)]
        [Appearance("Se Status = Pendente Cor Amarelo Claro", Criteria = "StatusTarefa = 'Pendente'", BackColor = "#F5F5DC")]
        [Appearance("Se Status Tarefa = Em Execução Verde", Criteria = "StatusTarefa = 'EmDesenvolvimento'", BackColor = "#98FB98")]
        [Appearance("Se Status Tarefa = Finalizado = Cor Azul", Criteria = "StatusTarefa = 'Finalizado'", BackColor = "#98FB98")] 
        [Appearance("Se Status Tarefa = Cancelado = Cor Vermelho", Criteria = "StatusTarefa = 'Cancelado'", BackColor = "#FF0000")]
        [Appearance("Se Status Tarefa = Desenvolvo Cor = Verde", Criteria = "StatusTarefa = 'Desenvolvido'", BackColor = "#87CEFF")]
        #endregion
        public StatusTarefaEnum StatusTarefa
        {
            get
            {
                return _statusTarefaEnum;
            }

            set
            {
                SetPropertyValue("StatusTarefa", ref _statusTarefaEnum, value);
            }
        }

        #endregion

        #region Override AfterConstruction
        //Ao Criar Uma Tarefa Status Default Pendente
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            {
                this.StatusTarefa = StatusTarefaEnum.Pendente;
                this.DataInicio = DateTime.Now;
            }
        }

        
        #endregion

        #region Retorna Usuários Envolvidos
        /// <summary>
        /// Retorna Lista de Usuários Envolvidos no Projeto
        /// </summary>
        /// <returns></returns>
        public List<Usuario> GetUsuariosTarefaEnvolvidos()
        {
            List<Usuario> usuarios = new List<Usuario>();
            foreach (var sub in SubTarefa)
            {
                if (!usuarios.Contains(sub.Desenvolvedor))
                    usuarios.Add(sub.Desenvolvedor);

                if (!usuarios.Contains(sub.Teste))
                    usuarios.Add(sub.Teste);


                if (!usuarios.Contains(sub.Analista))
                    usuarios.Add(sub.Analista);
            }
            return usuarios;
        } 
        #endregion
    }
}
