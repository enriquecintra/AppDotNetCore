using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OPPI.Servico.Email
{
    public class EmailServico : IEmailServico
    {
        public SendGridEmailSenderOptions Options { get; set; }

        public EmailServico(IOptions<SendGridEmailSenderOptions> options)
        {
            this.Options = options.Value;
        }

        private async Task<Response> Execute(
            string apiKey,
            string assunto,
            string mensagem,
            List<string> emails)
        {
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress(Options.RemetenteEmail, Options.RemetenteNome),
                Subject = assunto,
                PlainTextContent = mensagem,
                HtmlContent = mensagem
            };

            emails.ForEach((email) =>
            {
                msg.AddTo(new EmailAddress(email));
            });

            // disable tracking settings
            // ref.: https://sendgrid.com/docs/User_Guide/Settings/tracking.html
            msg.SetClickTracking(false, false);
            msg.SetOpenTracking(false);
            msg.SetGoogleAnalytics(false);
            msg.SetSubscriptionTracking(false);

            return await client.SendEmailAsync(msg).ConfigureAwait(false);
        }

        public async Task EnviarEmailAsync(string email, string assunto, string mensagem)
        {
            await Execute(Options.ApiKey, assunto, mensagem, new List<string>() { email });
        }
        public async Task EnviarEmailAsync(List<string> email, string assunto, string mensagem)
        {
            await Execute(Options.ApiKey, assunto, mensagem, email);
        }
    }
}



    //private string GetHtml(string url)
    //{
    //    using (HttpClient client = new HttpClient())
    //    {
    //        using (HttpResponseMessage response = client.GetAsync(url).Result)
    //        {
    //            using (HttpContent content = response.Content)
    //            {
    //                return content.ReadAsStringAsync().Result;
    //            }
    //        }
    //    }
    //}


    
