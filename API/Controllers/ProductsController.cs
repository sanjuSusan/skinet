using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTos;
using API.Error;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specification;
using InfraStructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    
    public class ProductsController : BaseController
    {
    
        //private readonly IGenericRepository _repo;
        private readonly IGenericRepository<Product> _ProductRepo;
        private readonly IGenericRepository<ProductBrand> _ProductBrandRepo;
        private readonly IGenericRepository<ProductType> _ProductTypeRepo;
        private readonly IMapper mapper;


        //public ProductsController(IProductRepository repo)
        //{
        //    _repo = repo;
        //}

        public ProductsController(IGenericRepository<Product> _productRepo,
            IGenericRepository<ProductBrand> _productBrandRepo, 
            IGenericRepository<ProductType> _productTypeRepo, IMapper mapper )
        {
            _ProductRepo = _productRepo;
            _ProductBrandRepo = _productBrandRepo;
            _ProductTypeRepo = _productTypeRepo;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult <IReadOnlyList<ProductsToReturn>>> GetProducts()

        {
            var spec = new ProductsWithTypeandBrandsSpecification();
            var products = await _ProductRepo.ListAsync(spec);
            return Ok(mapper
                .Map < IReadOnlyList<Product>, IReadOnlyList<ProductsToReturn>>(products));
        }

        [HttpGet("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse),StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductsToReturn>> GetProduct(int id)
        {
            var spec = new ProductsWithTypeandBrandsSpecification(id);
           var product= await _ProductRepo.GetEntityWithSpec(spec);
            if (product == null) return NotFound(new ApiResponse(404));
            return mapper.Map<Product, ProductsToReturn>(product);
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