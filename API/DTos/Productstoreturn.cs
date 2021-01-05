﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTos
{
    public class ProductsToReturn
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string pictureUrl { get; set; }
        public string ProductType { get; set; }
        public int ProductTypeId { get; set; }
        public string ProductBrand { get; set; }
        public int ProductBrandId { get; set; }
    }
}
