using System;
using System.ComponentModel.DataAnnotations;

namespace CarAuction2.Models.Car
{
    public class Car
    {

        public int CarId { get; set; }

        [Required]
        [MaxLength(64)]
        public string Mark { get; set; }
        
        [Required]
        [MaxLength(64)]
        public string Model { get; set; }
        
        [Required]
        public int ProductionYear { get; set; }

        public CarPicture Picture { get; set; }

        [Required] public CarStatus CarStatus { get; set; } = CarStatus.OnSale;
    }
}