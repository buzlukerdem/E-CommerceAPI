using E_Commerce.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Entities
{
    public class Order : BaseEntity
    {
        public int CustomerId { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }

        // Navigation Property, N-N relation Order-Product
        public ICollection<Product> Products { get; set; }
        // Navigation Property, 1-N relation Customer - Order
        public Customer Customer { get; set; }
    }
}
