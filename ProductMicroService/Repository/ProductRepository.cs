using ProductMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMicroservice.Repository
{
    public class ProductRepository : IProductRepository
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(ProductRepository));
        public ProductDto productdto;
        public static List<Product> items = new List<Product>()
        {
            new Product(){Id=1,Price=1000,Name="Shoes",Description="..",Image_name="Shoes.png",Rating=4},
            new Product(){Id=2,Price=5000,Name="Thermals",Description="..",Image_name="Thermals.png",Rating=4},
            new Product(){Id=3,Price=500,Name="Bats",Description="..",Image_name="Bats.png",Rating=5},

        };
        public List<ProductDto> SearchProductById()
        {
            try
            {
                _log4net.Info("Product details  have been successfully retrieved");
                List<ProductDto> productsdto = new List<ProductDto>();

                foreach (Product p in items)
                {
                    ProductDto productnewdto = new ProductDto()
                    {
                        Id = p.Id,
                        Price = p.Price,
                        Name = p.Name,
                        Description = p.Description,
                        Image_name = p.Image_name,
                        Rating = p.Rating


                    };
                    productsdto.Add(productnewdto);
                }





                return productsdto;
                
            }
            catch (Exception e)
            {
                _log4net.Error("Error " + e.Message);
                return null;
            }
            
           
    
        }
        public List<ProductDto> SearchProductByName()
        {
            try
            {
                _log4net.Info("Product details  have been successfully retrieved");
                List<ProductDto> productsdto = new List<ProductDto>();

                foreach (Product p in items)
                {
                    ProductDto productnewdto = new ProductDto()
                    {
                        Id = p.Id,
                        Price = p.Price,
                        Name = p.Name,
                        Description = p.Description,
                        Image_name = p.Image_name,
                        Rating = p.Rating


                    };
                    productsdto.Add(productnewdto);
                }
                return productsdto;

            }
            catch (Exception e)
            {
                _log4net.Error("Error " + e.Message);
                return null;
            }
            


        }
        public bool AddProductRating(ProductRating model)
        {
            try
            {
               _log4net.Info("Getting product details for product id " + model.ProdId);
                Product p = items.FirstOrDefault(x => x.Id == model.ProdId);
                p.Rating = model.Rating;
                return true;
            }
            catch (Exception e)
            {
                _log4net.Info("No product found with the given product id " + e.Message);
                return false;
            }


        }

    }
}
