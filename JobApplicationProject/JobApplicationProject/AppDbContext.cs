using JobApplicationProject.Models;
using Microsoft.EntityFrameworkCore;

namespace JobApplicationProject
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Job_Skill>()
                .HasOne(j => j.Job)
                .WithMany(s => s.Job_Skills)
                .HasForeignKey(j => j.JobId);

            modelBuilder.Entity<Job_Skill>()
                .HasOne(j => j.Skill)
                .WithMany(s => s.Job_Skills)
                .HasForeignKey(j => j.SkillId);
        }

        public DbSet<Job> Jobs { get; set; }

        public DbSet<Company> Companies { get; set; }

        public DbSet<ApplicationStatus> ApplicationStatuses { get; set; }

        public DbSet<Skill> Skills { get; set; }    

        public DbSet<Job_Skill> Job_Skills { get; set; }  


    }
}
