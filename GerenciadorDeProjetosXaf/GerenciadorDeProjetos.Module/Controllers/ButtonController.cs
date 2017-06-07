using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using GerenciadorDeProjetos.Module.BusinessObjects.Entities;
using DevExpress.Xpo;
using DevExpress.ExpressApp.Xpo;
using GerenciadorDeProjetos.Module.Views;
using DevExpress.XtraEditors.Filtering.Templates;
using GerenciadorDeProjetos.Module.BusinessObjects.Shared;
using GerenciadorDeProjetos.Module.BusinessObjects.NonPersistent;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using System.Windows.Forms;
using DevExpress.Persistent.BaseImpl;
using GerenciadorDeProjetos.Module.BusinessObjects.ClassUtils;
using DevExpress.CodeParser;
using DevExpress.Xpo.DB;

namespace GerenciadorDeProjetos.Module.Controllers
{
    public partial class ButtonController : ViewController
    {
        #region Default XAF
        public ButtonController()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }
        #endregion

        #region BtnPesquisar
        private void btnPesquisar_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            #region Consultar Projeto
            if (View.Id == "ConsultaProjeto_DetailView")
            {
                ConsultaProjeto tela = (ConsultaProjeto)e.CurrentObject;
                //if(tela?.Status == null || tela?.Gerente == null) { throw new UserFriendlyException("Favor Verificar se Todos os Campos Estão Prenchidos"); }
                string filtro = "";
                object[] valores = { null, null, null, null, null };
                int nvalores = 0;

                if (tela.Gerente != null)
                {
                    if (filtro == "")
                    {
                        filtro += "[Gerente] = ?";
                        valores[nvalores++] = tela.Gerente.Oid;
                    }
                    else
                    {

                        filtro += " && [Gerente] = ?";
                        valores[nvalores++] = tela.Gerente.Oid;

                    }
                }


                if (tela.Status != StatusProjetoEnum.Todos)
                {
                    if (filtro == "")
                    {
                        filtro += "[StatusProjeto] = ?";
                        valores[nvalores++] = tela.Status;
                    }
                    else
                    {
                        filtro += " && [StatusProjeto] = ?";
                        valores[nvalores++] = tela.Status;

                    }
                }

                if (tela.DataInicio > DateTime.MinValue)
                {
                    if (filtro == "")
                    {
                        filtro += "[DataInicio] >= ?";
                        valores[nvalores++] = tela.DataInicio.Date;
                    }
                    else
                    {
                        filtro += " && [DataInicio] >= ?";
                        valores[nvalores++] = tela.DataInicio.Date;
                    }
                }
                if (tela.DataFim > DateTime.MinValue)
                {
                    if (filtro == "")
                    {
                        filtro += "[DataFim] >= ?";
                        valores[nvalores++] = tela.DataFim.Date;
                    }
                    else
                    {
                        filtro += " && [DataFim] >= ?";
                        valores[nvalores++] = tela.DataFim.Date;
                    }
                }
                CriteriaOperator criteria = CriteriaOperator.Parse(filtro, valores[0], valores[1], valores[2], valores[3], valores[4]);
                XPCollection<Projeto> xp = new XPCollection<Projeto>(((XPObjectSpace)ObjectSpace).Session, criteria);

                tela.Projetos = xp;


            }
            #endregion

