using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Specification
{
    public class ProductsWithTypeandBrandsSpecification:BaseSpecification<Product>
    {
        public ProductsWithTypeandBrandsSpecification()
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }
        public ProductsWithTypeandBrandsSpecification(int id)
            :base(x => x.Id==id)
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }
    }
}
