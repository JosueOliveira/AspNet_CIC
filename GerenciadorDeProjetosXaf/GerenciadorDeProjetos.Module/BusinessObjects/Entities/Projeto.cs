using DevExpress.Data.Filtering;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using GerenciadorDeProjetos.Module.BusinessObjects.NonPersistent;
using GerenciadorDeProjetos.Module.BusinessObjects.Shared;
using GerenciadorDeProjetos.Module.BusinessObjects.ClassUtils;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace GerenciadorDeProjetos.Module.BusinessObjects.Entities
{

    #region Rules
    [XafDefaultProperty("Titulo")]
    [NavigationItem("Projetos")DefaultClassOptions]
    
    
    #region Rules Btn
    [Appearance("Desabilita btn UserInRole != de CancelarProjeto", AppearanceItemType.Action, "true", TargetItems = "btnCancelar", Enabled = false, Criteria = "StatusProjeto = 'Cancelado' || StatusProjeto = 'Finalizado' || !IsCurrentUserInRole('CancelarProjeto') && !IsCurrentUserInRole('admin')")]
    #endregion
    #endregion
    public class Projeto : SequencialObject
    {
        #region Private Properties        
        private Usuario _gerente;
        private string _titulo;
        private string _descricao;
        private TimeSpan _tempoPrevisto;
        private TimeSpan _tempoRealizado;
        private DateTime _dataInicio;
        private DateTime _dataPrevistoFim;
        private DateTime _dataFim;
        private StatusProjetoEnum _statusProjetoEnum;
        #endregion

        #region Builders
        public Projeto(Session session) : base(session) { }
        #endregion

        #region Public Properties
        

        #region Rules
        [Appearance("Desabilita Campo Gerente em Modo Edição", Criteria = "!IsNewObject", Context = "DetailView", Enabled = false)]

        [DataSourceProperty("UsuarioGerente")] 
        #endregion
        public Usuario Gerente
        {
            get
            {
                return _gerente;
            }

            set
            {
                SetPropertyValue("Gerente", ref _gerente, value);
            }
        }

        #region Rules
        [Appearance("Desabilita Campo Titulo em Modo Edição", Criteria = "!IsNewObject", Context = "DetailView", Enabled = false)] 
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
        [ImmediatePostData] 
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
        //[Appearance("Desabilita Campo TempoPrevisto em Modo Edição", Criteria = "!StatusProjeto = 'Pendente'", Context = "DetailView", Enabled = false)]
        [Appearance("Habilita em Modo Criação", Criteria = "!IsNewObject", Enabled = false)] 
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
        [Appearance("Desabilita Campo TempoRealizado se Status Projeto = Pendente", Criteria = "!StatusProjeto = 'Pendente'", Context = "DetailView", Enabled = false)]
        [Appearance("Esconde Campo Em modo Criação", Criteria = "IsNewObject", Visibility = ViewItemVisibility.Hide)] 
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

        #region Rules
        [Appearance("Desabilita Campo DataInicio em Modo Edição", Criteria = "!IsNewObject", Context = "DetailView", Enabled = false)]
        [Appearance("Esconde em Modo Criação", Criteria = "IsNewObject", Visibility = ViewItemVisibility.Hide)] 
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

        public DateTime DataPrevistoFim
        {
            get
            {
                return _dataPrevistoFim;
            }

            set
            {
                SetPropertyValue("DataPrevistoFim", ref _dataPrevistoFim, value);
            }
        }

        #region Rules
        [Appearance("Desabilita Campo DataFim em Modo Edição", Criteria = "!IsNewObject", Context = "DetailView", Enabled = false)]
        [Appearance("Esconde Campo DataFim Se Projeto Dif. De CAncelado OU Finalizado", Criteria = "!StatusProjeto = 'Cancelado' And !StatusProjeto = 'Finalizado' ", Context = "DetailView", Visibility = ViewItemVisibility.Hide)] 
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

        #region Associations And Enum
        #region Rules
        [Association("Projeto")] 
        #endregion
        public XPCollection<Tarefa> Tarefas
        {
            get
            {
                return GetCollection<Tarefa>("Tarefas");
            }
        }
        #region Rules
        [Association("Vesao")] 
        #endregion
        public XPCollection<Versao> Versao
        {
            get
            {
                return GetCollection<Versao>("Versao");
            }
        }

        #region Rules
        //retirado teMporario para teste verde 
        //[Appearance("", Criteria = "!IsNewObject", Context = "DetailView", Enabled = false)]
        [Appearance("Esconde Campo em Modo CRIAR", Criteria = "IsNewObject", Visibility = ViewItemVisibility.Hide)]
        [Appearance("Cor Red em Status Cancelado", Criteria = "StatusProjeto = 'Cancelado'", BackColor = "#FF0000")]
        [Appearance("Cor Green em Status Verde", Criteria = "StatusProjeto = 'EmExecução'", BackColor = "#98FB98")]
        [Appearance("Cor Orenge em Status Pendente", Criteria = "StatusProjeto = 'Pendente'", BackColor = "#F5F5DC")]
        [Appearance("Se status = Aberto Cor  Amarelo", Criteria = "StatusProjeto = 'Aberto'", BackColor = "'#F5F5DC'")]
        [Appearance("Se status = Finalizado ", Criteria = "StatusProjeto = 'Finalizado'", BackColor = "#87CEFF")]
        [ImmediatePostData] 
        #endregion
        public StatusProjetoEnum StatusProjeto
        {
            get
            {
                return _statusProjetoEnum;
            }

            set
            {
                SetPropertyValue("StatusProjeto", ref _statusProjetoEnum, value);
            }
        }
        #endregion

        #region Override AfterContruction
        //Cada Projeto Criado Propriedade Será Pendente Por default
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            this.StatusProjeto = StatusProjetoEnum.Pendente;
            this.DataInicio = DateTime.Now;
        }

        
        #endregion

        #region Retorna User In Role Cadastrar Projeto
        [Browsable(false)]
        public XPCollection<PermissionPolicyUser> UsuarioGerente
        {
            get
            {
                Permissao role = Session.FindObject<Permissao>(BinaryOperator.Parse("Name = 'CadastrarProjeto'"));
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

        #region Retorna Usuários Envolvidos no Projeto
        /// <summary>
        /// Retorna todos User Envolvidos no Projeto
        /// </summary>        
        public List<Usuario> GetUsuariosProjetoEnvolvidos()
        {
            List<Usuario> usuarios = new List<Usuario>();
            foreach (var tarefa in Tarefas)
            {
                foreach (var sub in tarefa.SubTarefa)
                {
                    if (!usuarios.Contains(sub.Desenvolvedor))
                        usuarios.Add(sub.Desenvolvedor);

                    if (!usuarios.Contains(sub.Teste))
                        usuarios.Add(sub.Teste);


                    if (!usuarios.Contains(sub.Analista))
                        usuarios.Add(sub.Analista);
                }
            }
            return usuarios;
        } 
        #endregion

    }
}
