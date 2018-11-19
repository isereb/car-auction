using System;

namespace CarAuction2.Models.Car
{
    public class Car
    {
        public int CarId { get; set; }

        public string Mark { get; set; }
        public string Model { get; set; }
        public DateTime ProductionYear { get; set; }
        public string PathToPicture { get; set; }
    }
}