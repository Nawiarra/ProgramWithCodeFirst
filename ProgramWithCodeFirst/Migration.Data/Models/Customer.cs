using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WoodWorkshop.Data.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string FullName { get; set; }
        public virtual ICollection<WoodFurnitureOrder> WoodFurnitureOrders { get; set; }

    }
}
