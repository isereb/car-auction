using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.UI.WebControls;

namespace CarAuction2.Models.User
{
    public class User
    {
        public int UserId { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "Password should be at least 6 characters long")]
        [MaxLength(64, ErrorMessage = "Password should be no more than 64 characters long")]
        public string Password { get; set; }
        private DateTime CreatedAt { get; set; }

    }
}