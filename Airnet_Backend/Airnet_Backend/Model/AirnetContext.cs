using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Airnet_Backend.Model
{
      public partial class AirnetContext : DbContext
      {
            public AirnetContext(DbContextOptions<AirnetContext> options)
                : base(options)
            {
            }
            public DbSet<Plan> Plans { get; set; }
            public DbSet<Recharge> Recharges { get; set; }
            public DbSet<User> Users { get; set; }
            public DbSet<Review> Reviews { get; set; }

      }
}
