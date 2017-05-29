using GTT.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace GTT.Models
{
    public class TourView: Item_View
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal? PriceUSD { get; set; }
        public decimal? PriceEUR { get; set; }
        public decimal? PriceUAH { get; set; }

        public string Description { get; set; }
        public virtual ICollection<string> Days_Program { get; set; }
        public virtual string FoodType { get; set; }
        public virtual ICollection<string> Pictures { get; set; }
        public virtual ICollection<string> Route { get; set; }
        public virtual ICollection<DateTime?> TourDate { get; set; }
        public decimal CurrencyConvert(decimal amount, string fromCurrency, string toCurrency)
        {
            // decimal currency = 0;
            decimal exchangeRate = 0;
            // string convertedAmount = "0";
            try
            {
                WebClient web = new WebClient();
                const string urlPattern = "http://finance.yahoo.com/d/quotes.csv?s={0}{1}=X&f=l1";
                string url = String.Format(urlPattern, fromCurrency, toCurrency);
                // Get response as string
                string response = new WebClient().DownloadString(url);
                // Convert string to number
                exchangeRate = decimal.Parse(response, System.Globalization.CultureInfo.InvariantCulture);


            }
            catch (Exception ex)
            {
                exchangeRate = 0;
            }

           // ViewBag.convertedAmount = exchangeRate;
            return (exchangeRate);
        }
        public TourView( Tour tour)
        {
            this.ID = tour.ID;
            this.Name = tour.Name;
            this.PriceUSD = tour.PriceUSD;
            this.PriceEUR =(decimal)this.PriceUSD* CurrencyConvert((decimal)this.PriceUSD, "USD", "EUR");
            this.PriceUAH = (decimal)this.PriceUSD * CurrencyConvert((decimal)this.PriceUSD, "USD", "UAH");
            this.Days_Program = new List<string>();
            Day_Connection current_day = tour.Day_Connection1;
            while(true)
            {
                Days_Program.Add(current_day.Day.Description);
                current_day = tour.Day_Connection.FirstOrDefault(c => c.DayID == current_day.NextDayID);
                if (current_day == null)
                    break;
            }


            this.Route = new List<string>();
            Route_Connection current_route_connection = tour.Route_Connection1;
            while (current_route_connection.NextConnectionID != tour.StartConnectionID)
            {
                Route.Add(current_route_connection.TourLocation.City);
                current_route_connection = tour.Route_Connection.FirstOrDefault(r => r.ID == current_route_connection.NextConnectionID);
                if (current_route_connection == null)
                    break;
            }

            this.Description = tour.Description;
            this.FoodType = tour.FoodType.Description;

            this.Pictures = new List<string>();
            foreach (var p in tour.Picture)
                Pictures.Add(p.PicturePath);

            this.TourDate = new List<DateTime?>( );
            foreach (var d in tour.TourDate)
                this.TourDate.Add(d.StartDate);
        }
    }
}