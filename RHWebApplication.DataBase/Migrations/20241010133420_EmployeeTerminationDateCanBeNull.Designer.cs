﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RHWebApplication.Database;

#nullable disable

namespace RHWebApplication.Database.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20241010133420_EmployeeTerminationDateCanBeNull")]
    partial class EmployeeTerminationDateCanBeNull
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RHWebApplication.Shared.Models.JobModels.Job", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("BaseSalary")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsPericulosity")
                        .HasColumnType("bit");

                    b.Property<bool>("IsUnhealthy")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Job");
                });

            modelBuilder.Entity("RHWebApplication.Shared.Models.PayrollModels.Payroll", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Additionals")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Commission")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Deductions")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<decimal>("Gross")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Net")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("OverTime")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Payrolls");
                });

            modelBuilder.Entity("RHWebApplication.Shared.Models.UserModels.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("RHWebApplication.Shared.Models.UserModels.Admin", b =>
                {
                    b.HasBaseType("RHWebApplication.Shared.Models.UserModels.User");

                    b.ToTable("Admins", (string)null);
                });

            modelBuilder.Entity("RHWebApplication.Shared.Models.UserModels.Employee", b =>
                {
                    b.HasBaseType("RHWebApplication.Shared.Models.UserModels.User");

                    b.Property<int>("JobId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("TerminationDate")
                        .HasColumnType("datetime2");

                    b.HasIndex("JobId");

                    b.ToTable("Employees", (string)null);
                });

            modelBuilder.Entity("RHWebApplication.Shared.Models.PayrollModels.Payroll", b =>
                {
                    b.HasOne("RHWebApplication.Shared.Models.UserModels.Employee", "Employee")
                        .WithMany("PayrollHistory")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("RHWebApplication.Shared.Models.UserModels.Admin", b =>
                {
                    b.HasOne("RHWebApplication.Shared.Models.UserModels.User", null)
                        .WithOne()
                        .HasForeignKey("RHWebApplication.Shared.Models.UserModels.Admin", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RHWebApplication.Shared.Models.UserModels.Employee", b =>
                {
                    b.HasOne("RHWebApplication.Shared.Models.UserModels.User", null)
                        .WithOne()
                        .HasForeignKey("RHWebApplication.Shared.Models.UserModels.Employee", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RHWebApplication.Shared.Models.JobModels.Job", "Job")
                        .WithMany()
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Job");
                });

            modelBuilder.Entity("RHWebApplication.Shared.Models.UserModels.Employee", b =>
                {
                    b.Navigation("PayrollHistory");
                });
#pragma warning restore 612, 618
        }
    }
}
