using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GTT.Models
{
    public class TourView: Item_View
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal? PriceUSD { get; set; }
        public int? StartConnectionID { get; set; }
        public string Description { get; set; }
        public string FoodType { get; set; }

        public virtual ICollection<Picture> Picture { get; set; }
        public virtual ICollection<Route_Connection> Route_Connection { get; set; }
        public virtual int Route_Start { get; set; }
        public virtual ICollection<TourDate> TourDate { get; set; }

        public TourView( Tour tour)
        {
            this.ID = tour.ID;
            this.Name = tour.Name;
            this.PriceUSD = tour.PriceUSD;
            this.StartConnectionID = tour.StartConnectionID;
            this.Description = tour.Description;
            this.FoodType = tour.FoodType;
            this.Route_Start = tour.Route_Connection1.ID;
            this.Picture = new List<Picture>( tour.Picture );
            this.Route_Connection = new List<Route_Connection>( tour.Route_Connection );
            this.TourDate = new List<TourDate>( tour.TourDate );
        }
    }
}