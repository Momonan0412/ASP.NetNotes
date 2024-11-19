using AppDev.API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppDev.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>(entity => {
                entity.HasKey(student => student.StudentIdentification);
                entity.Property(student => student.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(student => student.LastName)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(student => student.Program)
                    .IsRequired();
                entity.Property(student => student.YearLevel)
                    .IsRequired();
                entity.Property(student => student.Status)
                    .IsRequired();
            });

            modelBuilder.Entity<User>(entity => {

                entity.HasKey(user => user.UserIdentification); // Primary Key
                entity.Property(user => user.Email)
                      .IsRequired()
                      .HasMaxLength(200);
                entity.Property(user => user.Password)
                      .IsRequired();

                // Foreign Key Relationship between User and Student
                entity.HasOne(user => user.Student)
                      .WithOne()
                      .HasForeignKey<User>(user => user.StudentIdentification)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
