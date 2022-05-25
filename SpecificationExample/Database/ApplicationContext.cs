using Microsoft.EntityFrameworkCore;

namespace SpecificationExample.Database
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserTask> Tasks { get; set; }
        public DbSet<TaskStatus> Statuses { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(x => x.UserTasks)
                .WithOne(x => x.Author)
                .HasForeignKey(x => x.AuthorId);
            
            modelBuilder.Entity<UserTask>()
                .HasOne(x => x.Status)
                .WithMany(x => x.UserTasks)
                .HasForeignKey(x => x.StatusId);

            base.OnModelCreating(modelBuilder);
        }
    }
}