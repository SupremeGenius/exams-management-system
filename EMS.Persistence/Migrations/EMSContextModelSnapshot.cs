﻿// <auto-generated />
using System;
using EMS.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EMS.Persistence.Migrations
{
    [DbContext(typeof(EMSContext))]
    partial class EMSContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024");

            modelBuilder.Entity("EMS.Domain.Course", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Semester");

                    b.Property<int>("StudentYear");

                    b.Property<string>("Title");

                    b.Property<string>("UniversityYear");

                    b.HasKey("Id");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("EMS.Domain.Entities.CourseProfessor", b =>
                {
                    b.Property<Guid>("CourseId");

                    b.Property<Guid>("ProfessorId");

                    b.HasKey("CourseId", "ProfessorId");

                    b.HasIndex("ProfessorId");

                    b.ToTable("CourseProfessor");
                });

            modelBuilder.Entity("EMS.Domain.Entities.Professor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Title");

                    b.Property<Guid?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Professors");
                });

            modelBuilder.Entity("EMS.Domain.Entities.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FatherInitial");

                    b.Property<Guid?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("EMS.Domain.Exam", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CourseId");

                    b.Property<DateTime>("Date");

                    b.Property<Guid?>("ProfessorId");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("ProfessorId");

                    b.ToTable("Exams");
                });

            modelBuilder.Entity("EMS.Domain.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Password");

                    b.Property<string>("Role");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EMS.Domain.Entities.CourseProfessor", b =>
                {
                    b.HasOne("EMS.Domain.Course", "Course")
                        .WithMany("CourseProfessors")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EMS.Domain.Entities.Professor", "Professor")
                        .WithMany("CourseProfessors")
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EMS.Domain.Entities.Professor", b =>
                {
                    b.HasOne("EMS.Domain.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("EMS.Domain.Entities.Student", b =>
                {
                    b.HasOne("EMS.Domain.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("EMS.Domain.Exam", b =>
                {
                    b.HasOne("EMS.Domain.Course", "Course")
                        .WithMany("Exams")
                        .HasForeignKey("CourseId");

                    b.HasOne("EMS.Domain.Entities.Professor", "Professor")
                        .WithMany("Exams")
                        .HasForeignKey("ProfessorId");
                });
#pragma warning restore 612, 618
        }
    }
}
