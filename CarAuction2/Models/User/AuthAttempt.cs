using System;
using System.ComponentModel.DataAnnotations;

namespace CarAuction2.Models.User
{
    public class AuthAttempt
    {
        public int AuthAttemptId;
        
        [Required]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
        
        [Required]
        [MinLength(6)]
        [MaxLength(64)]
        [Display(Name = "Password")] 
        public string Password { get; set; }

        private readonly DateTime _attemptedAt = new DateTime();
    }
}