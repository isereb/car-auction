using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarAuction2.Models.User
{
    public class User
    {
        public int UserId { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "First name")]
        [MinLength(2, ErrorMessage = "{0} should be at least {1} characters long")]
        [MaxLength(64, ErrorMessage = "{0} should be no more than {1} characters long")]
        public string FirstName { get; set; }
        
        [Required]
        [Display(Name = "Last name")]
        [MinLength(2, ErrorMessage = "{0} should be at least {1} characters long")]
        [MaxLength(64, ErrorMessage = "{0} should be no more than {1} characters long")]
        public string LastName { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "{0} should be at least {1} characters long")]
        [MaxLength(64, ErrorMessage = "{0} should be no more than {1} characters long")]
        public string Password { get; set; }
        private DateTime CreatedAt { get; set; }

        [ForeignKey("UserRoleId")]
        public virtual UserRole UserRole { get; set; }

        public int UserRoleId { get; set; } = 1;

        public bool IsInRole(int i)
        {
            return UserRoleId == i;
        }

        public bool IsInRole(string name)
        {
            return UserRole.RoleName.Equals(name);
        }

    }
}