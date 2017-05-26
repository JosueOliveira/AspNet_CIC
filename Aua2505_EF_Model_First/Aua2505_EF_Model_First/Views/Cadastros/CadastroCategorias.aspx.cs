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
        DatabaseContainer contexto = new DatabaseContainer();
        Categoria categoria = new Categoria();
        protected void Page_Load(object sender, EventArgs e)
        {
            
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
            contexto.Categorias.Add(categoria);            
            contexto.SaveChanges();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            txtDescricao.Text = "";
            txtNome.Text = "";
            chkAtivo.Checked = false;
        }
    }
}