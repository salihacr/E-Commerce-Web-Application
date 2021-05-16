using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace E_Commerce_App.Core.Shared.Helper
{
    public interface IEmailSender
    {
        // smtp => gmail,hotmail

        // api => sendgrid
        Task SendEmailAsync(string email, string subject, string htmlMessage);
    }
    public class SmtpEmailSender : IEmailSender
    {

        private readonly string _host;
        private readonly int _port;
        private readonly bool _enableSSL;
        private readonly string _username;
        private readonly string _password;

        public SmtpEmailSender(string host, int port, bool enableSSL, string username, string password)
        {
            _host = host;
            _port = port;
            _enableSSL = enableSSL;
            _username = username;
            _password = password;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var client = new SmtpClient(_host, _port)
            {
                Credentials = new NetworkCredential(_username, _password),
                EnableSsl = _enableSSL
            };

            await client.SendMailAsync(
                new MailMessage(_username, email, subject, htmlMessage)
                {
                    IsBodyHtml = true
                }
            );
        }
    }
}
