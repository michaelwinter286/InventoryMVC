﻿// <auto-generated />
using System;
using InventoryMVC;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InventoryMVC.Migrations
{
    [DbContext(typeof(InventoryDBContext))]
    [Migration("20230712224201_initialcreate")]
    partial class initialcreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.9");

            modelBuilder.Entity("InventoryMVC.Models.Supplies", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("Amount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Item")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Minimum")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Supplies");
                });
#pragma warning restore 612, 618
        }
    }
}
