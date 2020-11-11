using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoodWorkshop.Domain.Models
{
    public class EpoxyModel
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Price { get; set; }
        public virtual ICollection<WoodFurnitureOrderModel> WoodFurnitureOrders { get; set; }

    }
}
