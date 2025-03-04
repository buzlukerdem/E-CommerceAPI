using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Entities
{
    // Table per hierarchy
    public class ProductImageFile : File
    {
        // NAV prop N-N
        public ICollection<Product> Products { get; set; }
    }
}
