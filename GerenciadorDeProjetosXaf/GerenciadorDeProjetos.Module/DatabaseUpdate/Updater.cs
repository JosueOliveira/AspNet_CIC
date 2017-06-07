using System;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Updating;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Security;
using GerenciadorDeProjetos.Module.BusinessObjects.Entities;
using static GerenciadorDeProjetos.Module.BusinessObjects.ClassUtils.SequenceGenerator;
using GerenciadorDeProjetos.Module.BusinessObjects.ClassUtils;

namespace GerenciadorDeProjetos.Module.DatabaseUpdate
{

    public class Updater : ModuleUpdater {
        public Updater(IObjectSpace objectSpace, Version currentDBVersion) :
            base(objectSpace, currentDBVersion) {
        }
        #region Carregamento dos Métodos Ao inicializar o Sistema
        public override void UpdateDatabaseAfterUpdateSchema()
        {
            base.UpdateDatabaseAfterUpdateSchema();
            SequenceGeneratorInitializer.Initialize();
            SequenceGenerator.RegisterSequences(XafTypesInfo.Instance.PersistentTypes);
            #region Carregamento Permissões de Acesso ao Sistema
            CriarUsuarioGrupo();
            CadastrarProjeto();
            ConsultarProjeto();
            CancelarProjeto();
            CadastrarTarefa();             
            DefinirResponsavel();
            Versionar();
            ReceberTarefas();
            CadastrarUsuario();
            CadastrarPerfil();
            ConfigurarSistema();
            EditarHorario();
            Desenvolver();
            Analisar();
            Testar();
            #endregion
            //-------------------------//
            #region Carregamento de Perfis Pré Definidos

            Diretor();
            GerenteDeProjeto();
            Analista();
            Desenvolvedor();
            Teste();
            Administrador(); 

            #endregion
            //-------------------------//
            ConfiguracaoEmail();
            ObjectSpace.CommitChanges();
        }
        #endregion
        //-------------------------//
        #region Permissões de Acesso ao Sistema

        private Permissao CadastrarProjeto()
        {

            Permissao CadProjRole = ObjectSpace.FindObject<Permissao>(new BinaryOperator("Name", "CadastrarProjeto"));
            if (CadProjRole == null)
            {
                CadProjRole = ObjectSpace.CreateObject<Permissao>();
                CadProjRole.Name = "CadastrarProjeto";
                CadProjRole.AddObjectPermission<PermissionPolicyUser>(SecurityOperations.Read, "[Oid] = CurrentUserId()", SecurityPermissionState.Allow);

            }                       
            CadProjRole.PermissionPolicy = SecurityPermissionPolicy.DenyAllByDefault;
            CadProjRole.AddTypePermissionsRecursively<Projeto>("Create;Write;Read", SecurityPermissionState.Allow);
            CadProjRole.AddTypePermissionsRecursively<Tarefa>("Read", SecurityPermissionState.Allow);
            CadProjRole.AddTypePermissionsRecursively<SubTarefa>("Read", SecurityPermissionState.Allow);
            CadProjRole.AddTypePermissionsRecursively<Versao>("Read", SecurityPermissionState.Allow);
            CadProjRole.AddTypePermissionsRecursively<Usuario>("Read", SecurityPermissionState.Allow);

            CadProjRole.AddNavigationPermission(@"Application/NavigationItems/Items/Projetos/Items/Projeto_ListView", SecurityPermissionState.Allow);
            CadProjRole.AddNavigationPermission(@"Application/NavigationItems/Items/Projetos/Items/CriarProjeto_DetailView", SecurityPermissionState.Allow);            
            CadProjRole.Save();
            return CadProjRole;
        }

