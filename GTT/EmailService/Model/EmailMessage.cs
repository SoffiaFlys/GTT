using System.Net.Mail;

namespace EmailService.Model
{
    public class EmailMessage
    {
        public string Subject { get; set; }
        public string Message { get; set; }
        public bool IsHtml { get; set; }
        public MailAddress FromAdress { get; set; }
        public MailAddress ToAdress { get; set; }
    }
}
