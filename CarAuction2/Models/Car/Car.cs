using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarAuction2.Models.Car
{
    public class Car
    {

        public int CarId { get; set; }

        [ForeignKey("ModelId")]
        public virtual Model Model { get; set; }

        [Required(ErrorMessage = "Model of the car should be selected")]
        public int ModelId { get; set; }
        
        [Required]
        public int ProductionYear { get; set; }

        public CarPicture Picture { get; set; }

        [Required] 
        public CarStatus CarStatus { get; set; } = CarStatus.Sale;
        
        public List<CarPicture> CarPictures { get; set; } 
    }
}