        private Permissao ConsultarProjeto()
        {
            Permissao ConsultarP = ObjectSpace.FindObject<Permissao>(new BinaryOperator("Name", "ConsultarProjeto"));
            if (ConsultarP == null)
            {
                ConsultarP = ObjectSpace.CreateObject<Permissao>();
                ConsultarP.Name = "ConsultarProjeto";
            }
            ConsultarP.PermissionPolicy = SecurityPermissionPolicy.DenyAllByDefault;
            ConsultarP.AddTypePermissionsRecursively<Projeto>("Read", SecurityPermissionState.Allow);
            ConsultarP.AddTypePermissionsRecursively<Tarefa>("Read", SecurityPermissionState.Allow);
            ConsultarP.AddTypePermissionsRecursively<SubTarefa>("Read", SecurityPermissionState.Allow);
            ConsultarP.AddTypePermissionsRecursively<Versao>("Read", SecurityPermissionState.Allow);
            ConsultarP.AddTypePermissionsRecursively<Usuario>("Read", SecurityPermissionState.Allow);            
            ConsultarP.AddNavigationPermission(@"Application/NavigationItems/Items/Projetos/Items/ConsultaProjeto_ListView", SecurityPermissionState.Allow);
             
            ConsultarP.Save();
            return ConsultarP;
        }

        private Permissao CancelarProjeto()
        {
            Permissao DeletarP = ObjectSpace.FindObject<Permissao>(new BinaryOperator("Name", "CancelarProjeto"));
            if (DeletarP == null)
            {
                DeletarP = ObjectSpace.CreateObject<Permissao>();
                DeletarP.Name = "CancelarProjeto";
            }
            DeletarP.PermissionPolicy = SecurityPermissionPolicy.DenyAllByDefault;
            DeletarP.AddTypePermissionsRecursively<Projeto>("Delete", SecurityPermissionState.Allow);
            DeletarP.Save();
            return DeletarP;
        }

        private Permissao CadastrarTarefa()
        {
            Permissao CadTarefa = ObjectSpace.FindObject<Permissao>(new BinaryOperator("Name", "CadastrarTarefa"));
            if (CadTarefa == null)
            {
                CadTarefa = ObjectSpace.CreateObject<Permissao>();
                CadTarefa.Name = "CadastrarTarefa";
            }
            CadTarefa.PermissionPolicy = SecurityPermissionPolicy.DenyAllByDefault;
            CadTarefa.AddTypePermissionsRecursively<Tarefa>("Create;Write;Read;Delete", SecurityPermissionState.Allow);
            CadTarefa.AddTypePermissionsRecursively<SubTarefa>("Create;Write;Read;Delete", SecurityPermissionState.Allow);
            CadTarefa.AddTypePermissionsRecursively<Versao>("Read", SecurityPermissionState.Allow);
            CadTarefa.AddTypePermissionsRecursively<Usuario>("Read", SecurityPermissionState.Allow);

            CadTarefa.AddNavigationPermission(@"Application/NavigationItems/Items/Tarefas/Items/ConsultarTarefa_ListView", SecurityPermissionState.Allow);
            CadTarefa.AddNavigationPermission(@"Application/NavigationItems/Items/Tarefas/Items/CriarTarefa_DetailView", SecurityPermissionState.Allow);
            CadTarefa.AddNavigationPermission(@"Application/NavigationItems/Items/Tarefas/Items/Criar SubTarefa", SecurityPermissionState.Allow);
            CadTarefa.Save();
            return CadTarefa;
        }
       

        //private Permissao ConsultarTarefa()
        //{
        //    Permissao consultarT = ObjectSpace.FindObject<Permissao>(new BinaryOperator("Name", "ConsultarTarefa"));
        //    if (consultarT == null)
        //    {
        //        consultarT = ObjectSpace.CreateObject<Permissao>();
        //        consultarT.Name = "ConsultarTarefa";
        //    }
        //    consultarT.PermissionPolicy = SecurityPermissionPolicy.DenyAllByDefault;
        //    consultarT.Save();
        //    return consultarT;
        //}

