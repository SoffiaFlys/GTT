using GTT.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GTT.Entities;

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
            
            switch ( type )
            {
                case Type.Tour:
                    List<TourView> ViewedList = new List<TourView>();
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
    }
}