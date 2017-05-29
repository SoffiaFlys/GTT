using EmailService.Manager;
using EmailService.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace GTT.Controllers
{
    public class EmailController : Controller
    {
        private ServiceManager _email = new EmailService.EmailService(
    adress: ConfigurationManager.AppSettings [ "EmailAdress" ],
    password: ConfigurationManager.AppSettings [ "EmailPassword" ] ).ServiceManager;
        // GET: Email
        [HttpGet]
        public ActionResult Index()
        {
            return View("Home", "Index");
        }
        

        [HttpPost]
        
        public async Task<ActionResult> Index( IncomeMessageEmailWithTempalte model )
        {
            try
            {
                await SendMessage( model.SendTo, model.Template );
                return Json( "Message sent" );
            }
            catch ( Exception ex )
            {
                return Json( "Something get wrong, message was not send. " + ex.Message );
            }
        }
        #region private 
        private async Task SendMessage( string sendTo, Template template, bool isHtml = false )
        {
            await _email.SendMessage( new EmailMessage
            {
                ToAdress = new System.Net.Mail.MailAddress( sendTo ),
                IsHtml = isHtml,
                Message = template.Message,
                Subject = template.Subject
            } );
        }
        #endregion
    }
    public class IncomeTemplateModel
    {
        public string Name { get; set; }
        public Template Template { get; set; }
    }
    public class Template
    { 
        public string Subject { get; set; }
       
        public string Message { get; set; }
    }
 

    public class IncomeMessageEmailWithTempalte
    {
        public string SendTo { get; set; }
        public Template Template { get; set; }
    }
}               