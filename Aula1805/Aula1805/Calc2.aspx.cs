using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aula1805
{
    public partial class Calc2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            //Session.Remove("controle1");
            //Session.Remove("controle2");
            if (!IsPostBack)
            {
                if(Session["controle1"] != null && Session["controle2"] != null)
                {
                    double valor1 = Convert.ToDouble(Session["controle1"]);
                    double valor2 = Convert.ToDouble(Session["controle2"]);
                     Soma(valor1, valor2);
                }
                else
                {                    

                    Response.Redirect("~/Calc1.aspx");
                }
            }
            
        }

        public void Soma(double val1, double val2)
        {
             
            txtValor1soma2.Text = Convert.ToString(Session["Controle1"]);             
            txtValor2soma2.Text = Convert.ToString(Session["controle2"]);
            //int valor1 = Convert.ToInt32(txtValor1soma2.Text);
            //int valor2 = Convert.ToInt32(txtValor2soma2.Text);      
            double valor1 = val1;
            double valor2 = val2;
            double resul = valor1 + valor2;
            txtResultadoSoma.Text = resul.ToString();


            txtValor1subtrai2.Text = Convert.ToString(Session["Controle1"]);
            txtValor2subtrai2.Text = Convert.ToString(Session["controle2"]);
            int valor3 = Convert.ToInt32(txtValor1subtrai2.Text);
            int valor4 = Convert.ToInt32(txtValor2subtrai2.Text);

            double resul2 = val1 - val2;
            txtResultadoSubtrai.Text = resul2.ToString();

            txtValor1mult2.Text = Convert.ToString(Session["Controle1"]);
            txtValor2mult2.Text = Convert.ToString(Session["controle2"]);
            int valor5 = Convert.ToInt32(txtValor1mult2.Text);
            int valor6 = Convert.ToInt32(txtValor2mult2.Text);

            double resul3 = val1 * val2;
            txtResultadoMultiplica.Text = resul3.ToString();

            txtValor1div2.Text = Convert.ToString(Session["Controle1"]);
            txtValor2div2.Text = Convert.ToString(Session["controle2"]);
            int valor7 = Convert.ToInt32(txtValor1div2.Text);
            int valor8 = Convert.ToInt32(txtValor2div2.Text);

            double resul4 = val1 / val2;
            txtResultadoDivisao.Text = resul4.ToString();
        }
    }
}