﻿// <auto-generated />
using ApexaApp.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApexaApp.API.Data.Migrations
{
    [DbContext(typeof(ApexaContext))]
    [Migration("20241111222159_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("ApexaApp.API.Models.Advisor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .HasMaxLength(10)
                        .HasColumnType("TEXT");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<string>("HealthStatus")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("SIN")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("SIN")
                        .IsUnique();

                    b.ToTable("Advisors");
                });
#pragma warning restore 612, 618
        }
    }
}