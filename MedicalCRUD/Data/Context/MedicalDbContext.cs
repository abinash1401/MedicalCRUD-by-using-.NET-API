using MedicalCRUD.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicalCRUD.Data.Contexts
{
    public class MedicalDbContext : DbContext
    {
        public MedicalDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<MedicalChart> MedicalCharts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<MedicalChart>()
                .HasOne(mc => mc.Patient)
                .WithMany(p => p.MedicalCharts)
                .HasForeignKey(mc => mc.PatientId);
        }

    }
}