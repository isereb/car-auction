using System.ComponentModel.DataAnnotations;

namespace CarAuction2.Models.User
{
    public class UserRole
    {
        [Key]
        public int UserRoleId { get; set; }
        public string RoleName { get; set; }
        
    }
}