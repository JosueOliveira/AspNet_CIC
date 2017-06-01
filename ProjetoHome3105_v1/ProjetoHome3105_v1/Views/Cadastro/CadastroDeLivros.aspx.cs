using ProjetoHome3105_v1.Controller;
using ProjetoHome3105_v1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoHome3105_v1.Views.Cadastro
{
    public partial class CadastroDeLivros : System.Web.UI.Page
    {
        CadastroController contexto = new CadastroController();
        Livros livro = new Livros();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            livro.Nome = txtNome.Text;
            livro.Descricao = txtDescricao.Text;
            livro.Codigo = txtCodigo.Text;
            livro.Autor = txtAutor.Text;
            contexto.AdicionarLivro(livro);
        }
    }
}