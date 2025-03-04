using E_Commerce.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public long Price { get; set; }
        public int Stock { get; set; }
        // NAV PROP N-N
        public ICollection<Order> Orders { get; set; }
        // NAV PROP N-N
        public ICollection<ProductImageFile> ProductImageFiles { get; set; }
    }
}
