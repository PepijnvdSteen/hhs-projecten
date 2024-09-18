﻿// <auto-generated />
using EFCore.ORM;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EFCore.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20240917095925_grades")]
    partial class grades
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("EFCore.ORM.Student", b =>
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

            modelBuilder.Entity("EFCore.ORM.Teacher", b =>
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

            modelBuilder.Entity("EFCore.ORM.Student", b =>
                {
                    b.OwnsOne("System.Collections.Generic.List<EFCore.ORM.Grade>", "Grades", b1 =>
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
#pragma warning restore 612, 618
        }
    }
}
