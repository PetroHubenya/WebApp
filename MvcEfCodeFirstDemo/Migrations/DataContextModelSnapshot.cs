﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MvcEfCodeFirstDemo.Data;

#nullable disable

namespace MvcEfCodeFirstDemo.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Models.Sensor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BoxId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BoxId");

                    b.ToTable("Sensors");
                });

            modelBuilder.Entity("Models.SensorData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("SensorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("SensorId1")
                        .HasColumnType("int");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.Property<double>("Value")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("SensorId1");

                    b.ToTable("SensorsData");
                });

            modelBuilder.Entity("MvcEfCodeFirstDemo.Models.Box", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Boxes");
                });

            modelBuilder.Entity("Models.Sensor", b =>
                {
                    b.HasOne("MvcEfCodeFirstDemo.Models.Box", null)
                        .WithMany("Sensors")
                        .HasForeignKey("BoxId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Models.SensorData", b =>
                {
                    b.HasOne("Models.Sensor", null)
                        .WithMany("SensorsData")
                        .HasForeignKey("SensorId1");
                });

            modelBuilder.Entity("Models.Sensor", b =>
                {
                    b.Navigation("SensorsData");
                });

            modelBuilder.Entity("MvcEfCodeFirstDemo.Models.Box", b =>
                {
                    b.Navigation("Sensors");
                });
#pragma warning restore 612, 618
        }
    }
}
