using System;
using System.ComponentModel.DataAnnotations;
using IdeGames.Data.Models;
using IdeGames.Services.Mapping;

namespace IdeGames.Services.Models.Models.Account
{
    public class CredentialsInputModel : IMapTo<Order>
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^[A-Za-z0-9]+[_\-' A-Za-z0-9]+$", 
            ErrorMessage = "Please enter a valid address")]
        public string Address { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Ordered On")]
        public DateTime OrderedOn { get; set; }
    }
}
