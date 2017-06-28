using GTT.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GTT.Models
{
    public class BusView:Item_View
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
        public string Seats { get; set; }
        public virtual ICollection<string> BusEquipment { get; set; }
        public virtual ICollection<string> PictureBus { get; set; }

        public BusView(Bus bus)
        {
            this.ID = bus.ID;
            this.Name = bus.Name;
            this.Brand = bus.Brand;
            this.Color = bus.Color;
            this.Seats = bus.Seats;
            this.BusEquipment = new List<string>(  );
            foreach ( var e in bus.BusEquipment )
                this.BusEquipment.Add( e.Equipment.Description );
            this.PictureBus = new List<string>( );
            foreach ( var p in bus.PictureBus )
                this.PictureBus.Add( p.PicturePath );
        }
    }
}