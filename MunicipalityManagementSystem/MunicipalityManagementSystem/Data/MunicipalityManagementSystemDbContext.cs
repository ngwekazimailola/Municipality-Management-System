using Microsoft.EntityFrameworkCore;
using MunicipalityManagementSystem.Models;

namespace MunicipalityManagementSystem.Data
{
    public class MunicipalityManagementSystemDbContext : DbContext
    {
        public MunicipalityManagementSystemDbContext(DbContextOptions<MunicipalityManagementSystemDbContext> options) : base(options) { }

        public DbSet<Citizen> Citizens { get; set; }
        public DbSet<ServiceRequest> ServiceRequests { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Report> Reports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships
            modelBuilder.Entity<ServiceRequest>()
                .HasOne(sr => sr.Citizen)
                .WithMany(c => c.ServiceRequests)
                .HasForeignKey(sr => sr.CitizenID);

            modelBuilder.Entity<Report>()
                .HasOne(r => r.Citizen)
                .WithMany(c => c.Reports)
                .HasForeignKey(r => r.CitizenID);
        }
    }
}
