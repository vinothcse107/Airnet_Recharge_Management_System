using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Airnet_Backend.Model
{
      public class Review
      {
            [Key, ForeignKey("RechargeReviewId")]
            public Guid ReviewId { get; set; }
            [JsonIgnore]
            public virtual Recharge RechargeReviewId { get; set; }
            // ----------------------------------------
            [ForeignKey("User")]
            public string Username { get; set; }
            [JsonIgnore]
            public User User { get; set; }
            // ----------------------------------------
            [ForeignKey("Plan")]
            public Guid PlanId { get; set; }
            [JsonIgnore]
            public Plan Plan { get; set; }
            // -----------------
            public string ReviewContent { get; set; }
            public string ReviewRating { get; set; }
      }
}