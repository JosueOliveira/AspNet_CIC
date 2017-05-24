using Aula2305BD.Models;
using Aula2305BD.View.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aula2305BD.View.Categoria
{
    public partial class Lista : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        { 
            gvCategorias.DataSource =
                contexto.Produto;

            gvCategorias.DataBind();
        }
    }
}