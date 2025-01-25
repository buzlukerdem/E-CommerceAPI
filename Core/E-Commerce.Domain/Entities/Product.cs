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
        public string? ProductName { get; set; }
        public int ProductStok { get; set; }
        public int ProductPrice { get; set; }
    }
}
