using GTT.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GTT.Controllers
{
    public enum Type
    { Tour, Bus }
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
            
        }
        
        public ActionResult Category(Type type )
        {
            switch ( type)
            {
                case Type.Tour:
                    using ( var context = new TourContext() )
                    { RedirectToAction( "", context ); }
                    break;
                case Type.Bus:
                    using ( var context = new BusContext() )
                    { RedirectToAction( "", context ); }
                    break;
            }
            return View();
    }
}