        private Permissao DefinirResponsavel()
        {
            Permissao DefResp = ObjectSpace.FindObject<Permissao>(new BinaryOperator("Name", "DefinirResponsavel"));
            if (DefResp == null)
            {
                DefResp = ObjectSpace.CreateObject<Permissao>();
                DefResp.Name = "DefinirResponsavel";
            }
            DefResp.PermissionPolicy = SecurityPermissionPolicy.DenyAllByDefault;
            DefResp.AddTypePermissionsRecursively<Tarefa>("Write;Read", SecurityPermissionState.Allow);
            DefResp.AddTypePermissionsRecursively<SubTarefa>("Write;Read", SecurityPermissionState.Allow);
            DefResp.AddTypePermissionsRecursively<Usuario>("Read", SecurityPermissionState.Allow);
            DefResp.AddTypePermissionsRecursively<Versao>("Read", SecurityPermissionState.Allow);
            DefResp.AddTypePermissionsRecursively<Projeto>("Read", SecurityPermissionState.Allow);
                       

            DefResp.AddNavigationPermission(@"Application/NavigationItems/Items/Tarefas/Items/ConsultarTarefa_ListView", SecurityPermissionState.Allow);
            DefResp.Save();
            return DefResp;
        }

        private Permissao Versionar()
        {
            Permissao vers = ObjectSpace.FindObject<Permissao>(new BinaryOperator("Name", "Versionar"));
            if (vers == null)
            {
                vers = ObjectSpace.CreateObject<Permissao>();
                vers.Name = "Versionar";
            }
            vers.PermissionPolicy = SecurityPermissionPolicy.DenyAllByDefault;
            vers.AddTypePermissionsRecursively<Tarefa>("Write;Read", SecurityPermissionState.Allow);
            vers.AddTypePermissionsRecursively<Versao>("Create;Read", SecurityPermissionState.Allow);

            vers.AddNavigationPermission(@"Application/NavigationItems/Items/Tarefas/Items/Versao_DetailView", SecurityPermissionState.Allow);            
            vers.Save();
            return vers;
        }

        private Permissao ReceberTarefas()
        {
            Permissao receberTarefas = ObjectSpace.FindObject<Permissao>(new BinaryOperator("Name", "ReceberTarefas"));
            if (receberTarefas == null)
            {
                receberTarefas = ObjectSpace.CreateObject<Permissao>();
                receberTarefas.Name = "ReceberTarefas";
            }
            receberTarefas.PermissionPolicy = SecurityPermissionPolicy.DenyAllByDefault;
            receberTarefas.AddTypePermissionsRecursively<Tarefa>("Write;Read", SecurityPermissionState.Allow);
            receberTarefas.AddTypePermissionsRecursively<SubTarefa>("Write;Read", SecurityPermissionState.Allow);
            receberTarefas.AddTypePermissionsRecursively<Usuario>("Read", SecurityPermissionState.Allow);
            receberTarefas.AddTypePermissionsRecursively<Versao>("Read", SecurityPermissionState.Allow);

            receberTarefas.AddNavigationPermission(@"Application/NavigationItems/Items/Tarefas/Items/Tarefa_ListView", SecurityPermissionState.Allow);
            receberTarefas.Save();
            return receberTarefas;
        }

        private Permissao CadastrarUsuario()
        {
            Permissao cadastarUsuario = ObjectSpace.FindObject<Permissao>(new BinaryOperator("Name", "CadastrarUsuario"));
            if (cadastarUsuario == null)
            {
                cadastarUsuario = ObjectSpace.CreateObject<Permissao>();
                cadastarUsuario.Name = "CadastrarUsuario";
            }
            cadastarUsuario.PermissionPolicy = SecurityPermissionPolicy.DenyAllByDefault;
            cadastarUsuario.AddTypePermissionsRecursively<Usuario>("Create;Write;Read;Delete", SecurityPermissionState.Allow);
            cadastarUsuario.AddTypePermissionsRecursively<PerfilUsuario>("Read", SecurityPermissionState.Allow);            

            cadastarUsuario.AddNavigationPermission(@"Application/NavigationItems/Items/Usuários e Permissões/Items/PerfilUsuario_ListView", SecurityPermissionState.Allow);
            cadastarUsuario.AddNavigationPermission(@"Application/NavigationItems/Items/Usuários e Permissões/Items/Usuario_ListView", SecurityPermissionState.Allow);
            return cadastarUsuario;
        }

