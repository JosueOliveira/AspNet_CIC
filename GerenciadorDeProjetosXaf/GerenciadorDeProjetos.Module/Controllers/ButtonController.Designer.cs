namespace GerenciadorDeProjetos.Module.Controllers
{
    partial class ButtonController
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ButtonController));
            this.btnPesquisar = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            this.btnLimpar = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            this.PausarTarefa = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            this.btnIniciarTarefa = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            this.btnFinalizar = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            this.btnReprovarPoP = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            this.btnAprovarTarefa = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            this.btnVersionar = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            this.btnCancelar = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Caption = "Pesquisar";
            this.btnPesquisar.Category = "Pesquisar";
            this.btnPesquisar.ConfirmationMessage = null;
            this.btnPesquisar.Id = "btnPesquisar";
            this.btnPesquisar.ImageName = "Pesquisa20.png";
            this.btnPesquisar.PaintStyle = DevExpress.ExpressApp.Templates.ActionItemPaintStyle.CaptionAndImage;
            this.btnPesquisar.ToolTip = null;
            this.btnPesquisar.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.btnPesquisar_Execute);
            // 
            // btnLimpar
            // 
            this.btnLimpar.Caption = "Limpar";
            this.btnLimpar.Category = "Limpar";
            this.btnLimpar.ConfirmationMessage = null;
            this.btnLimpar.Id = "btnLimpar";
            this.btnLimpar.ImageName = "Limpar20.png";
            this.btnLimpar.PaintStyle = DevExpress.ExpressApp.Templates.ActionItemPaintStyle.CaptionAndImage;
            this.btnLimpar.ToolTip = null;
            this.btnLimpar.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.btnLimpar_Execute);
            // 
            // PausarTarefa
            // 
            this.PausarTarefa.Caption = "Pausar Tarefa";
            this.PausarTarefa.Category = "Edit";
            this.PausarTarefa.ConfirmationMessage = null;
            this.PausarTarefa.Id = "PausarTarefa";
            this.PausarTarefa.ImageName = "Pause20.png";
            this.PausarTarefa.SelectionDependencyType = DevExpress.ExpressApp.Actions.SelectionDependencyType.RequireSingleObject;
            this.PausarTarefa.TargetObjectsCriteria = "StatusSubTarefa = \'EmDesenvolvimento\' || StatusSubTarefa = \'EmTeste\'";
            this.PausarTarefa.TargetObjectType = typeof(GerenciadorDeProjetos.Module.BusinessObjects.Entities.SubTarefa);
            this.PausarTarefa.TargetViewId = "SubTarefa_ListView";
            this.PausarTarefa.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
            this.PausarTarefa.ToolTip = null;
            this.PausarTarefa.TypeOfView = typeof(DevExpress.ExpressApp.ListView);
            this.PausarTarefa.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.PausarTarefa_Execute);
            // 
            // btnIniciarTarefa
            // 
            this.btnIniciarTarefa.Caption = "Iniciar";
            this.btnIniciarTarefa.Category = "Edit";
            this.btnIniciarTarefa.ConfirmationMessage = null;
            this.btnIniciarTarefa.Id = "btnIniciarTarefa";
            this.btnIniciarTarefa.ImageName = "play20.png";
            this.btnIniciarTarefa.PaintStyle = DevExpress.ExpressApp.Templates.ActionItemPaintStyle.Image;
            this.btnIniciarTarefa.SelectionDependencyType = DevExpress.ExpressApp.Actions.SelectionDependencyType.RequireSingleObject;
            this.btnIniciarTarefa.TargetObjectsCriteria = "!StatusSubTarefa = \'Desenvolvido\' && !StatusSubTarefa = \'TesteFinalizado\' && !Sta" +
    "tusSubTarefa = \'Aprovado\'";
            this.btnIniciarTarefa.TargetObjectType = typeof(GerenciadorDeProjetos.Module.BusinessObjects.Entities.SubTarefa);
            this.btnIniciarTarefa.TargetViewId = "SubTarefa_ListView";
            this.btnIniciarTarefa.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
            this.btnIniciarTarefa.ToolTip = null;
            this.btnIniciarTarefa.TypeOfView = typeof(DevExpress.ExpressApp.ListView);
            this.btnIniciarTarefa.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.btnIniciarTarefa_Execute);
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.Caption = "Finalizar";
            this.btnFinalizar.Category = "Edit";
            this.btnFinalizar.ConfirmationMessage = "ATENÇÃO: Deseja Relamente Finalizar a Sub-Tarefa? ";
            this.btnFinalizar.Id = "btnFinalizar";
            this.btnFinalizar.ImageName = "Stop20.png";
            this.btnFinalizar.PaintStyle = DevExpress.ExpressApp.Templates.ActionItemPaintStyle.Image;
            this.btnFinalizar.SelectionDependencyType = DevExpress.ExpressApp.Actions.SelectionDependencyType.RequireSingleObject;
            this.btnFinalizar.TargetObjectsCriteria = resources.GetString("btnFinalizar.TargetObjectsCriteria");
            this.btnFinalizar.TargetObjectType = typeof(GerenciadorDeProjetos.Module.BusinessObjects.Entities.SubTarefa);
            this.btnFinalizar.TargetViewId = "SubTarefa_ListView";
            this.btnFinalizar.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
            this.btnFinalizar.ToolTip = null;
            this.btnFinalizar.TypeOfView = typeof(DevExpress.ExpressApp.ListView);
            this.btnFinalizar.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.btnFinalizar_Execute);
            // 
            // btnReprovarPoP
            // 
            this.btnReprovarPoP.AcceptButtonCaption = null;
            this.btnReprovarPoP.CancelButtonCaption = null;
            this.btnReprovarPoP.Caption = "Reprovar";
            this.btnReprovarPoP.Category = "Edit";
            this.btnReprovarPoP.ConfirmationMessage = null;
            this.btnReprovarPoP.Id = "btnReprovarPoP";
            this.btnReprovarPoP.ImageName = "reprovar16.png";
            this.btnReprovarPoP.PaintStyle = DevExpress.ExpressApp.Templates.ActionItemPaintStyle.Image;
            this.btnReprovarPoP.SelectionDependencyType = DevExpress.ExpressApp.Actions.SelectionDependencyType.RequireSingleObject;
            this.btnReprovarPoP.TargetObjectsCriteria = "";
            this.btnReprovarPoP.TargetObjectsCriteriaMode = DevExpress.ExpressApp.Actions.TargetObjectsCriteriaMode.TrueForAll;
            this.btnReprovarPoP.TargetObjectType = typeof(GerenciadorDeProjetos.Module.BusinessObjects.Entities.SubTarefa);
            this.btnReprovarPoP.TargetViewId = "SubTarefa_ListView";
            this.btnReprovarPoP.ToolTip = "Reprovar Tarefa";
            this.btnReprovarPoP.TypeOfView = typeof(DevExpress.ExpressApp.View);
            this.btnReprovarPoP.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.btnReprovarAction);
            this.btnReprovarPoP.Execute += new DevExpress.ExpressApp.Actions.PopupWindowShowActionExecuteEventHandler(this.btnReprovarPoP_Execute);
            // 
            // btnAprovarTarefa
            // 
            this.btnAprovarTarefa.Caption = "btn Aprovar Tarefa";
            this.btnAprovarTarefa.Category = "Edit";
            this.btnAprovarTarefa.ConfirmationMessage = null;
            this.btnAprovarTarefa.Id = "btnAprovarTarefa";
            this.btnAprovarTarefa.ImageName = "Xafaprovar20.png";
            this.btnAprovarTarefa.PaintStyle = DevExpress.ExpressApp.Templates.ActionItemPaintStyle.Image;
            this.btnAprovarTarefa.SelectionDependencyType = DevExpress.ExpressApp.Actions.SelectionDependencyType.RequireSingleObject;
            this.btnAprovarTarefa.TargetObjectsCriteria = "StatusSubTarefa = \'TesteFinalizado\'";
            this.btnAprovarTarefa.TargetObjectType = typeof(GerenciadorDeProjetos.Module.BusinessObjects.Entities.SubTarefa);
            this.btnAprovarTarefa.TargetViewId = "SubTarefa_ListView";
            this.btnAprovarTarefa.ToolTip = "Aprovar Tarefa";
            this.btnAprovarTarefa.TypeOfView = typeof(DevExpress.ExpressApp.View);
            this.btnAprovarTarefa.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.btnAprovarTarefa_Execute);
            // 
            // btnVersionar
            // 
            this.btnVersionar.Caption = "Versionar";
            this.btnVersionar.ConfirmationMessage = null;
            this.btnVersionar.Id = "btnVersionar";
            this.btnVersionar.SelectionDependencyType = DevExpress.ExpressApp.Actions.SelectionDependencyType.RequireMultipleObjects;
            this.btnVersionar.TargetObjectType = typeof(GerenciadorDeProjetos.Module.BusinessObjects.Entities.Tarefa);
            this.btnVersionar.TargetViewId = "VersionarProjeto_Tarefas_ListView";
            this.btnVersionar.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
            this.btnVersionar.ToolTip = null;
            this.btnVersionar.TypeOfView = typeof(DevExpress.ExpressApp.ListView);
            this.btnVersionar.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.btnVersionar_Execute);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Caption = "Cancelar";
            this.btnCancelar.Category = "Edit";
            this.btnCancelar.ConfirmationMessage = null;
            this.btnCancelar.Id = "btnCancelar";
            this.btnCancelar.ImageName = "Xafcancelar16.png";
            this.btnCancelar.PaintStyle = DevExpress.ExpressApp.Templates.ActionItemPaintStyle.Image;
            this.btnCancelar.SelectionDependencyType = DevExpress.ExpressApp.Actions.SelectionDependencyType.RequireSingleObject;
            this.btnCancelar.TargetObjectsCriteria = " ";
            this.btnCancelar.TargetViewId = "";
            this.btnCancelar.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
            this.btnCancelar.ToolTip = "Cancelar";
            this.btnCancelar.TypeOfView = typeof(DevExpress.ExpressApp.ListView);
            this.btnCancelar.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.btnCancelar_Execute);
            // 
            // ButtonController
            // 
            this.Actions.Add(this.btnPesquisar);
            this.Actions.Add(this.btnLimpar);
            this.Actions.Add(this.PausarTarefa);
            this.Actions.Add(this.btnIniciarTarefa);
            this.Actions.Add(this.btnFinalizar);
            this.Actions.Add(this.btnReprovarPoP);
            this.Actions.Add(this.btnAprovarTarefa);
            this.Actions.Add(this.btnVersionar);
            this.Actions.Add(this.btnCancelar);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SimpleAction btnPesquisar;
        private DevExpress.ExpressApp.Actions.SimpleAction btnIniciarTarefa;
        private DevExpress.ExpressApp.Actions.SimpleAction PausarTarefa;
        private DevExpress.ExpressApp.Actions.SimpleAction btnFinalizar;
        private DevExpress.ExpressApp.Actions.PopupWindowShowAction btnReprovarPoP;
        private DevExpress.ExpressApp.Actions.SimpleAction btnAprovarTarefa;
        private DevExpress.ExpressApp.Actions.SimpleAction btnVersionar;
        private DevExpress.ExpressApp.Actions.SimpleAction btnLimpar;
        private DevExpress.ExpressApp.Actions.SimpleAction btnCancelar;
    }
}
