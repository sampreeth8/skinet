﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
   public interface IProductRepository
    {

        Task<IReadOnlyList<Product>> GetProductsAsync();
        Task<Product> GetProductByIdAsync(int id);

        Task<List<ProductBrand>> GetProductBrandsAsync();
        Task<List<ProductType>> GetProductTypesAsync();
        
    }
}