        private Permissao CadastrarPerfil()
        {
            Permissao cadPerfil = ObjectSpace.FindObject<Permissao>(new BinaryOperator("Name", "CadastrarPerfil"));
            if (cadPerfil == null)
            {
                cadPerfil = ObjectSpace.CreateObject<Permissao>();
                cadPerfil.Name = "CadastrarPerfil";
            }
            cadPerfil.PermissionPolicy = SecurityPermissionPolicy.DenyAllByDefault;
            cadPerfil.AddTypePermissionsRecursively<PerfilUsuario>("Create;Write;Read;Delete", SecurityPermissionState.Allow);            
            cadPerfil.AddNavigationPermission(@"Application/NavigationItems/Items/Usuários e Permissões/Items/PerfilUsuario_ListView", SecurityPermissionState.Allow);
            cadPerfil.AddNavigationPermission(@"Application/NavigationItems/Items/Usuários e Permissões/Items/Usuario_ListView", SecurityPermissionState.Allow);
            cadPerfil.Save();
            return cadPerfil;
        }

        private Permissao ConfigurarSistema()
        {
            Permissao config = ObjectSpace.FindObject<Permissao>(new BinaryOperator("Name", "ConfigurarSistema"));
            if (config == null)
            {
                config = ObjectSpace.CreateObject<Permissao>();
                config.Name = "ConfigurarSistema";
            }
            config.PermissionPolicy = SecurityPermissionPolicy.DenyAllByDefault;
            config.AddTypePermissionsRecursively<Configuracao>("Write;Read", SecurityPermissionState.Allow);
            config.AddNavigationPermission(@"Application/NavigationItems/Items/Configurações/Items/Configuracao_ListView", SecurityPermissionState.Allow);
            config.Save();
            return config;
        }

        private Permissao Relatorios()
        {
            Permissao relatorio = ObjectSpace.FindObject<Permissao>(new BinaryOperator("Name", "Relatorios"));
            if (relatorio == null)
            {
                relatorio = ObjectSpace.CreateObject<Permissao>();
                relatorio.Name = "Relatorios";
            }
            relatorio.PermissionPolicy = SecurityPermissionPolicy.DenyAllByDefault;
            relatorio.AddTypePermissionsRecursively<Projeto>("Read", SecurityPermissionState.Allow);
            relatorio.AddTypePermissionsRecursively<Tarefa>("Read", SecurityPermissionState.Allow);
            relatorio.AddTypePermissionsRecursively<SubTarefa>("Read", SecurityPermissionState.Allow);
            relatorio.AddTypePermissionsRecursively<Usuario>("Read", SecurityPermissionState.Allow);
            relatorio.AddTypePermissionsRecursively<Versao>("Read", SecurityPermissionState.Allow);
            relatorio.AddNavigationPermission(@"Application/NavigationItems/Items/Relatórios", SecurityPermissionState.Allow);            
            relatorio.Save();
            return relatorio;
        }

        private Permissao EditarHorario()
        {
            Permissao edHorario = ObjectSpace.FindObject<Permissao>(new BinaryOperator("Name", "EditarHorario"));
            if (edHorario == null)
            {
                edHorario = ObjectSpace.CreateObject<Permissao>();
                edHorario.Name = "EditarHorario";
            }
            edHorario.PermissionPolicy = SecurityPermissionPolicy.DenyAllByDefault;
            edHorario.AddTypePermissionsRecursively<Tarefa>("Write;Read", SecurityPermissionState.Allow);
            edHorario.AddTypePermissionsRecursively<SubTarefa>("Write;Read", SecurityPermissionState.Allow);
            edHorario.AddTypePermissionsRecursively<TempoTarefa>("Write;Read", SecurityPermissionState.Allow);
            edHorario.Save();
            return edHorario;
        }

