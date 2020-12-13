using EcommercePortalClient.Models.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EcommercePortalClient.Provider
{
    public class ProceedToBuyProvider:IProceedToBuyProvider
    {
        public async Task<HttpResponseMessage> AddToCart(CartViewModel cart)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44363/");
                var jsonstring = JsonConvert.SerializeObject(cart);
                var obj = new StringContent(jsonstring, System.Text.Encoding.UTF8, "application/json");
                var response = await client.PostAsync("api/ProceedToBuy/AddToCart/", obj );
                return response;
            }
        }
        public async Task<HttpResponseMessage> AddToWishlist(CartViewModel cart)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44363/");
                var jsonstring = JsonConvert.SerializeObject(cart);
                var obj = new StringContent(jsonstring, System.Text.Encoding.UTF8, "application/json");
                var response = await client.PostAsync("api/ProceedToBuy/AddToWishList/", obj);
                return response;
            }
        }

    }
}
