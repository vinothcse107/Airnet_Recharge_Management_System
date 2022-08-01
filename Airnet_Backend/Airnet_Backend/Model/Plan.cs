using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Airnet_Backend.Model
{
      public partial class Plan
      {
            [Key]
            public Guid PlanId { get; set; }
            public string PlanType { get; set; }
            public string PlanName { get; set; }
            public string PlanValidity { get; set; }
            public string PlanDetails { get; set; }
            public string PlanPrice { get; set; }
            public string PlanOffers { get; set; }
            public virtual ICollection<Review> Review { get; set; }

      }
}
