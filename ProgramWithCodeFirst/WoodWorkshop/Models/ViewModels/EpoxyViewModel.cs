using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoodWorkshop.Models.ViewModels
{
    public class EpoxyViewModel
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Price { get; set; }
        public virtual ICollection<WoodFurnitureOrderViewModel> WoodFurnitureOrders { get; set; }
    }
}