            #region Consultar Tarefa
            if (View.Id == "ConsultarTarefa_DetailView")
            {
                ConsultarTarefa tela = (ConsultarTarefa)e.CurrentObject;

                String filtro = "";
                object[] valores = { null, null, null, null, null };
                int nvalores = 0;

                if (tela.Status != StatusTarefaEnum.Todos)
                {
                    if (filtro == "")
                    {
                        filtro += "[StatusTarefa] = ?";
                        valores[nvalores++] = tela.Status;
                    }
                    else
                    {
                        filtro += " && [StatusTarefa] = ?";
                        valores[nvalores++] = tela.Status;
                    }
                }

                if (tela.Projeto != null)
                {
                    if (filtro == "")
                    {
                        filtro += "[Projeto] = ?";
                        valores[nvalores++] = tela.Projeto;
                    }
                    else
                    {
                        filtro += " && [Projeto] = ?";
                        valores[nvalores++] = tela.Projeto;
                    }
                }

                if (tela.Usuario != null)
                {
                    if (tela.ContemEm != PerfilUsuarioEnum.Todos)
                    {
                        if (tela.ContemEm == PerfilUsuarioEnum.Desenvolvedor)
                        {
                            if (filtro == "")
                            {
                                filtro += "SubTarefa[Desenvolvedor = ?]";
                                valores[nvalores++] = tela.Usuario;
                            }
                            else
                            {
                                filtro += " && SubTarefa[Desenvolvedor = ?]";
                                valores[nvalores++] = tela.Usuario;
                            }
                        }

                        if (tela.ContemEm == PerfilUsuarioEnum.Analista)
                        {
                            if (filtro == "")
                            {
                                filtro += "SubTarefa[Analista = ?]";
                                valores[nvalores++] = tela.Usuario;
                            }
                            else
                            {
                                filtro += " && SubTarefa[Analista = ?]";
                                valores[nvalores++] = tela.Usuario;
                            }
                        }

                        if (tela.ContemEm == PerfilUsuarioEnum.Teste)
                        {
                            if (filtro == "")
                            {
                                filtro += "SubTarefa[Teste = ?]";
                                valores[nvalores++] = tela.Usuario;
                            }
                            else
                            {
                                filtro += " && SubTarefa[Teste = ?]";
                                valores[nvalores++] = tela.Usuario;
                            }
                        }

                        if (tela.ContemEm == PerfilUsuarioEnum.Gerente)
                        {
                            if (filtro == "")
                            {
                                filtro += "[Projeto.Gerente] = ?";
                                valores[nvalores++] = tela.Usuario;
                            }
                            else
                            {
                                filtro += " && [Projeto.Gerente] = ?";
                                valores[nvalores++] = tela.Usuario;
                            }
                        }
                    }


                }

                CriteriaOperator criteria = CriteriaOperator.Parse(filtro, valores[0], valores[1], valores[2], valores[3], valores[4]);
                XPCollection<Tarefa> tar = new XPCollection<Tarefa>(((XPObjectSpace)ObjectSpace).Session, criteria);

                tela.Tarefas = tar;
            }
            #endregion

