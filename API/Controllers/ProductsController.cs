using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using InfraStructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
    
        //private readonly IGenericRepository _repo;
        private readonly IGenericRepository<Product> _ProductRepo;
        private readonly IGenericRepository<ProductBrand> _ProductBrandRepo;
        private readonly IGenericRepository<ProductType> _ProductTypeRepo;

        //public ProductsController(IProductRepository repo)
        //{
        //    _repo = repo;
        //}

        public ProductsController(IGenericRepository<Product> _productRepo,
            IGenericRepository<ProductBrand> _productBrandRepo, 
            IGenericRepository<ProductType> _productTypeRepo )
        {
            _ProductRepo = _productRepo;
            _ProductBrandRepo = _productBrandRepo;
            _ProductTypeRepo = _productTypeRepo;
        }
        [HttpGet]
        public async Task<ActionResult <List<Product>>> GetProducts()

        {
            var products = await _ProductRepo.ListAllAsync();
            return Ok(products);
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<Product>> GetProductById(int Id)
        {
            return await _ProductRepo.GetByIdAsync(Id);
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            return Ok(await _ProductTypeRepo.ListAllAsync());
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok (await _ProductTypeRepo.ListAllAsync());
        }

    }
}