﻿// <auto-generated />
using EFCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EFCore.Migrations
{
    [DbContext(typeof(MyContext))]
    partial class MyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("EFCore.Models.Student", b =>
                {
                    b.Property<int>("StudentNr")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("Email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("StudentNr");

                    b.ToTable("Studenten");
                });

            modelBuilder.Entity("EFCore.Models.Teacher", b =>
                {
                    b.Property<int>("TeacherNr")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("Email");

                    b.Property<string>("TeachingCourse")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("TeacherNr");

                    b.ToTable("Teacher");
                });

            modelBuilder.Entity("StudentTeacher", b =>
                {
                    b.Property<int>("studentsStudentNr")
                        .HasColumnType("INTEGER");

                    b.Property<int>("teachersTeacherNr")
                        .HasColumnType("INTEGER");

                    b.HasKey("studentsStudentNr", "teachersTeacherNr");

                    b.HasIndex("teachersTeacherNr");

                    b.ToTable("StudentTeacher");
                });

            modelBuilder.Entity("EFCore.Models.Student", b =>
                {
                    b.OwnsOne("System.Collections.Generic.List<EFCore.Models.Grade>", "Grades", b1 =>
                        {
                            b1.Property<int>("StudentNr")
                                .HasColumnType("INTEGER");

                            b1.Property<int>("Capacity")
                                .HasColumnType("INTEGER");

                            b1.HasKey("StudentNr");

                            b1.ToTable("Studenten");

                            b1.WithOwner()
                                .HasForeignKey("StudentNr");
                        });

                    b.Navigation("Grades")
                        .IsRequired();
                });

            modelBuilder.Entity("StudentTeacher", b =>
                {
                    b.HasOne("EFCore.Models.Student", null)
                        .WithMany()
                        .HasForeignKey("studentsStudentNr")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFCore.Models.Teacher", null)
                        .WithMany()
                        .HasForeignKey("teachersTeacherNr")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
