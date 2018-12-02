using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarAuction2.Models.Car
{
    public class Model
    {
        [Key]
        public int ModelId { get; set; }

        [ForeignKey("MarkId")]
        public virtual Model Mark { get; set; }

        [Required(ErrorMessage = "Mark of the model should be selected")]
        public int MarkId { get; set; }
        
        [Required]
        [MaxLength(64)]
        public string Name { get; set; }
    }
}