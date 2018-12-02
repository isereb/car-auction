using System.ComponentModel.DataAnnotations;

namespace CarAuction2.Models.Car
{
    public class CarPicture
    {
        [Key]
        public int PictureId { get; set; }

        [MaxLength(64)]
        public string Description { get; set; }
    }
}