using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoodWorkshop.Data.Models;

namespace Migration.Data
{
    public class MigrationContext : DbContext
    {
        public MigrationContext() : base("Data Source = (LocalDB)\\MSSQLLocalDB;Initial Catalog = ProgramWithCodeFirstDB;Integrated Security=true")
        {

        }


        public DbSet<WoodFurnitureOrder> WoodFurnitureOrders { get; set; }
        public DbSet<FurnitureType> FurnitureTypes { get; set; }
        public DbSet<WoodType> WoodTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region WoodFurnitureOrder

            modelBuilder.Entity<WoodFurnitureOrder>()
                .ToTable("WoodFurnitureOrders")
                .HasKey(x=>x.Id);

            modelBuilder.Entity<WoodFurnitureOrder>()
                .Property(x => x.FullName)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<WoodFurnitureOrder>()
                .Property(x => x.PhoneNumber)
                .IsRequired()
                .HasMaxLength(15);

            modelBuilder.Entity<WoodFurnitureOrder>()
                .Property(x => x.Color)
                .IsRequired()
                .HasMaxLength(20);

            modelBuilder.Entity<WoodFurnitureOrder>()
                .Property(x => x.Date)
                .IsRequired()
                .HasMaxLength(20);


            #endregion

            #region FurnitureType

            modelBuilder.Entity<FurnitureType>()
               .ToTable("FurnitureTypes")
               .HasKey(x => x.Id);

            modelBuilder.Entity<FurnitureType>()
                .HasMany(x => x.WoodFurnitureOrders)
                .WithRequired(x => x.FurnitureType)
                .HasForeignKey(x => x.FurnitureTypeId);

            modelBuilder.Entity<FurnitureType>()
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(40);

            modelBuilder.Entity<FurnitureType>()
                .Property(x => x.Size)
                .IsRequired()
                .HasMaxLength(20);

            #endregion

            #region WoodType

            modelBuilder.Entity<WoodType>()
               .ToTable("WoodTypes")
               .HasKey(x => x.Id);

            modelBuilder.Entity<WoodType>()
                .HasMany(x => x.WoodFurnitureOrders)
                .WithRequired(x => x.WoodType)
                .HasForeignKey(x => x.WoodTypeId);

            modelBuilder.Entity<WoodType>()
                .Property(x => x.TypeName)
                .IsRequired()
                .HasMaxLength(30);

            modelBuilder.Entity<WoodType>()
                .Property(x => x.Price)
                .IsRequired()
                .HasMaxLength(15);


            #endregion

        }
    }
}
