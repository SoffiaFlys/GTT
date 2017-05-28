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

        public ActionResult Category( Type type )
        {
            List<Item_View> ViewedList = new List<Item_View>();
            switch ( type )
            {
                case Type.Tour:
                    using ( var context = new TourContext() )
                    {
                        foreach ( Tour tour in context.Tour )
                            ViewedList.Add( new TourView( tour ) );
                    }
                    return View( "Tours", ViewedList );
                case Type.Bus:
                    using ( var context = new BusContext() )
                    {
                        foreach ( Bus bus in context.Bus )
                            ViewedList.Add( new BusView( bus ) );
                    }
                    return View( "Buses", ViewedList );

            }
            return View();
        }
    }
}