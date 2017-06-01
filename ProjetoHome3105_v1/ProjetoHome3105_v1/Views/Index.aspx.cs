using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoHome3105_v1.Views
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnNewBook_Click(object sender, EventArgs e)
        {
            Session["IsNewObject"] = true;
            Response.Redirect("~/Views/Cadastro/CadastroDeLivros.aspx");
        }
    }
}