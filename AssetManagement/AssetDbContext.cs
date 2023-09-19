using AssetManagementAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace AssetManagementAPI
{
    public class AssetDbContext : DbContext
    {
        public AssetDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<City> Cities { get; set; }
        public DbSet<Building> Buildings { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Asset> Assets { get; set; }

        public DbSet<Facility> Facilities { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Seat> Seats { get; set; }

        public DbSet<Cabin> Cabins { get; set; }

        public DbSet<MeetingRoom> MeetingRooms { get; set; }

        public DbSet<MeetingRoomAsset> MeetingRoomAssets { get; set; }

        public DbSet<Overview> Overviews { get; set; }

        public DbSet<UnallocatedViewModel> unallocatedViewModels { get; set; }

        public DbSet<FacilityViewModel> FacilityViewModels { get; set; }

        public DbSet<CabinAllocatedViewModel> CabinAllocatedViewModels { get; set; }

        public DbSet<CabinUnallocatedViewModel> CabinUnallocatedViewModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder
                .Entity<Overview>()
                .ToView("Overview")
                .HasNoKey();

            base.OnModelCreating(modelBuilder);
            modelBuilder
                .Entity<UnallocatedViewModel>()
                .ToView("Unallocated")
                .HasNoKey();

            base.OnModelCreating(modelBuilder);
            modelBuilder
                .Entity<FacilityViewModel>()
                .ToView("FacilityView")
                .HasNoKey();

            base.OnModelCreating(modelBuilder);
            modelBuilder
                .Entity<CabinAllocatedViewModel>()
                .ToView("CabinAllocated")
                .HasNoKey();

            base.OnModelCreating(modelBuilder);
            modelBuilder
                .Entity<CabinUnallocatedViewModel>()
                .ToView("CabinUnallocated")
                .HasNoKey();

        }
    }
}