            #region Consultar Versão
            if (View.Id == "VersionarProjeto_DetailView")
            {
                VersionarProjeto _telaVersionar = (VersionarProjeto)e.CurrentObject;

                if(_telaVersionar.Projeto == null) { throw new UserFriendlyException("Favor Selecionar um Projeto"); }
                //Cria Lista de Tarefas Desenvolvidas 
                XPCollection<Tarefa> tarefas = new XPCollection<Tarefa>(((XPObjectSpace)ObjectSpace).Session, CriteriaOperator.Parse("StatusTarefa = 'Desenvolvido' && Projeto.Oid = ? ", _telaVersionar.Projeto.Oid));
                              
                
               _telaVersionar.Tarefas = tarefas;
            } 
            #endregion
            View.Refresh();
        }
        #endregion

        #region BtnIniciarTarefa
        private void btnIniciarTarefa_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            if (View.Id == "SubTarefa_ListView")
            {

                SubTarefa subT = (SubTarefa)e.CurrentObject;
                //se status pendente seta data inicio se não continua a mesma
                if (subT.StatusSubTarefa == StatusSubTarefaEnum.Pendente)
                {
                    subT.DataInicio = DateTime.Now;
                }
                if (subT.DataInicio == null)
                {
                    subT.DataInicio = DateTime.Now;
                }
                 

                TempoTarefa _tempoTarefa = ObjectSpace.CreateObject<TempoTarefa>();

                _tempoTarefa.Data = DateTime.Now.Date;
                _tempoTarefa.HoraInicio = DateTime.Now.TimeOfDay;
                //Pega User da Sessão pela Id
                _tempoTarefa.User = ObjectSpace.GetObjectByKey<Usuario>(SecuritySystem.CurrentUserId);
                subT.HistoricoTempo.Add(_tempoTarefa);

                
                //Se Status do Projeto = Pendente o mesmo passa para EmExecução
                if (subT?.Tarefa?.Projeto?.StatusProjeto == StatusProjetoEnum.Pendente)
                {
                    subT.Tarefa.Projeto.StatusProjeto = StatusProjetoEnum.EmExecução; subT.Save();
                }
                //Se Status Tarefa = Pendente Ou Pausado O mesmo passa para EmExecução
                if (!subT.EmTeste)
                {
                    subT.StatusSubTarefa = StatusSubTarefaEnum.EmDesenvolvimento; subT.Save();
                    if (subT?.Tarefa?.StatusTarefa == StatusTarefaEnum.Pendente || subT?.Tarefa?.StatusTarefa == StatusTarefaEnum.Pausado)
                    {
                        subT.Tarefa.StatusTarefa = StatusTarefaEnum.EmDesenvolvimento; subT.Save();
                    }
                }
                
                if (subT.EmTeste)
                {
                    subT.StatusSubTarefa = StatusSubTarefaEnum.EmTeste;
                }

                subT.Correcao = false;
               
                ////TEMPORAIO PARA TESTE
                //if (subT?.StatusSubTarefa == StatusSubTarefaEnum.Finalizado)
                //{
                //    subT.StatusSubTarefa = StatusSubTarefaEnum.EmDesenvolvimento; subT.Save();
                //}
                ObjectSpace.CommitChanges();
            }
            View.Refresh();
        }
        #endregion

        #region BtnPausarTarefa
        private void PausarTarefa_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            if (View.Id == "SubTarefa_ListView")
            {
                SubTarefa subT = (SubTarefa)e.CurrentObject; subT.Save();

                if (subT.EmTeste)
                {
                    subT.StatusSubTarefa = StatusSubTarefaEnum.TestePausado;
                }else
                {
                    subT.StatusSubTarefa = StatusSubTarefaEnum.Pausado;
                }                   

               
                   
                    if (subT.HistoricoTempo == null) { throw new UserFriendlyException("Subtarefa não foi iniciada"); }
                    //Pega o Ultimo registro
                    TempoTarefa _horaPausa = subT.HistoricoTempo.FirstOrDefault(x => x.HoraFim == TimeSpan.Parse("00:00:00"));
                    if (_horaPausa != null)
                    {
                        _horaPausa.HoraFim = DateTime.Now.TimeOfDay;
                        _horaPausa.Save();
                    }
                    subT.Save();
                    ObjectSpace.CommitChanges();
                                 
                
            }
            View.Refresh();
        }

        #endregion

        #region BtnFinalizarTarefa
        private void btnFinalizar_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            if (View.Id == "SubTarefa_ListView")
            {
                //Converte Objeto Selecionado em SubTarefa
                SubTarefa SubT = (SubTarefa)e.CurrentObject;                
                //Procura em SubTarefa Status em: EmExecução, Pendente, Pausado, Reprovado, Aprovado, EmTeste
                //IEnumerable<SubTarefa> subtarefas = SubT.Tarefa.SubTarefa.Where(x => x.StatusSubTarefa != StatusSubTarefaEnum.Finalizado
                //&& x.StatusSubTarefa != StatusSubTarefaEnum.Cancelado && x.Tarefa == SubT.Tarefa);
                
                
                //Procura SubTarefas com Status EmExecução ou Pausado
                //Se Ecnontrou StatusSubTarefa = Finalizado
                if (SubT.StatusSubTarefa == StatusSubTarefaEnum.EmDesenvolvimento || SubT.StatusSubTarefa == StatusSubTarefaEnum.Pausado || SubT.StatusSubTarefa == StatusSubTarefaEnum.EmTeste || SubT.StatusSubTarefa == StatusSubTarefaEnum.TestePausado)
                {
                    if (SubT.EmTeste)
                    {
                        SubT.StatusSubTarefa = StatusSubTarefaEnum.TesteFinalizado; SubT.Save();
                    }else
                    {
                        SubT.StatusSubTarefa = StatusSubTarefaEnum.Desenvolvido; SubT.Save();
                    }
                   
                   

                    TempoTarefa _horaPausa = SubT.HistoricoTempo.FirstOrDefault(x => x.HoraFim == TimeSpan.Parse("00:00:00"));
                    if (_horaPausa != null) { _horaPausa.HoraFim = DateTime.Now.TimeOfDay; _horaPausa.Save(); }

                    

                    #region Verifica Status Tarefa Mãe
                    //Cria Collection de Todas subTarefas da Mesma tarefa
                    XPCollection<SubTarefa> sub = new XPCollection<SubTarefa>(((XPObjectSpace)ObjectSpace).Session, CriteriaOperator.Parse("[Tarefa] = ?", SubT.Tarefa));
                    int num = 0;
                    foreach (SubTarefa item in sub)
                    {
                        if (item.StatusSubTarefa != StatusSubTarefaEnum.Desenvolvido && item.StatusSubTarefa != StatusSubTarefaEnum.Cancelado && item.StatusSubTarefa != StatusSubTarefaEnum.Aprovado)
                        {
                            num += 1;
                        }
                    }

                    //Se NÃO encontrou Sub Tarefa com Status entre EmExecução, Pendente, Pausado, Reprovado, Aprovado, EmTeste
                    //Tarefa MÃE pode ser Finalizada por que Todas suas SubTarefas Estão Finalizadas ou Canceladas
                    //valor 1 pq Status (SubTarefa) do objeto atual ainda não esta Finalizado ou Cancelado
                    if (num == 0)
                    {
                        //Tarefa MÃE será Finalizada 
                        SubT.Tarefa.StatusTarefa = StatusTarefaEnum.Desenvolvido; 
                    } 
                    #endregion

                }

                #region Atualiza Status Projeto Principal
                ////Faz Busca de Tarefas do Mesmo Projeto                
                //XPCollection<Tarefa> tarefas = new XPCollection<Tarefa>(((XPObjectSpace)ObjectSpace).Session, CriteriaOperator.Parse("[Projeto] = ?", SubT.Tarefa.Projeto));

                //int cont = 0;
                //foreach (Tarefa itemTarefa in tarefas)
                //{
                //    if (itemTarefa.StatusTarefa != StatusTarefaEnum.Cancelado && itemTarefa.StatusTarefa != StatusTarefaEnum.Finalizado)
                //    {
                //        cont += 1;
                //    }
                //}
                ////Se Todas Tarefas Estiverem Finalizadas O Projeto Pai Será Finalizado
                ////Igual a "0" por Objeto (Tarefa) ja foi finalizada
                //if (cont == 0)
                //{
                //    //Projeto Pai será Finalizado
                //    SubT.Tarefa.Projeto.StatusProjeto = StatusProjetoEnum.Finalizado;
                //    SubT.Tarefa.Projeto.DataFim = DateTime.Now;
                //}   
                #endregion

                ObjectSpace.CommitChanges();
            }
            View.Refresh();
        }
        #endregion

        #region Btn Janela Pop Reprovar Tarefa
        private void btnReprovarAction(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            //Acumula em Itens o Objeto selecionado
            var itens = View.SelectedObjects;
            //Transforma Item em Objeto do Tipo Sub Tarefa
            foreach (SubTarefa subT in itens)
            {
                //Cria Tela do Tipo Comentario
                //ObjectSpace Conecxão com o Banco . (Operações)
                ComentarioAdd _tela = ObjectSpace.CreateObject<ComentarioAdd>();
                //coloca Objeto SubTarefa dentro da _tela Comentario Add
                //Subt.Oid utilizado para Pegar Oid do Objecto 1 dentro do Objeto secundario
                _tela.SubTarefa = ObjectSpace.GetObjectByKey<SubTarefa>(subT.Oid);
                //Cria Tela DetailView, Chama a Conecxão(ObjectSpace), Coloca Tela, Root = False por ser Objeto secundário
                DetailView createView = Application.CreateDetailView(ObjectSpace, _tela, false);
                //Determina View em modo de Edição .Edit
                createView.ViewEditMode = ViewEditMode.Edit;
                subT.Save();
                //Chama operador do Evento do Click e acumula Objecto
                e.View = createView;
            }
        }
        //btnReprovar Tarefa
        private void btnReprovarPoP_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
            //subT.Desenvolvedor.Email = "A tarefa {0} - SubTarefa {1} Foi reprovada pelo Motivo: {2}.";subT.Save();

            //subT.EmTeste = false;subT.Save();
            //subT.Correcao = true;subT.Save();
            //subT.StatusSubTarefa = StatusSubTarefaEnum.Reprovado;subT.Save();
            //SubTarefa subT = (SubTarefa)e.CurrentObject;
            //Acumula em View Objeto da Janela Pop Fazendo Casting para ComentarioAdd por ser Objeto da mesma intancia
            var view = (ComentarioAdd)e.PopupWindowViewCurrentObject;
            //Intancia Do Objeto ComentarioTeste Onde será Setado no banco
            ComentarioTeste comentario = ObjectSpace.CreateObject<ComentarioTeste>();
            //acumulou em Comentario.Sub tarefa o Objecto SubTarefa com o Oid da Sessão Pop
            comentario.SubTarefa = ObjectSpace.GetObjectByKey<SubTarefa>(view.Oid);
            //Acumula em ComentarioTeste.comentario Motivo da Janela PoP
            comentario.Comentario = view.Motivo;
            //Hora da Execução do btn Ok
            comentario.DataHora = DateTime.Now;
            //salva Alterarções do Comentario
            comentario.Save();
            //Add Cometario em Sub tarefa
            view.SubTarefa.Testes.Add(comentario);
            //Seta status da Sub Tarefa
            view.SubTarefa.StatusSubTarefa = StatusSubTarefaEnum.Reprovado;
            //
            if (view.SubTarefa.EmTeste)
            {
                view.SubTarefa.Tarefa.StatusTarefa = StatusTarefaEnum.Pendente;
            }

            comentario.SubTarefa.EmTeste = false;
            comentario.SubTarefa.Correcao = true;

            //Salva Alterações no Banco
            ObjectSpace.CommitChanges();
            string titulo = $"Sub Tarefa {comentario.SubTarefa.Codigo} reprovada. Necessário Atenção especial";
            string msg = $"A Tarefa {comentario.SubTarefa.Codigo} foi reprovada pelo motivo: {comentario.Comentario}";
            //Parametros.Configuracoes.EnviadoDe = comentario.SubTarefa.Teste.Email;
            Email.EnviarEmail(comentario?.SubTarefa?.Desenvolvedor?.Email, msg, titulo);
            //Atualiza View
            View.Refresh();
        }
        #endregion

        #region Btn Aprovar Tarefa

        private void btnAprovarTarefa_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            SubTarefa subT = (SubTarefa)e.CurrentObject;

            //Fazer Varredura em todas As Tarefas Pertencentes Ao Mesmo Projeto

            if (subT.StatusSubTarefa == StatusSubTarefaEnum.Finalizado || subT.StatusSubTarefa == StatusSubTarefaEnum.EmTeste || subT.StatusSubTarefa == StatusSubTarefaEnum.TesteFinalizado)
            {
                subT.StatusSubTarefa = StatusSubTarefaEnum.Aprovado;
                subT.Correcao = false;
                subT.EmTeste = false;
                subT.DataFim = DateTime.Now;

                XPCollection<TempoTarefa> tempo = new XPCollection<TempoTarefa>();
                tempo = new XPCollection<TempoTarefa>(((XPObjectSpace)ObjectSpace).Session);
                foreach (TempoTarefa x in tempo)
                {
                    x.HoraFim = x.HoraFim;
                    if (x != null) { x.Save(); if (subT.Correcao) { subT.Correcao = false; }; break; }
                }
                subT.Save();

                #region Verifica Status Tarefa Mãe
                //Cria Collection de Todas subTarefas da Mesma tarefa
                XPCollection<SubTarefa> sub = new XPCollection<SubTarefa>(((XPObjectSpace)ObjectSpace).Session, CriteriaOperator.Parse("[Tarefa] = ?", subT.Tarefa));
                int num = 0;
                foreach (SubTarefa item in sub)
                {
                    if (item.StatusSubTarefa != StatusSubTarefaEnum.Aprovado && item.StatusSubTarefa != StatusSubTarefaEnum.Cancelado)
                    {
                        num += 1;
                    }
                }

                //Se NÃO encontrou Sub Tarefa com Status entre EmExecução, Pendente, Pausado, Reprovado, Aprovado, EmTeste
                //Tarefa MÃE pode ser Finalizada por que Todas suas SubTarefas Estão Finalizadas ou Canceladas
                //valor 1 pq Status (SubTarefa) do objeto atual ainda não esta Finalizado ou Cancelado
                if (num == 0)
                {
                    //Tarefa MÃE será Finalizada 
                    subT.Tarefa.StatusTarefa = StatusTarefaEnum.Finalizado;
                    subT.DataFim = DateTime.Now;

                }
                #endregion

                #region Atualiza Status Projeto Principal
                //Faz Busca de Tarefas do Mesmo Projeto                
                XPCollection<Tarefa> tarefas = new XPCollection<Tarefa>(((XPObjectSpace)ObjectSpace).Session, CriteriaOperator.Parse("[Projeto] = ?", subT.Tarefa.Projeto));

                int cont = 0;
                foreach (Tarefa itemTarefa in tarefas)
                {
                    if (itemTarefa.StatusTarefa != StatusTarefaEnum.Cancelado && itemTarefa.StatusTarefa != StatusTarefaEnum.Aprovado && itemTarefa.StatusTarefa != StatusTarefaEnum.Finalizado)
                    {
                        cont += 1;
                    }
                }
                //Se Todas Tarefas Estiverem Finalizadas O Projeto Pai Será Finalizado
                //Igual a "0" por Objeto (Tarefa) ja foi finalizada
                if (cont == 0)
                {
                    //Projeto Pai será Finalizado
                    subT.Tarefa.Projeto.StatusProjeto = StatusProjetoEnum.Finalizado;                    
                    subT.Tarefa.Projeto.DataFim = DateTime.Now;
                }
                #endregion
            }



            ObjectSpace.CommitChanges();
            View.Refresh();
        }
        #endregion

        #region Btn Versionar
        private void btnVersionar_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            if (View.Id == "VersionarProjeto_Tarefas_ListView")
            {
                Tarefa tarefa = (Tarefa) e.CurrentObject;
                
                var tela = (VersionarProjeto)((DetailView)ObjectSpace.Owner).CurrentObject;
                //Versao versao = ObjectSpace.FindObject<Versao>(CriteriaOperator.Parse("NumVersao = ? && Projeto.Oid = ?", tela.NovaVersao, tela.Projeto.Oid));

                Versao versao = ObjectSpace.FindObject<Versao>(CriteriaOperator.Parse("NumVersao = ? && Projeto.Oid = ? && Oid = ?", tela.NovaVersao, tela.Projeto.Oid, tarefa.IdVersao));

                //XPCollection<Versao> versao = new XPCollection<Versao>(((XPObjectSpace)ObjectSpace).Session, CriteriaOperator.Parse("[Projeto] = ?", tela.Projeto.Oid));

                //XPCollection<Versao> versao = XPCollection<Versao>(CriteriaOperator.Parse("Projeto = ?", tela.Projeto.Oid));
                if (versao != null) throw new Exception("ATENÇÃO: Versão já existente"); 

                if (tela.NovaVersao == null) throw new Exception("ATENÇÃO: Informe uma Versão");
                versao = ObjectSpace.CreateObject<Versao>();
                versao.Projeto = tela.Projeto;
                versao.NumVersao = tela.NovaVersao;
                versao.Save();

                
                    tarefa.IdVersao = versao;
                    tarefa.StatusTarefa = StatusTarefaEnum.EmTeste;
                    foreach (var subT in tarefa.SubTarefa)
                    {
                        if (subT.StatusSubTarefa != StatusSubTarefaEnum.Aprovado)
                        {
                            subT.EmTeste = true;
                            subT.StatusSubTarefa = StatusSubTarefaEnum.DisponivelTeste;
                        }
                    }
                
                ObjectSpace.CommitChanges();
            }
            View.Refresh();
        }

        #endregion

        #region Btn Limpar
        private void btnLimpar_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            if (View.Id == "ConsultaProjeto_DetailView")
            {
                ConsultaProjeto tela = (ConsultaProjeto)e.CurrentObject;
                tela.Projetos = null;
            }

            if (View.Id == "ConsultarTarefa_DetailView")
            {
                ConsultarTarefa tela = (ConsultarTarefa)e.CurrentObject;
                tela.Tarefas = null;
            }
        }
        #endregion

        #region Btn Cancelar
        private void btnCancelar_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            #region Cancelar Projeto
            if (View.Id == "Projeto_ListView")
            {
                Projeto tela = (Projeto)e.CurrentObject;

                tela.StatusProjeto = StatusProjetoEnum.Cancelado;
                tela.DataFim = DateTime.Now;


                foreach (Tarefa item in tela.Tarefas)
                {
                    item.StatusTarefa = StatusTarefaEnum.Cancelado;
                    foreach (SubTarefa subT in item.SubTarefa)
                    {
                        subT.StatusSubTarefa = StatusSubTarefaEnum.Cancelado;

                        if (subT.DataFim > DateTime.MinValue)
                        {
                            subT.DataFim = DateTime.Now;
                        }
                    }
                    if (item.DataFim > DateTime.MinValue)
                    {
                        item.DataFim = DateTime.Now;
                    }
                    item.Save();
                }


                //Envia Mail a Todos User Envolvidos No projeto
                string titulo = $"Projeto { tela.Titulo } foi Cancelado ";
                string msg = $"A Tarefa { tela } foi Cancelada ";

                foreach (var item in tela.GetUsuariosProjetoEnvolvidos())
                {
                    if (item != null)
                    {
                        Email.EnviarEmail(item.Email, msg, titulo);
                    }
                }
                tela.Save();
            }
            #endregion

            #region Cancelar Tarefa
            if (View.Id == "Projeto_Tarefas_ListView")
            {
                Tarefa tela = (Tarefa)e.CurrentObject;

                tela.StatusTarefa = StatusTarefaEnum.Cancelado;
                foreach (SubTarefa item in tela.SubTarefa)
                {
                    item.StatusSubTarefa = StatusSubTarefaEnum.Cancelado;

                    item.Save();
                }
                tela.Save();
            }


            if (View.Id == "ConsultarTarefa_Tarefas_ListView")
            {
                Tarefa tela = (Tarefa)e.CurrentObject;

                tela.StatusTarefa = StatusTarefaEnum.Cancelado;
                foreach (SubTarefa item in tela.SubTarefa)
                {
                    item.StatusSubTarefa = StatusSubTarefaEnum.Cancelado;

                    item.Save();
                }
                tela.Save();
            }
            #endregion

            ObjectSpace.CommitChanges();
            View.Refresh();
        }
        #endregion

              
       
    }
}
