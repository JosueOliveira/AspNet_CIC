using ProjetoHome2405DB.View.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoHome2405DB.View.Categoria
{
    public partial class Lista : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            gvCategorias.DataSource = contexto.Categoria.ToList();

            gvCategorias.DataBind();

        }
    }
}