using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using IdeGames.Data.Common;

namespace IdeGames.Data.Models
{
    public class Order : BaseModel<int>
    {
        [Required] 
        public string Name { get; set; }

        [EmailAddress]
        [Required] 
        public string Email { get; set; }

        [RegularExpression(@"^[A-Za-z0-9]+[_\-' A-Za-z0-9]+$", 
            ErrorMessage = "Please enter a valid address")]
        [Required] 
        public string Address { get; set; }

        [Phone]
        [Required] 
        public string PhoneNumber { get; set; }
        
        [Required] 
        public DateTime OrderOn { get; set; }
    }
}