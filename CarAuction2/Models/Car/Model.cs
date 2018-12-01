using System.ComponentModel.DataAnnotations;

namespace CarAuction2.Models.Car
{
    public class Model
    {
        [Key]
        public int ModelId { get; set; }

        [Required]
        [MaxLength(64)]
        public string Name { get; set; }
    }
}