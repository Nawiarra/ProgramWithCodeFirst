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
        public MigrationContext() : base("Data Source =(LocalDB)\\MSSQLLocalDB;Initial Catalog = MultiLayerExampleDB;Integrated Security=true")
        {

        }


        public DbSet <WoodFurnitureOrder> WoodFurnitureOrders { get; set; }
        public DbSet <FurnitureType> FurnitureTypes { get; set; }
        public DbSet <WoodType> WoodTypes { get; set; }
    }
}
