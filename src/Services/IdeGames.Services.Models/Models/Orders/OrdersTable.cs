using System;
using System.ComponentModel.DataAnnotations;
using IdeGames.Data.Common;
using IdeGames.Data.Models;
using IdeGames.Services.Mapping;

namespace IdeGames.Services.Models.Models.Orders
{
    public class OrdersTable : BaseModel<string>, IMapFrom<Order>
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Ordered On")] public DateTime OrderedOn { get; set; }
    }
}