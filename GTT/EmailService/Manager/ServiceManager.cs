using EmailService.Model;
using System;
using System.Threading.Tasks;
using MailMessage = System.Net.Mail.MailMessage;
using SmtpClient = System.Net.Mail.SmtpClient;

namespace EmailService.Manager
{
    public sealed class ServiceManager 
    {
        #region private props

        private SmtpClient _client;

        private string _fromAdress;
        #endregion

        #region public

        public ServiceManager(SmtpClient client, string fromAdress)
        {
            _client = client;
            _fromAdress = fromAdress;
        }

        public async Task SendMessage(EmailMessage message) 
        {
            await Task.Run(() =>
            {
                message.FromAdress = new System.Net.Mail.MailAddress(_fromAdress);
                MailMessage messageToSend = ConvertMessage(message);
                _client.Send(messageToSend);
            }
            );
        }

        #endregion

        #region private

        private MailMessage ConvertMessage(EmailMessage message)
        {
            MailMessage result = new MailMessage(message.FromAdress,message.ToAdress)
            {
                Subject = String.IsNullOrEmpty(message.Subject) ? String.Empty : message.Subject,
                IsBodyHtml = message.IsHtml,
                Body = message.Message
            };
            return result;
        }

        private bool IsMessageValid(EmailMessage message)
        {
            return !String.IsNullOrEmpty(message.FromAdress.Address) &&
                   !String.IsNullOrEmpty(message.ToAdress.Address) &&
                   !String.IsNullOrEmpty(message.Message) &&
                   !String.IsNullOrEmpty(message.Message);
        }

        #endregion
    }
}
