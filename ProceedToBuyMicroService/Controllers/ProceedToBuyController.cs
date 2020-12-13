using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProceedToBuyService.Models;
using ProceedToBuyService.Provider;

namespace ProceedToBuyService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProceedToBuyController : ControllerBase
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(ProceedToBuyController));
        private readonly IProceedToBuyProvider _provider;
        public ProceedToBuyController(IProceedToBuyProvider p)
        {
            this._provider = p;
        }



        // POST: api/ProceedToBuy
       [HttpPost]
        [Route("AddToCart")]
        public async Task<IActionResult> AddToCart([FromBody]CartModel cart)
        {
            _log4net.Info("Add to Cart method initiated");
            try
            {
                CartDto result = await _provider.GetSupply(cart.ProductId,cart.CustomerId,cart.Zipcode,cart.DeliveryDate);
                if(result==null)
                {
                    return Content("no vendors available");
                }
                _log4net.Info("Added to Cart");
                return Ok(result);

            }
            catch
            {
                _log4net.Info("Cannot Add To Cart");
                return Ok(null);
            }
           
        }


          [HttpPost]
          [Route("AddToWishlist")]
          public IActionResult AddToWishList([FromBody]CartModel wish )
          {
              _log4net.Info("Add to WishList method initiated");
              try
            {
                  _log4net.Info("Add To Wishlist Provider called");

                WishlistSuccess message =  _provider.Wish(wish.CustomerId, wish.ProductId);
                return Ok(message);

              }
              catch
              {
                  _log4net.Info("Error calling Add Wishlist provider");
                  return Ok(null);
              }
            

          }


    }
}
