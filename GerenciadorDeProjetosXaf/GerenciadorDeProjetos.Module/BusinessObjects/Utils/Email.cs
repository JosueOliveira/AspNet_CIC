using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeProjetos.Module.BusinessObjects.ClassUtils
{
    public class Email
    {
        public static void EnviarEmail(string ContatoTo, string Msg, string Titulo)
        {

            if (Parametros.Configuracoes.AlertaEmail)
            {
                MailMessage mensagemEmail = new System.Net.Mail.MailMessage();

                

                mensagemEmail.To.Add(new MailAddress(ContatoTo));
                string contatoFrom = Parametros.Configuracoes.EnviadoDe;
                MailAddress mailAdress = new MailAddress(contatoFrom);
                mensagemEmail.From = mailAdress;                
                mensagemEmail.Subject = Titulo;
                mensagemEmail.Body = Msg;

                // Define Servidor de envio
                System.Net.Mail.SmtpClient smtpClient = new System.Net.Mail.SmtpClient();
                smtpClient.Host = Parametros.Configuracoes.Host;
                smtpClient.Port = Convert.ToInt32(Parametros.Configuracoes.Porta);
                //Desabilita Certificados de Email
                smtpClient.EnableSsl = false;
                smtpClient.Credentials = new System.Net.NetworkCredential(Parametros.Configuracoes.UserName, Parametros.Configuracoes.Senha);
                smtpClient.Send(mensagemEmail);
            }

        }
    }
}
