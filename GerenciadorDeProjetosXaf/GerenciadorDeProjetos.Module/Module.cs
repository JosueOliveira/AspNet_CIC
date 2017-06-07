using System;
using System.Text;
using System.Linq;
using DevExpress.ExpressApp;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using System.Collections.Generic;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp.Model.Core;
using DevExpress.ExpressApp.Model.DomainLogics;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.Xpo;
using GerenciadorDeProjetos.Module.Views;
using GerenciadorDeProjetos.Module.BusinessObjects.Entities;
using GerenciadorDeProjetos.Module.BusinessObjects.ClassUtils;
using static GerenciadorDeProjetos.Module.BusinessObjects.ClassUtils.SequenceGenerator;

namespace GerenciadorDeProjetos.Module {
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppModuleBasetopic.aspx.
    public sealed partial class GerenciadorDeProjetosModule : ModuleBase {
        public GerenciadorDeProjetosModule() {
            InitializeComponent();
			BaseObject.OidInitializationMode = OidInitializationMode.AfterConstruction;
        }
        public override IEnumerable<ModuleUpdater> GetModuleUpdaters(IObjectSpace objectSpace, Version versionFromDB) {
            ModuleUpdater updater = new DatabaseUpdate.Updater(objectSpace, versionFromDB);
            return new ModuleUpdater[] { updater };
        }
        public override void Setup(XafApplication application) {
            base.Setup(application);
            //Inicializa SequenceGenerator
            SequenceGeneratorInitializer.Register(application);

            //application.LoggedOn -- Para carregar User Logado
            application.LoggedOn += Application_LoggedOn;
            application.CustomProcessShortcut += application_CustomProcessShortcut;
        }

        private void Application_LoggedOn(object sender, LogonEventArgs e)
        {
            try
            {
                using (IObjectSpace objectSpace = Application.CreateObjectSpace())
                {
                    //Istancia Config Atualizado A partir do Log Do sistema
                    Configuracao config = objectSpace.FindObject<Configuracao>(null);
                    
                    //Parametro Tem objeto Static Sem Persistência, Do tipo Configurações então recebe config
                    Parametros.Configuracoes = config;
                }
            }
            catch (Exception)
            {
                throw new Exception("Ocorreu um erro ao carregar os Parametros do sistema.");
            }
        }
        //Cria Views Do Projeto
        private void application_CustomProcessShortcut(object sender, CustomProcessShortcutEventArgs e)
        {
            if(e.Shortcut.ViewId == "ConsultaProjeto_DetailView")
            {              
                IObjectSpace objectspace = Application.CreateObjectSpace();
                ConsultaProjeto x = objectspace.CreateObject<ConsultaProjeto>();                              
                DetailView createView = Application.CreateDetailView(objectspace, x, true);
                createView.ViewEditMode = ViewEditMode.Edit;
                e.View = createView;
                e.Handled = true;
                                 
            }

            if (e.Shortcut.ViewId == "CriarProjeto_DetailView")
            {
                IObjectSpace objectspace = Application.CreateObjectSpace();
                Projeto x = objectspace.CreateObject<Projeto>();
                DetailView createView = Application.CreateDetailView(objectspace, "CriarProjeto_DetailView", true, x);
                createView.ViewEditMode = ViewEditMode.Edit;
                e.View = createView;
                e.Handled = true;
            }

            if (e.Shortcut.ViewId == "ConsultarTarefa_ListView")
            {
                IObjectSpace objectspace = Application.CreateObjectSpace();
                ConsultarTarefa x = objectspace.CreateObject<ConsultarTarefa>();
                DetailView createView = Application.CreateDetailView(objectspace, x, true);
                createView.ViewEditMode = ViewEditMode.Edit;
                e.View = createView;
                e.Handled = true;
            }

            if (e.Shortcut.ViewId == "CriarTarefa_DetailView")
            {
                IObjectSpace objectspace = Application.CreateObjectSpace();
                Tarefa x = objectspace.CreateObject<Tarefa>();
                DetailView createView = Application.CreateDetailView(objectspace ,"CriarTarefa_DetailView", true, x);
                createView.ViewEditMode = ViewEditMode.Edit;
                e.View = createView;
                e.Handled = true;
            }

            if (e.Shortcut.ViewId == "SubTarefa_DetailView")
            {
                IObjectSpace objectspace = Application.CreateObjectSpace();
                Tarefa x = objectspace.CreateObject<Tarefa>();
                DetailView createView = Application.CreateDetailView(objectspace, "SubTarefaVinculada_DetailView", true, x);
                createView.ViewEditMode = ViewEditMode.Edit;
                e.View = createView;
                e.Handled = true;
            }
            if(e.Shortcut.ViewId == "VersionarProjeto_DetailView")
            {
                IObjectSpace objectspace = Application.CreateObjectSpace();
                VersionarProjeto x = objectspace.CreateObject<VersionarProjeto>();
                DetailView createView = Application.CreateDetailView(objectspace, x, true);
                createView.ViewEditMode = ViewEditMode.Edit;
                e.View = createView;
                e.Handled = true;
            }
            if(e.Shortcut.ViewId == "SubTarefa_DetailView_Criar")
            {
                IObjectSpace objectspace = Application.CreateObjectSpace();
                SubTarefa tela = objectspace.CreateObject<SubTarefa>();
                DetailView createView = Application.CreateDetailView(objectspace, "SubTarefa_DetailView_Criar", true, tela);
                createView.ViewEditMode = ViewEditMode.Edit;
                e.View = createView;
                e.Handled = true;
            }

        }

        public override void CustomizeTypesInfo(ITypesInfo typesInfo) {
            base.CustomizeTypesInfo(typesInfo);
            CalculatedPersistentAliasHelper.CustomizeTypesInfo(typesInfo);
        }

         
    }
}
