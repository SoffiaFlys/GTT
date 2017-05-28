using GTT.Entities;
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
        public int? ProgramFirstDayID { get; set; }
        public string Description { get; set; }
        public int? FoodTypeID { get; set; }
        public virtual ICollection<Day_Connection> Day_Connection { get; set; }
        public virtual Day_Connection Day_Connection1 { get; set; }
        public virtual FoodType FoodType { get; set; }
        public virtual ICollection<Picture> Picture { get; set; }
        public virtual ICollection<Route_Connection> Route_Connection { get; set; }
        public virtual Route_Connection Route_Connection1 { get; set; }
        public virtual ICollection<TourDate> TourDate { get; set; }

        public TourView( Tour tour)
        {
            this.ID = tour.ID;
            this.Name = tour.Name;
            this.PriceUSD = tour.PriceUSD;

            this.StartConnectionID = tour.StartConnectionID;
            this.Route_Connection = new List<Route_Connection>( tour.Route_Connection );
            this.Route_Connection1 = tour.Route_Connection1 ;

            this.ProgramFirstDayID = tour.ProgramFirstDayID;
            this.Day_Connection = new List<Day_Connection>( tour.Day_Connection );
            this.Day_Connection1 = tour.Day_Connection1;

            this.Description = tour.Description;
            this.FoodTypeID = tour.FoodTypeID;
            this.FoodType = tour.FoodType;

            this.Picture = new List<Picture>( tour.Picture );
            this.TourDate = new List<TourDate>( tour.TourDate );
        }
    }
}