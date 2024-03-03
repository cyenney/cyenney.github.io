using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi
{

    public class SurveySaysDbContext : DbContext
    {
        public SurveySaysDbContext(DbContextOptions<SurveySaysDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=laptop\\SQLExpress;Database=SurveySaysDb;Trusted_Connection=true;TrustServerCertificate=true");
        }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
