using System.ComponentModel.DataAnnotations;

namespace CarAuction2.Models.Car
{
    public class Mark
    {
        [Key]
        public int MarkId { get; set; }

        [Required]
        [MaxLength(64)]
        public string Name { get; set; }
    }
}