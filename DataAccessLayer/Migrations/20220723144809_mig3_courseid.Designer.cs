﻿// <auto-generated />
using System;
using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20220723144809_mig3_courseid")]
    partial class mig3_courseid
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EntityLayer.Concrete.Course", b =>
                {
                    b.Property<string>("CourseId")
                        .HasMaxLength(6)
                        .HasColumnType("NCHAR(6)")
                        .HasColumnName("CourseID");

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CourseId");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            CourseId = "CSI101",
                            CourseName = "Introduction to Computer Science"
                        },
                        new
                        {
                            CourseId = "CSI102",
                            CourseName = "Algorithms"
                        },
                        new
                        {
                            CourseId = "MAT101",
                            CourseName = "Calculus"
                        },
                        new
                        {
                            CourseId = "PHY101",
                            CourseName = "Physics"
                        });
                });

            modelBuilder.Entity("EntityLayer.Concrete.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentId"), 1L, 1);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CourseId")
                        .HasColumnType("NCHAR(6)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentId");

                    b.HasIndex("CourseId");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            StudentId = 1,
                            BirthDate = new DateTime(1994, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CourseId = "MAT101",
                            FirstName = "Mert",
                            LastName = "Ramazanoglu"
                        },
                        new
                        {
                            StudentId = 2,
                            BirthDate = new DateTime(1994, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CourseId = "CSI102",
                            FirstName = "ali",
                            LastName = "Ramazanoglu"
                        });
                });

            modelBuilder.Entity("EntityLayer.Concrete.Student", b =>
                {
                    b.HasOne("EntityLayer.Concrete.Course", "Course")
                        .WithMany("Students")
                        .HasForeignKey("CourseId");

                    b.Navigation("Course");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Course", b =>
                {
                    b.Navigation("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
