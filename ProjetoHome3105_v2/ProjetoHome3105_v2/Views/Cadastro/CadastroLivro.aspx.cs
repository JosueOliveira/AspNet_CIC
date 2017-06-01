using ProjetoHome3105_v2.Controller;
using ProjetoHome3105_v2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoHome3105_v2.Views.Cadastro
{
    public partial class CadastroLivro : System.Web.UI.Page
    {
        LivroController contexto = new LivroController();
        Livros livro = new Livros();
        protected void Page_Load(object sender, EventArgs e)
        {
            bool IsNewObject = Convert.ToBoolean(Session["IsNewObject"]);
            if (!IsNewObject)
            {
                if (!IsPostBack)
                {
                    var idLocalizar = Session["IdLocalizar"];
                    CarregaObjecto(Convert.ToInt32(idLocalizar));
                }                
            }
            Session["IsNewObject"] = false;
           
        }

        protected void btnAdicionar_Click(object sender, EventArgs e)
        {
            livro.Nome = txtNome.Text;
            livro.Autor = txtAutor.Text;
            livro.Descricao = txtDescricao.Text;
            contexto.Adicionarlivro(livro);

            Response.Redirect("~/Views/index.aspx");

            var ID = "Adicionado Com sucesso!!";
            ClientScript.RegisterStartupScript(this.GetType(), "script", "alert('" + ID + "');", true);
            Limpar();
        }

        
        public void CarregaObjecto(int id)
        {
            livro = contexto.LocalizarLivroPorId(id);
            txtNome.Text = livro.Nome;
            txtAutor.Text = livro.Autor;
            txtDescricao.Text = livro.Descricao;
        }

        private void Limpar()
        {
            txtAutor.Text = "";
            txtNome.Text = "";
            txtDescricao.Text = "";
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            livro.Nome = txtNome.Text;
            livro.Autor = txtAutor.Text;
            livro.Descricao = txtDescricao.Text;
            livro.Id = Convert.ToInt32(Session["IdLocalizar"]);
            contexto.Editar(livro);

            var ID = "Alterado Com sucesso!!";
            ClientScript.RegisterStartupScript(this.GetType(), "script", "alert('" + ID + "');", true);
            Response.Redirect("~/Views/index.aspx");
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            livro.Nome = txtNome.Text;
            livro.Descricao = txtDescricao.Text;
            livro.Autor = txtAutor.Text;
            int id  = Convert.ToInt32(Session["IdLocalizar"]);
            livro.Id = id;
            contexto.Excluir(livro);
            var ID = "Excluido Com sucesso!!";
            ClientScript.RegisterStartupScript(this.GetType(), "script", "alert('" + ID + "');", true);
            Response.Redirect("~/Views/Index.aspx");
        }
        
    }
}