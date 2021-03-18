﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StatisticsApp.Data;

namespace StatisticsApp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210318075756_indastryFinancialTable")]
    partial class indastryFinancialTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("StatisticsApp.Entity.FinancialToIndustry", b =>
                {
                    b.Property<int>("UtmId")
                        .HasColumnType("int");

                    b.Property<int>("IndustryFinancialId")
                        .HasColumnType("int");

                    b.HasKey("UtmId", "IndustryFinancialId");

                    b.HasIndex("IndustryFinancialId");

                    b.ToTable("financialToIndustries");
                });

            modelBuilder.Entity("StatisticsApp.Entity.IndustryFinancial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("AverageSalary")
                        .HasColumnType("double");

                    b.Property<double>("Exempt")
                        .HasColumnType("double");

                    b.Property<double>("MaxSalary")
                        .HasColumnType("double");

                    b.Property<double>("MinSalary")
                        .HasColumnType("double");

                    b.Property<bool>("isExemptTax")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("IndustryFinancials");
                });

            modelBuilder.Entity("StatisticsApp.Entity.TaxRate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("TaxRateCount")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.ToTable("TaxRates");
                });

            modelBuilder.Entity("StatisticsApp.Entity.UTM", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<double>("Latitude")
                        .HasColumnType("double");

                    b.Property<double>("Lngitude")
                        .HasColumnType("double");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("PostalCode")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Utms");
                });

            modelBuilder.Entity("StatisticsApp.Entity.FinancialToIndustry", b =>
                {
                    b.HasOne("StatisticsApp.Entity.IndustryFinancial", "IndustryFinancial")
                        .WithMany("FinancialToIndustries")
                        .HasForeignKey("IndustryFinancialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StatisticsApp.Entity.UTM", "Utm")
                        .WithMany("FinancialToIndustries")
                        .HasForeignKey("UtmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IndustryFinancial");

                    b.Navigation("Utm");
                });

            modelBuilder.Entity("StatisticsApp.Entity.IndustryFinancial", b =>
                {
                    b.Navigation("FinancialToIndustries");
                });

            modelBuilder.Entity("StatisticsApp.Entity.UTM", b =>
                {
                    b.Navigation("FinancialToIndustries");
                });
#pragma warning restore 612, 618
        }
    }
}
