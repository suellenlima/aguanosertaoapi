using System.Net.Mail;
using System.Net;
using System.Reflection;
using AguaNoSertao.Domain.Interfaces.Integration;

namespace AguaNoSertao.Infra.Integration
{
    public class EmailIntegration : IEmailIntegration
    {
        public void EnviarEmailRecuperarSenha(string nome, string guidRecuperação, string email)
        {
            try
            {
                //TODO AGUARDANDO HTML PARA ADICIONAR NO E-MAIL. O ATUAL É PROVISORIO.
                string location = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Htmls", "EmailRecuperacaoSenha.html");

                using var reader = new StreamReader(location);

                string body = reader.ReadToEnd();

                body = body.Replace("##NOME##", nome);
                body = body.Replace("##GUID##", guidRecuperação);

                MailAddress remetente = new MailAddress($"Agua no Sertão <aguanosertaodevteste@outlook.com.br>", "Agua no Sertão");

                using MailMessage message = new MailMessage();
                message.Subject = "Agua no Sertão - Recuperação de Senha";
                message.IsBodyHtml = true;
                message.Body = body;
                message.From = remetente;
                message.To.Add(email);

                using SmtpClient sc = new SmtpClient("smtp-mail.outlook.com", 587);
                sc.UseDefaultCredentials = false;
                NetworkCredential cre = new NetworkCredential("aguanosertaodevteste@outlook.com.br", "hH7owXlzR7*5");
                sc.Credentials = cre;
                sc.EnableSsl = true;
                sc.Send(message);
            }
            catch (Exception e)
            {
                throw new ArgumentException("Não foi possível, enviar o e-mail de recuperação de senha.", e.Message);
            }
        }
    }
}
