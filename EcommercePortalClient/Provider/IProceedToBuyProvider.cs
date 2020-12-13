using EcommercePortalClient.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EcommercePortalClient.Provider
{
    public interface IProceedToBuyProvider
    {
        public Task<HttpResponseMessage> AddToCart(CartViewModel cart);
        public Task<HttpResponseMessage> AddToWishlist(CartViewModel cart);
    }
}
