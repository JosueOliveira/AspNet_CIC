using Aua2505_EF_Model_First.Controllers;
using Aua2505_EF_Model_First.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aua2505_EF_Model_First.Views.Categorias
{
    public partial class Lista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CategoriasController ctrl = new CategoriasController();              

            gvCategorias.DataSource = ctrl.Listar();
            gvCategorias.DataBind();


           // var ID = "Categoria Carregada com sucesso!!";
            //ClientScript.RegisterStartupScript(this.GetType(), "script", "alert('" + ID + "');", true);
        }

        protected void btnAdicionar_Click(object sender, EventArgs e)
        {
            Session["NewObject"] = true;
            Response.Redirect("~/Views/Cadastros/CadastroCategorias.aspx");
        }
 

        protected void btnLocalizar_Click(object sender, EventArgs e)
        {
            if(txtId.Text != "")
            {
                Session["IdCategoria"] = txtId.Text;
                Response.Redirect("~/Views/Cadastros/CadastroCategorias.aspx");
            }

             var ID = "Informe id Da Categoria que Dejesa Localizar!!";
            ClientScript.RegisterStartupScript(this.GetType(), "script", "alert('" + ID + "');", true);
        
    }
    }
}