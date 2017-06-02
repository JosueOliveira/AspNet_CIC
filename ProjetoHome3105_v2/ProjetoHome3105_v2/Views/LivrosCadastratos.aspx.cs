using ProjetoHome3105_v2.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoHome3105_v2.Views
{
    public partial class LivrosCadastratos : System.Web.UI.Page
    {
        LivroController contexto = new LivroController();
        protected void Page_Load(object sender, EventArgs e)
        {
            grdLivrosCadastrados.DataSource = contexto.Listar();
            grdLivrosCadastrados.DataBind();
        }
    }
}