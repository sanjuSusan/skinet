using API.DTos;
using AutoMapper;
using Core.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Helpers
{
    public class ProductUrlreesolver : IValueResolver<Product, ProductsToReturn, string>
    {
        private readonly IConfiguration _config;

        public ProductUrlreesolver(IConfiguration config)
        {
            _config = config;
        }
        public string Resolve(Product source, ProductsToReturn destination, string destMember, ResolutionContext context)
        {
           if(!string.IsNullOrEmpty(source.pictureUrl))
            {
                return _config["ApiUrl"] + source.pictureUrl;
            }
            return null;
        }
    }

   
}
