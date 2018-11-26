using Microsoft.EntityFrameworkCore;
using ScheduleHelper.Models.DbModels;

namespace ScheduleHelper.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options)
       : base(options)
        {
        }

        public DbSet<Place> Places { get; set; }

        public DbSet<ScheduleItem> ScheduleItems { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public DbSet<StudentScheduleItem> StudentScheduleItems { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Language> Languages { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<History> Histories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<StudentScheduleItem>()
                .HasKey(x => new { x.StudentId, x.ScheduleItemId });
                
        }

    }
}
