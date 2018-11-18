using System;
using System.ComponentModel.DataAnnotations;

namespace CarAuction2.Models.User
{
    public class Registration
    {
        public int RegistrationId;

        [Required]
        [EmailAddress]
        public string Email;

        [Required]
        [MinLength(6)]
        [MaxLength(64)]
        public string Password;

        private readonly DateTime _regAt = new DateTime(); 

    }
}