﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.ViewModels.Products
{
    public class VM_Update_Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public long Price { get; set; }
        public int Stock { get; set; }
    }
}
