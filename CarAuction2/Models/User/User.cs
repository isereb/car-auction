using System;
using System.ComponentModel.DataAnnotations;

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
        [MinLength(6, ErrorMessage = "{0} should be at least {1} characters long")]
        [MaxLength(64, ErrorMessage = "{0} should be no more than {1} characters long")]
        public string FirstName;
        
        [Required]
        [Display(Name = "Last name")]
        [MinLength(6, ErrorMessage = "{0} should be at least {1} characters long")]
        [MaxLength(64, ErrorMessage = "{0} should be no more than {1} characters long")]
        public string LastName;

        [Required]
        [MinLength(6, ErrorMessage = "{0} should be at least {1} characters long")]
        [MaxLength(64, ErrorMessage = "{0} should be no more than {1} characters long")]
        public string Password { get; set; }
        private DateTime CreatedAt { get; set; }

    }
}