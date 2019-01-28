using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using Workshop.Data.Models.Account;
using Workshop.Data.Models.Car;
using Workshop.Data.Models.Logging;

namespace Workshop.Data
{
    public class WorkshopDbContext: IdentityDbContext<WorkshopUser, WorkshopRole, Guid>
    {
        public DbSet<WorkshopLog> Logs { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarImage> CarImages { get; set; }

        public WorkshopDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            ConfigureCarModel(builder);
            ConfigureCarImagesModel(builder);

            InitializeWorkshopRoles(builder);
        }

        private void ConfigureCarModel(ModelBuilder builder)
        {
            builder.Entity<Car>()
                .HasOne(x => x.Owner)
                .WithMany(x => x.Cars);
        }

        private void ConfigureCarImagesModel(ModelBuilder builder)
        {
            builder.Entity<CarImage>()
                .HasOne(x => x.Car)
                .WithMany(x => x.Images);
        }

        private void InitializeWorkshopRoles(ModelBuilder builder)
        {
            builder.Entity<WorkshopRole>().HasData(new WorkshopRole
            {
                Id = new Guid("3ca04c41-6ba2-41b4-8549-98e09c83777f"),
                Name = "Manager",
                NormalizedName = "MANAGER",
                ConcurrencyStamp = "3ca04c41-6ba2-41b4-8549-98e09c83777f"
            });

            builder.Entity<WorkshopRole>().HasData(new WorkshopRole
            {
                Id = new Guid("5ec55e49-85fa-407c-a308-4faaec25ded0"),
                Name = "Client",
                NormalizedName = "CLIENT",
                ConcurrencyStamp = "5ec55e49-85fa-407c-a308-4faaec25ded0"
            });

            builder.Entity<WorkshopRole>().HasData(new WorkshopRole
            {
                Id = new Guid("275b3afd-e537-4e98-9d67-622b37606565"),
                Name = "Admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = "275b3afd-e537-4e98-9d67-622b37606565"
            });
        }
    }
}
