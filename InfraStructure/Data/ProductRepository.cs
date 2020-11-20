using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfraStructure.Data
{
    public class ProductRepository : IGenericRepository
    {
        private readonly StoreDbContext _context;

        public ProductRepository(StoreDbContext context)
        {
            _context = context;  
        }
        public async Task<Product> GetProductByIdAsync(int Id)
        {
            return await _context.Products
                .Include(p=>p.ProductType)
                .Include(p=>p.ProductBrand)
                .FirstOrDefaultAsync(p=>p.Id==Id);
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {

            var typeId = 1;
            var products = _context.Products.Where(x => x.ProductTypeId == typeId).Include(x => x.ProductType).ToListAsync();
            return await _context.Products.
                Include(p => p.ProductType)
                .Include(p => p.ProductBrand)               
                .ToListAsync();
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductsBrandAsync()
        {
            return await _context.ProductBrands.ToListAsync();
        }

        public async Task<IReadOnlyList<ProductType>> GetProductsTypeAsync()
        {
            return await _context.ProductTypes.ToListAsync();
        }
    }

  
}
