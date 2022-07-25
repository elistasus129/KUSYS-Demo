using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-OO37TJV;database=KUSYSDemo;integrated security=true");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
             new Student()
             {
                 StudentId = 1,
                 FirstName = "Mert",
                 LastName = "Ramazanoglu",
                 BirthDate = Convert.ToDateTime("1994-09-12"),
                 CourseId = "MAT101"
             },
               new Student()
               {
                   StudentId = 2,
                   FirstName = "Ali",
                   LastName = "Ramazanoglu",
                   BirthDate = Convert.ToDateTime("1999-05-11"),
                   CourseId = "CSI102"
               }
             );

            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(p => p.CourseId).HasColumnName("CourseID").HasColumnType("NCHAR").HasMaxLength(6);
                entity.Property(p => p.CourseName).IsRequired().HasMaxLength(50);

            });

            modelBuilder.Entity<Course>().HasData
                (
                new Course() { CourseId = "CSI101", CourseName = "Introduction to Computer Science" },
                new Course() { CourseId = "CSI102", CourseName = "Algorithms" },
                new Course() { CourseId = "MAT101", CourseName = "Calculus" },
                new Course() { CourseId = "PHY101", CourseName = "Physics" }
                );



        }
     
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