        private Permissao Desenvolver()
        {
            Permissao desenvolv = ObjectSpace.FindObject<Permissao>(new BinaryOperator("Name", "Desenvolver"));
            if (desenvolv == null)
            {
                desenvolv = ObjectSpace.CreateObject<Permissao>();
                desenvolv.Name = "Desenvolver";
            }
            desenvolv.PermissionPolicy = SecurityPermissionPolicy.DenyAllByDefault;
            desenvolv.AddTypePermissionsRecursively<Tarefa>("Write;Read", SecurityPermissionState.Allow);
            desenvolv.AddTypePermissionsRecursively<SubTarefa>("Write;Read", SecurityPermissionState.Allow);
            desenvolv.AddTypePermissionsRecursively<TempoTarefa>("Read", SecurityPermissionState.Allow);            
            desenvolv.Save();
            return desenvolv;
        }

        private Permissao Analisar()
        {
            Permissao analiza = ObjectSpace.FindObject<Permissao>(new BinaryOperator("Name", "Analisar"));
            if (analiza == null)
            {
                analiza = ObjectSpace.CreateObject<Permissao>();
                analiza.Name = "Analisar";
            }
            analiza.PermissionPolicy = SecurityPermissionPolicy.DenyAllByDefault;
            analiza.AddTypePermissionsRecursively<Tarefa>("Write;Read", SecurityPermissionState.Allow);
            analiza.AddTypePermissionsRecursively<SubTarefa>("Write;Read", SecurityPermissionState.Allow);
            analiza.AddTypePermissionsRecursively<TempoTarefa>("Read", SecurityPermissionState.Allow);
            
            analiza.Save();
            return analiza;
        }

        private Permissao Testar()
        {
            Permissao testar = ObjectSpace.FindObject<Permissao>(new BinaryOperator("Name", "Testar"));
            if (testar == null)
            {
                testar = ObjectSpace.CreateObject<Permissao>();
                testar.Name = "Testar";
            }
            testar.PermissionPolicy = SecurityPermissionPolicy.DenyAllByDefault;
            testar.AddTypePermissionsRecursively<Tarefa>("Write;Read", SecurityPermissionState.Allow);
            testar.AddTypePermissionsRecursively<SubTarefa>("Write;Read", SecurityPermissionState.Allow);
            testar.AddTypePermissionsRecursively<TempoTarefa>("Read", SecurityPermissionState.Allow);            
            testar.Save();
            return testar;
        }
        #endregion
        //-------------------------//
        #region Perfis Pré Definidos

        private PerfilUsuario Diretor()
        {
            PerfilUsuario diretor = ObjectSpace.FindObject<PerfilUsuario>(new BinaryOperator("Nome", "Diretor"));
            if (diretor == null)
            {
                diretor = ObjectSpace.CreateObject<PerfilUsuario>();
                diretor.Nome = "Diretor";
            }
            diretor?.PermissoesPerfil?.Add(ConsultarProjeto());
            diretor?.PermissoesPerfil?.Add(Relatorios());
            
            return diretor;
        }

        private PerfilUsuario GerenteDeProjeto()
        {
            PerfilUsuario gerProj = ObjectSpace.FindObject<PerfilUsuario>(new BinaryOperator("Nome", "GerenteDeProjeto"));
            if (gerProj == null)
            {
                gerProj = ObjectSpace.CreateObject<PerfilUsuario>();
                gerProj.Nome = "GerenteDeProjeto";
            }
            gerProj?.PermissoesPerfil?.Add(CadastrarProjeto());
            gerProj?.PermissoesPerfil?.Add(CancelarProjeto());
            gerProj?.PermissoesPerfil?.Add(CadastrarTarefa());             
            gerProj?.PermissoesPerfil?.Add(DefinirResponsavel());
            gerProj?.PermissoesPerfil?.Add(CadastrarUsuario());
            gerProj?.PermissoesPerfil?.Add(EditarHorario());
            gerProj?.PermissoesPerfil?.Add(Relatorios());            
            return gerProj;
        }

