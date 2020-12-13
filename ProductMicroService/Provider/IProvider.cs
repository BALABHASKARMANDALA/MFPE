using ProductMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMicroservice.Provider
{
    public interface IProvider
    {
        public ProductDto SearchProductById(int Product_Id);
        public ProductDto SearchProductByName(string Product_Name);
        public bool AddProductRating(ProductRating model);
    }
}