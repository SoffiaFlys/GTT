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
        public virtual ICollection<BusEquipment> BusEquipment { get; set; }
        public virtual ICollection<PictureBus> PictureBus { get; set; }

        public BusView(Bus bus)
        {
            this.ID = bus.ID;
            this.Name = bus.Name;
            this.Brand = bus.Brand;
            this.Color = bus.Color;
            this.Seats = bus.Seats;
            this.BusEquipment = new List<BusEquipment>( bus.BusEquipment );
            this.PictureBus = new List<PictureBus>( bus.PictureBus );
        }
    }
}