        private PerfilUsuario Analista()
        {
            PerfilUsuario analista = ObjectSpace.FindObject<PerfilUsuario>(new BinaryOperator("Nome", "Analista"));
            if (analista == null)
            {
                analista = ObjectSpace.CreateObject<PerfilUsuario>();
                analista.Nome = "Analista";
            }
            analista?.PermissoesPerfil?.Add(ReceberTarefas());
            analista?.PermissoesPerfil?.Add(Analisar());
            return analista;
        }

        private PerfilUsuario Desenvolvedor()
        {
            PerfilUsuario developer = ObjectSpace.FindObject<PerfilUsuario>(new BinaryOperator("Nome", "Desenvolvedor"));
            if (developer == null)
            {
                developer = ObjectSpace.CreateObject<PerfilUsuario>();
                developer.Nome = "Desenvolvedor";
            }
            developer?.PermissoesPerfil?.Add(ReceberTarefas());
            developer?.PermissoesPerfil?.Add(Versionar());
            developer?.PermissoesPerfil?.Add(Desenvolver());
            return developer;
        }

        private PerfilUsuario Teste()
        {
            PerfilUsuario teste = ObjectSpace.FindObject<PerfilUsuario>(new BinaryOperator("Nome", "Teste"));
            if (teste == null)
            {
                teste = ObjectSpace.CreateObject<PerfilUsuario>();
                teste.Nome = "Teste";
            }
            teste?.PermissoesPerfil?.Add(ReceberTarefas());
            teste?.PermissoesPerfil?.Add(Testar());
            return teste;
        }

        private PerfilUsuario Administrador()
        {
            PerfilUsuario admin = ObjectSpace.FindObject<PerfilUsuario>(new BinaryOperator("Nome", "Administrador"));
            if (admin == null)
            {
                admin = ObjectSpace.CreateObject<PerfilUsuario>();
                admin.Nome = "Administrador";
            }              
            admin?.PermissoesPerfil?.Add(CadastrarUsuario());
            admin?.PermissoesPerfil?.Add(CadastrarPerfil());
            admin?.PermissoesPerfil?.Add(ConfigurarSistema());
            return admin;
        }
        #endregion
        //-------------------------//
        #region Usuário Super Admin
        private void CriarUsuarioGrupo()
        {
            //CRIA USUÁRIO E REGRAS ADMIN///////////
            Permissao AdminRole = CreateAdminRole();
            Usuario admin = ObjectSpace.FindObject<Usuario>(new BinaryOperator("UserName", "admin"));
            if (admin == null)
            {
                admin = ObjectSpace.CreateObject<Usuario>();
                admin.UserName = "admin";
                admin.SetPassword("");
            }
            admin.Roles.Add(AdminRole);
        }

        private Permissao CreateAdminRole()
        {
            Permissao adminRole = ObjectSpace.FindObject<Permissao>(new BinaryOperator("Name", "admin"));
            if (adminRole == null)
            {
                adminRole = ObjectSpace.CreateObject<Permissao>();
                adminRole.Name = "admin";
                //adminRole.AddObjectPermission<PermissionPolicyUser>(SecurityOperations.Read, "[Oid] = CurrentUserId()", SecurityPermissionState.Allow);
            }            
            adminRole.IsAdministrative = true;
            return adminRole;
        }

        #endregion
        //-------------------------//
        #region Config Email Padrão

        private void ConfiguracaoEmail()
        {
            Configuracao config = ObjectSpace.FindObject<Configuracao>(null);
            if (config == null)
            {
                config = ObjectSpace.CreateObject<Configuracao>();                
                config.Porta = "2500";
                config.Host = "ais.com.br";
                config.AlertaEmail = true;
                config.EnviadoDe = "comunicados@ais.com.br";
                config.EnviarPara = "josue@ais.com.br";
                config.Senha = "a91afzppv8";
                config.UserName = "comunicados@ais.com.br";

            }             
        } 
        #endregion
        public override void UpdateDatabaseBeforeUpdateSchema() {
            base.UpdateDatabaseBeforeUpdateSchema();
            
        }
    }
}
