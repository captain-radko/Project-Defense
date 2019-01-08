using System;
using System.Collections.Generic;
using System.Text;
using IdeGames.Data.Common;

namespace IdeGames.Data.Models
{
    public class Order : BaseModel<int>
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime OrderOn { get; set; }
    }
}