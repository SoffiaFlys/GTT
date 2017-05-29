using EmailService.Manager;
using System.Net;
using System.Configuration;
using System.Net.Mail;

namespace EmailService
{
    public class EmailService
    {
        private string _adress;
        private string _password;
        public EmailService(string adress, string password)
        {
            _adress = adress;
            _password = password;
        }
        public ServiceManager ServiceManager
        {
            get
            {
                return new ServiceManager(new System.Net.Mail.SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new NetworkCredential(_adress, _password)
                }, _adress);
            }
        }
    }
}
