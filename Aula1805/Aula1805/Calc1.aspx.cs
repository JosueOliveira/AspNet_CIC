using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aula1805
{
    public partial class Calc1 : System.Web.UI.Page
    {
        public string nomeUsuario
        {
            get
            {
                return ViewState["nomeUsuario"].ToString();
            }
            set
            {
                ViewState["nomeUsuario"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {               

                nomeUsuario = "godofredo";
            }
        }

        protected void btnSoma_Click(object sender, EventArgs e)
        {
            txtResultado.Text = "";
            int valor1 = Convert.ToInt32(txtValor1.Text);
            Session["controle1"] = valor1.ToString();
            int valor2 = Convert.ToInt32(txtValor2.Text);
            Session["controle2"] = valor2.ToString();
            int resultado = valor1 + valor2;
           
                txtResultado.Text = resultado.ToString();
            lblNome.Text = ViewState["nomeUsuario"].ToString();
                        
        }

        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            txtResultado.Text = "";
            txtValor1.Text = "";
            txtValor2.Text = "";
        }

        protected void btnIgual_Click(object sender, EventArgs e)
        {
            int valor1 = Convert.ToInt32(txtValor1.Text);
            Session["controle1"] = valor1.ToString();
            int valor2 = Convert.ToInt32(txtValor2.Text);
            Session["controle2"] = valor2.ToString();
            Response.Redirect("~/Calc2.aspx");
        }
    }
}