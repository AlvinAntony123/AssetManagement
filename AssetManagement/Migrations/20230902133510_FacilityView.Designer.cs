﻿// <auto-generated />
using System;
using AssetManagementAPI;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AssetManagementAPI.Migrations
{
    [DbContext(typeof(AssetDbContext))]
    [Migration("20230902133510_FacilityView")]
    partial class FacilityView
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AssetManagementAPI.Models.Asset", b =>
                {
                    b.Property<int>("AssetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AssetId"), 1L, 1);

                    b.Property<string>("AssetName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AssetId");

                    b.ToTable("Assets");
                });

            modelBuilder.Entity("AssetManagementAPI.Models.Building", b =>
                {
                    b.Property<int>("BuildingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BuildingId"), 1L, 1);

                    b.Property<string>("BuildingAbbrv")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BuildingName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BuildingId");

                    b.HasIndex("BuildingAbbrv")
                        .IsUnique()
                        .HasFilter("[BuildingAbbrv] IS NOT NULL");

                    b.ToTable("Buildings");
                });

            modelBuilder.Entity("AssetManagementAPI.Models.Cabin", b =>
                {
                    b.Property<int>("CabinId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CabinId"), 1L, 1);

                    b.Property<string>("CabinName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("FacilityId")
                        .HasColumnType("int");

                    b.HasKey("CabinId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("FacilityId");

                    b.ToTable("Cabins");
                });

            modelBuilder.Entity("AssetManagementAPI.Models.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CityId"), 1L, 1);

                    b.Property<string>("CityAbbrv")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CityName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CityId");

                    b.HasIndex("CityAbbrv")
                        .IsUnique()
                        .HasFilter("[CityAbbrv] IS NOT NULL");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("AssetManagementAPI.Models.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartmentId"), 1L, 1);

                    b.Property<string>("DepartmentName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DepartmentId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("AssetManagementAPI.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"), 1L, 1);

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("EmployeeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAllocated")
                        .HasColumnType("bit");

                    b.HasKey("EmployeeId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("AssetManagementAPI.Models.Facility", b =>
                {
                    b.Property<int>("FacilityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FacilityId"), 1L, 1);

                    b.Property<int>("BuildingId")
                        .HasColumnType("int");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<short>("FaciltyFloor")
                        .HasColumnType("smallint");

                    b.Property<string>("FaciltyName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FacilityId");

                    b.HasIndex("BuildingId");

                    b.HasIndex("CityId");

                    b.ToTable("Facilities");
                });

            modelBuilder.Entity("AssetManagementAPI.Models.MeetingRoom", b =>
                {
                    b.Property<int>("MeetingRoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MeetingRoomId"), 1L, 1);

                    b.Property<int>("FacilityId")
                        .HasColumnType("int");

                    b.Property<string>("MeetingRoomName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalSeats")
                        .HasColumnType("int");

                    b.HasKey("MeetingRoomId");

                    b.HasIndex("FacilityId");

                    b.ToTable("MeetingRooms");
                });

            modelBuilder.Entity("AssetManagementAPI.Models.MeetingRoomAsset", b =>
                {
                    b.Property<int>("MeetingRoomAssetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MeetingRoomAssetId"), 1L, 1);

                    b.Property<int>("AssetId")
                        .HasColumnType("int");

                    b.Property<int>("MeetingRoomId")
                        .HasColumnType("int");

                    b.Property<int>("NoOfItems")
                        .HasColumnType("int");

                    b.HasKey("MeetingRoomAssetId");

                    b.HasIndex("AssetId");

                    b.HasIndex("MeetingRoomId");

                    b.ToTable("MeetingRoomAssets");
                });

            modelBuilder.Entity("AssetManagementAPI.Models.Overview", b =>
                {
                    b.Property<string>("BuildingAbbrv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CityAbbrv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<short>("FaciltyFloor")
                        .HasColumnType("smallint");

                    b.Property<string>("FaciltyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SeatName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToView("Overview");
                });

            modelBuilder.Entity("AssetManagementAPI.Models.Seat", b =>
                {
                    b.Property<int>("SeatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SeatId"), 1L, 1);

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("FacilityId")
                        .HasColumnType("int");

                    b.Property<string>("SeatName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SeatId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("FacilityId");

                    b.ToTable("Seats");
                });

            modelBuilder.Entity("AssetManagementAPI.Models.UnallocatedViewModel", b =>
                {
                    b.Property<string>("BuildingAbbrv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CityAbbrv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<short>("FaciltyFloor")
                        .HasColumnType("smallint");

                    b.Property<string>("FaciltyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SeatName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToView("Unallocated");
                });

            modelBuilder.Entity("AssetManagementAPI.Models.Cabin", b =>
                {
                    b.HasOne("AssetManagementAPI.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId");

                    b.HasOne("AssetManagementAPI.Models.Facility", "Facility")
                        .WithMany()
                        .HasForeignKey("FacilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Facility");
                });

            modelBuilder.Entity("AssetManagementAPI.Models.Employee", b =>
                {
                    b.HasOne("AssetManagementAPI.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("AssetManagementAPI.Models.Facility", b =>
                {
                    b.HasOne("AssetManagementAPI.Models.Building", "Building")
                        .WithMany()
                        .HasForeignKey("BuildingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AssetManagementAPI.Models.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Building");

                    b.Navigation("City");
                });

            modelBuilder.Entity("AssetManagementAPI.Models.MeetingRoom", b =>
                {
                    b.HasOne("AssetManagementAPI.Models.Facility", "Facility")
                        .WithMany()
                        .HasForeignKey("FacilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Facility");
                });

            modelBuilder.Entity("AssetManagementAPI.Models.MeetingRoomAsset", b =>
                {
                    b.HasOne("AssetManagementAPI.Models.Asset", "Asset")
                        .WithMany()
                        .HasForeignKey("AssetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AssetManagementAPI.Models.MeetingRoom", "MeetingRoom")
                        .WithMany()
                        .HasForeignKey("MeetingRoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Asset");

                    b.Navigation("MeetingRoom");
                });

            modelBuilder.Entity("AssetManagementAPI.Models.Seat", b =>
                {
                    b.HasOne("AssetManagementAPI.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId");

                    b.HasOne("AssetManagementAPI.Models.Facility", "Facility")
                        .WithMany()
                        .HasForeignKey("FacilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Facility");
                });
#pragma warning restore 612, 618
        }
    }
}
