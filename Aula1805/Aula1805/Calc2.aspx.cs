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
            Soma();
            Session.Remove("controle1");
            Session.Remove("controle2");
            
        }

        public void Soma()
        {
             
            txtValor1soma2.Text = Convert.ToString(Session["Controle1"]);             
            txtValor2soma2.Text = Convert.ToString(Session["controle2"]);
            int valor1 = Convert.ToInt32(txtValor1soma2.Text);
            int valor2 = Convert.ToInt32(txtValor2soma2.Text);      
            
            int resul = valor1 + valor2;
            txtResultadoSoma.Text = resul.ToString();


            txtValor1subtrai2.Text = Convert.ToString(Session["Controle1"]);
            txtValor2subtrai2.Text = Convert.ToString(Session["controle2"]);
            int valor3 = Convert.ToInt32(txtValor1subtrai2.Text);
            int valor4 = Convert.ToInt32(txtValor2subtrai2.Text);

            int resul2 = valor1 - valor2;
            txtResultadoSubtrai.Text = resul2.ToString();

            txtValor1mult2.Text = Convert.ToString(Session["Controle1"]);
            txtValor2mult2.Text = Convert.ToString(Session["controle2"]);
            int valor5 = Convert.ToInt32(txtValor1mult2.Text);
            int valor6 = Convert.ToInt32(txtValor2mult2.Text);

            int resul3 = valor1 * valor2;
            txtResultadoMultiplica.Text = resul3.ToString();

            txtValor1div2.Text = Convert.ToString(Session["Controle1"]);
            txtValor2div2.Text = Convert.ToString(Session["controle2"]);
            int valor7 = Convert.ToInt32(txtValor1div2.Text);
            int valor8 = Convert.ToInt32(txtValor2div2.Text);

            int resul4 = valor1 / valor2;
            txtResultadoDivisao.Text = resul4.ToString();
        }
    }
}