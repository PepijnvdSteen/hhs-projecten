using Microsoft.EntityFrameworkCore;

namespace EFCore.Models;

public class MyContext : DbContext
{
  public DbSet<Student> Studenten { get; set; }
  
  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.UseSqlite(@"Data Source=/Users/pep/development/hhs-projecten/C#/WPFW/IC5/EFCore/efcore.db");
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
      
    modelBuilder.Entity<Student>()
      .Property(s => s.Name)
      .IsRequired()
      .HasMaxLength(50);
    modelBuilder.Entity<Student>()
      .Property(s => s.Email)
      .HasColumnType("Email");
    modelBuilder.Entity<Student>()
      .OwnsOne(s => s.Grades);
    
    modelBuilder.Entity<Teacher>()
      .Property(t => t.TeachingCourse)
      .IsRequired()
      .HasMaxLength(50);
    modelBuilder.Entity<Teacher>()
      .Property(t => t.Email)
      .HasColumnType("Email");
  }
}