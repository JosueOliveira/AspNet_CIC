using DevExpress.Data.Filtering;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using GerenciadorDeProjetos.Module.BusinessObjects.Shared;
using GerenciadorDeProjetos.Module.BusinessObjects.ClassUtils;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace GerenciadorDeProjetos.Module.BusinessObjects.Entities
{
    #region Rules
    [XafDefaultProperty("Titulo")]
    [DefaultClassOptions]
    //Filtro de Montagem da ListView de Acordo com as Regras do Usuário da Sessão 
    [ListViewFilter("Filtro ListView", "IsCurrentUserInRole('Desenvolver') && [Desenvolvedor] = CurrentUserId() && [EmTeste] = false Or IsCurrentUserInRole('Testar') && [Teste] = CurrentUserId() && [EmTeste] = true Or IsCurrentUserInRole('CadastrarProjeto') && [Tarefa.Projeto.Gerente] = CurrentUserId() Or IsCurrentUserInRole('Analisar') && [Analista] = CurrentUserId() && [EmTeste] = false Or IsCurrentUserInRole('admin') Or [StatusSubTarefa] = 'Pendente' && [StatusSubTarefa] = 'EmDesenvolvimento' && [StatusSubTarefa] = 'Pausado' && [StatusSubTarefa] = 'Desenvolvido' && [StatusSubTarefa] = 'DisponivelTeste' && [StatusSubTarefa] = 'EmTeste' && [StatusSubTarefa] = 'TesteFinalizado'")]    
    //Desabilita Btn Se Role For Direfente de Testar
    [Appearance("Desabilita btn Role !Testar", AppearanceItemType.Action, "true", TargetItems = "btnReprovarPoP", Enabled = false, Criteria = "!IsCurrentUserInRole('Testar') && !IsCurrentUserInRole('admin')")]
    [Appearance("Habilita User Testar BtnArovar", AppearanceItemType.Action, "true", TargetItems = "btnAprovarTarefa", Enabled = false, Criteria = "!IsCurrentUserInRole('Testar') && !IsCurrentUserInRole('admin')")]
    [Appearance("Desabilita Btn Inicar Tarefa Caso Status Seja Reprovar Ou Aprovar", AppearanceItemType.Action, "true", TargetItems = "btnIniciarTarefa", Enabled = false, Criteria = "StatusSubTarefa = 'EmTeste' || StatusSubTarefa = 'EmDesenvolvimento'")]    
    [Appearance("Desabilita Btn Cancelar", AppearanceItemType.Action, "true", TargetItems = "btnCancelar", Enabled = false)]
    #endregion
    public class SubTarefa : SequencialObject
    {
        #region Private Properties
        private Tarefa _tarefa;        
        private string _titulo;
        private string _descricao;
        private Usuario _desenvolvedor;
        private Usuario _teste;
        private Usuario _analista;
        private TimeSpan _tempoRealizado;
        private DateTime _dataInicio;
        private DateTime _dataFim;
        private StatusSubTarefaEnum _statuSubTarefaEnum;
        private bool _correcao;
        private bool _emTeste;
        #endregion

        #region Builders
        public SubTarefa(Session session) : base(session) { }
        #endregion

        #region Public Properties
        
        #region Rules
        [Appearance("Desabilita Campo Titulo Em Mode Edição", Criteria = "!IsNewObject", Enabled = false)]
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
        [Size(-1)]
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
        //DataSourcePropertyIsNullMode filtra o retorno da property
        [DataSourceProperty("UsuarioDev", DataSourcePropertyIsNullMode.SelectNothing)]
        [DataSourceCriteriaProperty("IsActive")]
        #endregion
        public Usuario Desenvolvedor
        {
            get
            {

                return _desenvolvedor;
            }

            set
            {
                SetPropertyValue("Desenvolvedor", ref _desenvolvedor, value);
            }
        }
        #region Rules
        [RuleRequiredField("Torna Campo Obrigatório", DefaultContexts.Save, "ATENÇÃO: Informe um Usuario Teste")]
        [DataSourceProperty("UsuarioTeste", DataSourcePropertyIsNullMode.SelectNothing)]
        [DataSourceCriteriaProperty("IsActive")]
        #endregion
        public Usuario Teste
        {
            get
            {
                return _teste;
            }

            set
            {
                SetPropertyValue("Teste", ref _teste, value);
            }
        }
        #region Rules
        [DataSourceProperty("UsuarioAnalista", DataSourcePropertyIsNullMode.SelectNothing)]
        [DataSourceCriteriaProperty("IsActive")]
        #endregion
        public Usuario Analista
        {
            get
            {
                return _analista;
            }
            set
            {
                SetPropertyValue("Analista", ref _analista, value);
            }
        }
        #region Rules
        [Appearance("", Visibility = ViewItemVisibility.Hide)]
        #endregion
        public bool Correcao
        {
            get
            {
                return _correcao;
            }

            set
            {
                SetPropertyValue("Correcao", ref _correcao, value);
            }
        }
        #region Rules
        [Appearance("", Visibility = ViewItemVisibility.Hide)]
        #endregion
        public bool EmTeste
        {
            get
            {
                return _emTeste;
            }

            set
            {
                SetPropertyValue("EmTeste", ref _emTeste, value);
                _emTeste = value;
            }
        }

        #region Tempo Realizado Formatação Display
        //Propriedade Não Persistente Para Formatação do Tempo Realizado
        public string TempoUtilizado
        {
            get { return $"{TempoRealizado.Hours}h {TempoRealizado.Minutes}m e {TempoRealizado.Seconds}s"; }
        } 
        #endregion
        #region Rules
        [NonPersistent]
        #endregion
        public TimeSpan TempoRealizado
        {
            get
            {
                TimeSpan tempoRealizado = TimeSpan.MinValue;
                tempoRealizado = TimeSpan.Parse("00:00:00");    
                tempoRealizado += TempoTarefa.GetTempoTotal(this);
                TempoRealizado = tempoRealizado;
                return tempoRealizado;
            }
            set
            {
                SetPropertyValue("TempoRealizado", ref _tempoRealizado, value);
            }
        }
        #region Rules
        [Appearance("Esconde Campo Data Inicio em Modo Criação", Criteria = "IsNewObject", Visibility = ViewItemVisibility.Hide)]
        [Appearance("Esconde Campo Data Inicio em Modo Edição", Criteria = "!IsNewObject", Visibility = ViewItemVisibility.Hide)]
        #endregion
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
        [Appearance("Esconde Campo Data Fim em Modo Criação", Criteria = "IsNewObject", Visibility = ViewItemVisibility.Hide)]
        [Appearance("Esconde Campo DataFim em Mode Edição", Criteria = "!IsNewObject", Visibility = ViewItemVisibility.Hide)]
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
        #endregion

        #region Associations and Enum
        #region Rules
        [Association("Subtarefa")]
        #endregion
        public Tarefa Tarefa
        {
            get
            {
                return _tarefa;
            }

            set
            {
                SetPropertyValue("Tarefa", ref _tarefa, value);
            }
        }
        #region Rules 
        //CRITERIA- Aparece somente ao Usuário com Permissão de Edição de Tempo Tarefa
        [Appearance("Esconde Campo Historico Tempo User Sem Permissão", Criteria = "!IsCurrentUserInRole('EditarHorario')", Visibility = ViewItemVisibility.Hide)]
        [Association("tempoTarefa")]
        #endregion
        public XPCollection<TempoTarefa> HistoricoTempo
        {
            get
            {
                return GetCollection<TempoTarefa>("HistoricoTempo");
            }
        }
        #region Rules
        [Association("SubTarefa_ComentarioTeste")]
        #endregion
        public XPCollection<ComentarioTeste> Testes
        {
            get
            {
                return GetCollection<ComentarioTeste>("Testes");
            }
        }
        #region Rules
        [Appearance("Desabilita Campo em Modo de Edição", Criteria = "!IsNewObject", Enabled = false)]
        [XafDisplayName("Status")]

        #region Cores User Desenvolvedor
        [Appearance("Esconde em Modo Criação", Criteria = "IsNewObject", Visibility = ViewItemVisibility.Hide)]
        [Appearance("Se Status = Em Execução Cor Verde", Criteria = "StatusSubTarefa = 'EmDesenvolvimento'", BackColor = "#98FB98")]
        [Appearance("Se Status = Pausado Cor Laranja", Criteria = "StatusSubTarefa = 'Pausado'", BackColor = "#FFA500")]
        [Appearance("Se Status = Finalizado Cor Azul", Criteria = "StatusSubTarefa = 'Finalizado'", BackColor = "#87CEFF")]
        [Appearance("Se Status = Reprovado Cor Vermelho", Criteria = "StatusSubTarefa = 'Reprovado'", BackColor = "#FF0000")]
        [Appearance("Se Status = Pendente Cor Amarelo", Criteria = "StatusSubTarefa = 'Pendente'", BackColor = "#F5F5DC")]
        [Appearance("Se Status = EmTestes Cor Beige", Criteria = "StatusSubTarefa = 'EmTeste'", BackColor = "#F5F5DC")]
        [Appearance("Se Status = Aprovado Cor Verde", Criteria = "StatusSubTarefa = 'Aprovado'", BackColor = "#66CDAA")]
        [Appearance("Se Status em Correção = true", Criteria = "Correcao", BackColor = "#FF0000")]
        [Appearance("Se Status = Desenvolvido Cor Azul", Criteria = "StatusSubTarefa = 'Desenvolvido'", BackColor = "#87CEFF")]
        #endregion

        #region Cores User teste
        [Appearance("Se Status = TestePausado Cor Laranja", Criteria = "StatusSubTarefa = 'TestePausado'", BackColor = "#FFA500")]
        [Appearance("Se Status = TesteFinalizado Cor Verde", Criteria = "StatusSubTarefa = 'TesteFinalizado'", BackColor = "#98FB98")]
        [Appearance("Se Status = Disponivel Teste Cor Azul", Criteria = "StatusSubTarefa = 'DisponivelTeste'", BackColor = "#87CEFF")]
        #endregion

        #endregion
        public StatusSubTarefaEnum StatusSubTarefa
        {
            get
            {
                return _statuSubTarefaEnum;
            }

            set
            {
                SetPropertyValue("StatuSubTarefa", ref _statuSubTarefaEnum, value);
            }
        }
        #endregion

        #region Métodos HideBrowse Retorna Regras Users
        //método filtra e retona apenas regras selecionados
        [Browsable(false)]//DESABILITA O COMPONENTE NO BROWSE
        public XPCollection<PermissionPolicyUser> UsuarioDev
        {
            get
            {
                Permissao role = Session.FindObject<Permissao>(BinaryOperator.Parse("Name = 'Desenvolver'"));
                if (role != null)
                { return role.Users; }
                else
                { return null; }
            }
        }

        [Browsable(false)]
        public XPCollection<PermissionPolicyUser> UsuarioTeste
        {
            get
            {

                Permissao role = Session.FindObject<Permissao>(BinaryOperator.Parse("Name= 'Testar'"));
                if (role != null)
                {
                    return role.Users;
                }
                else
                {
                    return null;
                }
            }
        }

        [Browsable(false)]
        public XPCollection<PermissionPolicyUser> UsuarioAnalista
        {
            get
            {
                Permissao role = Session.FindObject<Permissao>(BinaryOperator.Parse("Name= 'Analisar'"));
                if (role != null)
                {
                    return role.Users;
                }
                else
                {
                    return null;
                }
            }
        }
        #endregion

        #region Métodos Override
        //Seta Um valor Pré-Definido Para Propriedade - Método Xaf         
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            this.StatusSubTarefa = StatusSubTarefaEnum.Pendente;
        }

        
        #endregion

        #region Retorna Todos Usuários Envolvidos No Projeto
        /// <summary>
        /// Retorna Todas Usuários Envolvidos no Projeto
        /// </summary>
        public List<Usuario> GetUsuariosEnvolvidos()
        {
            List<Usuario> usuarios = new List<Usuario>();
            if (!usuarios.Contains(Desenvolvedor))
                usuarios.Add(Desenvolvedor);

            if (!usuarios.Contains(Teste))
                usuarios.Add(Teste);


            if (!usuarios.Contains(Analista))
                usuarios.Add(Analista);

            return usuarios;
        }
        #endregion


       

        
    }
}
