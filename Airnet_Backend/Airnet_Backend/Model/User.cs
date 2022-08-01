using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Airnet_Backend.Model
{
      public partial class User
      {
            [Key]
            public string Username { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public long? MobileNumber { get; set; }
            public string UserRole { get; set; }
            public ICollection<Recharge> Recharges { get; set; }
            public ICollection<Review> Review { get; set; }

      }
}
