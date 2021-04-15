using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Gitline.Models;

namespace Gitline.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<ProductOrder> ProductOrder { get; set; }

        public DbSet<Order> Order { get; set; }


    }
}
