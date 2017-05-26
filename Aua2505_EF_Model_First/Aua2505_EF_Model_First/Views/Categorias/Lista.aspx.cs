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

            #region Cria Comunicação com A base de dados
            DatabaseContainer contexto = new DatabaseContainer(); 
            #endregion

            var caregorias = contexto.Categorias;

            gvCategorias.DataSource = caregorias.ToList();
            gvCategorias.DataBind();
        }
    }
}