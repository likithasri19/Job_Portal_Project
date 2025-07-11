using Microsoft.EntityFrameworkCore;
using JobRepository.Model;

namespace JobRepository
{
    public class JobPortalContext : DbContext
    {
        public JobPortalContext(DbContextOptions<JobPortalContext> options) : base(options)
        {
        }

        public DbSet<Job> Jobs { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Location> Locations { get; set; }

        public DbSet<JobSkill> JobSkills { get; set; }

        public DbSet<Application> Applications { get; set; }

        public DbSet<Skill> Skills { get; set; }

        public DbSet<Manager> Managers { get; set; }


        public DbSet<User> Users { get; set; }






        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Your [ForeignKey] attributes handle the relationships automatically
            // Only configure default values


       
            base.OnModelCreating(modelBuilder);
        }
    }
}