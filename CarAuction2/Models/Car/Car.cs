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
        
        [ForeignKey("SellerId")]
        public virtual User.User Seller { get; set; }
        
        [Required]
        public int SellerId { get; set; }
        
        [Display(Name = "Production Year")]
        [Required]
        public int ProductionYear { get; set; }
        
        [Required]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = true)]
        public int Mileage { get; set; }

        [Required]
        public String Description { get; set; }

        [Required]
        [Display(Name = "Desired Price")]
        [DisplayFormat(DataFormatString = "{0:C0}", ApplyFormatInEditMode = true)]
        public int DesiredPrice { get; set; }

        [Required] 
        public CarStatus CarStatus { get; set; } = CarStatus.Sale;

        public List<CarPicture> CarPictures { get; set; }
    }
}