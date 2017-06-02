using ProjetoHome3105_v2.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoHome3105_v2.Views
{
    public partial class Index : System.Web.UI.Page
    {
        LivroController contexto = new LivroController();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            grdLivros.DataSource = contexto.Listar();
            grdLivros.DataBind();
        }

        protected void btnNewBook_Click(object sender, EventArgs e)
        {
            Session["IsNewObject"] = true;
            Response.Redirect("~/Views/Cadastro/CadastroLivro.aspx");
        }

        protected void btnLocalizar_Click(object sender, EventArgs e)
        {
            if(txtId.Text != "")
            {
                Session["IdLocalizar"] = txtId.Text;
                Response.Redirect("~/Views/Cadastro/CadastroLivro.aspx");
            }else
            {
                var ID = "Informe id Da Categoria que Dejesa Localizar!!";
                ClientScript.RegisterStartupScript(this.GetType(), "script", "alert('" + ID + "');", true);
            }
        }

        protected void grdLivros_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int linha = Convert.ToInt32(e.CommandArgument);

            var idObject =  Convert.ToInt32(grdLivros.Rows[linha].Cells[2].Text);

            string command = e.CommandName;
            Session["IdLocalizar"] = idObject;
            if (command == "Excluir")
            {
                Session["Comando"] = true;
                Response.Redirect("~/Views/Cadastro/CadastroLivro.aspx");                 
            }
            else
            {
                if(command == "Editar")
                {
                    Session["Comando"] = false;
                    Response.Redirect("~/Views/Cadastro/CadastroLivro.aspx");
                }
            }
        }

        protected void btnListar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/LivrosCadastratos");
        }
    }
}