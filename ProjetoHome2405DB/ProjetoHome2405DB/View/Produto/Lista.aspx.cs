using ProjetoHome2405DB.View.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoHome2405DB.View.Produto
{
    public partial class Lista : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var produtoCadastrado = contexto.Produto;

            gvProdutos.DataSource = produtoCadastrado.ToList();
            gvProdutos.DataBind();
        }
    }
}