using GTT.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GTT.Entities;
using GTT.Views.Models;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace GTT.Controllers
{
    public enum Type
    { Tour, Bus }
    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            return View();
            
        }

        public ActionResult Category( Type type )
        {
            
            switch ( type )
            {
                case Type.Tour:
                    var ViewedList = new List<TourView>();
                    using ( var context = new TourContext() )
                    {
                        foreach ( Tour tour in context.Tour )
                            ViewedList.Add( new TourView( tour ) );
                    }
                    return View( "Tours", ViewedList.AsEnumerable<TourView>() );
                case Type.Bus:
                    List<BusView> BusList = new List<BusView>();
                    using ( var context = new BusContext() )
                    {
                        foreach ( Bus bus in context.Bus )
                            BusList.Add( new BusView( bus ) );
                    }
                    return View( "Buses", BusList );

            }
            return View();
        }
        public ActionResult Tour(int Id)
        {
            using (TourContext context = new TourContext())
            {
                var toutview = new TourView(context.Tour.FirstOrDefault(t => t.ID == Id));
                return View("Tour", toutview);
            }
        }


        
        [HttpPost]
        public ViewResult Index(Message message)
        {
            var fromAddress = new MailAddress( "gtt.callback@gmail.com" );
            var toAddress = new MailAddress( "kokhan.oksana@gmail.com" );
            const string fromPassword = "!QAZ2ws3e4";
            var subject = message.Subject;
            var body = String.Format("Message from: {0} \n {1}",message.From, message.Text);

            using ( var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential( fromAddress.Address, fromPassword )
            } )
            {
                using ( var msg = new MailMessage( fromAddress, toAddress )
                {
                    Subject = subject,
                    Body = body
                } )
                {
                    smtp.Send( msg );
                }
                return View( "Index" );
            }
        }

    }
}