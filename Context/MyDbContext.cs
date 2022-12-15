using Microsoft.EntityFrameworkCore;
using TaskTracker.Entity;

namespace TaskTracker.Context
{
    ///<summary>
    ///This class is used for interaction with database.
    ///</summary>
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ProjectEntity> Projects { get; set; }

        public virtual DbSet<TaskEntity> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjectEntity>(entity =>
            {
                entity.ToTable("Project");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.ProjectStatus)
                    .IsRequired();

                entity.Property(e => e.Priority)
                    .IsRequired();
            });

            modelBuilder.Entity<TaskEntity>(entity =>
            {
                entity.ToTable("Task");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Description)
                    .HasMaxLength(255);

                entity.Property(e => e.Status)
                    .IsRequired();

                entity.Property(e => e.Priority)
                    .IsRequired();
            });
        }
    }
}
