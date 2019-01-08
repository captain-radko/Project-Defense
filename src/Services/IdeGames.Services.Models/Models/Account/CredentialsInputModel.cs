using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using IdeGames.Data.Models;
using IdeGames.Services.Mapping;

namespace IdeGames.Services.Models.Models.Account
{
    public class CredentialsInputModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Ordered On")]
        public DateTime OrderedOn { get; set; }
    }
}
