using Aua2505_EF_Model_First.Controllers;
using Aua2505_EF_Model_First.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aua2505_EF_Model_First.Views.Cadastros
{
    public partial class CadastroCategorias : System.Web.UI.Page
    {

        Categoria categoria = new Categoria();
        CategoriasController contexto = new CategoriasController();
        protected void Page_Load(object sender, EventArgs e)
        {
            bool NewObject = Convert.ToBoolean(Session["NewObject"]);
            if (!NewObject)
            {
                if (!IsPostBack)
                {
                    var idLocalizar = Session["IdCategoria"];
                    CarregaOjbeto(Convert.ToInt32(idLocalizar));
                }
            }
            Session["NewObject"] = false;
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            categoria.Nome = txtNome.Text;
            categoria.Descricao = txtDescricao.Text;


            if (chkAtivo.Checked)
            {
                categoria.Ativo = true;
            }
            else
            {
                categoria.Ativo = false;
            }
            contexto.Adicionar(categoria);
            var ID = "Adicionado Com sucesso!!";
            ClientScript.RegisterStartupScript(this.GetType(), "script", "alert('" + ID + "');", true);
            Limpar();

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpar();
        }

        protected void CarregaOjbeto(int id)
        {
            categoria = contexto.LocarlizarPorID(id);
            txtNome.Text = categoria.Nome;
            txtDescricao.Text = categoria.Descricao;
            chkAtivo.Checked = categoria.Ativo;

        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            categoria.Nome = txtNome.Text;
            categoria.Descricao = txtDescricao.Text;
            categoria.Ativo = chkAtivo.Checked;
            int id = Convert.ToInt32(Session["IdCategoria"]);
            categoria.Id = id;

            contexto.Editar(categoria);

            var ID = "Alterado Com sucesso!!";
            ClientScript.RegisterStartupScript(this.GetType(), "script", "alert('" + ID + "');", true);
            Response.Redirect("~/Views/Categorias/Lista.aspx"); 

        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            categoria.Nome = txtNome.Text;
            categoria.Descricao = txtDescricao.Text;
            categoria.Ativo = chkAtivo.Checked;
            int id = Convert.ToInt32(Session["IdCategoria"]);
            categoria.Id = id;
            contexto.Excluir(categoria);
            var ID = "Excluido Com sucesso!!";
            ClientScript.RegisterStartupScript(this.GetType(), "script", "alert('" + ID + "');", true);
            Response.Redirect("~/Views/Categorias/Lista.aspx");
        }

        protected void Limpar()
        {
            txtDescricao.Text = "";
            txtNome.Text = "";
            chkAtivo.Checked = false;
        }
    }
}