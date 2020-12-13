using EcommercePortalClient.Models.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace EcommercePortalClient.Provider
{
    public class ProductProvider : IProductProvider
    {
        public async Task<HttpResponseMessage> GetProductById(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44328/");
                client.DefaultRequestHeaders.Accept.Clear();
                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                var response = await client.GetAsync("api/Product/searchProductById/" + id);
                return response;
            }
        }

        public async Task<HttpResponseMessage> GetProductByName(string name)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44328/");
                client.DefaultRequestHeaders.Accept.Clear();
                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                var response = await client.GetAsync("api/Product/searchProductByName/" + name);
                return response;
            }
        }

        public async Task<HttpResponseMessage> RateAProduct(ProductViewModel prod)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:44328/");
                var jsonstring = JsonConvert.SerializeObject(prod);
                var obj = new StringContent(jsonstring, System.Text.Encoding.UTF8, "application/json");
                var response = await client.PostAsync("api/Product/RateAProduct/", obj);
                return response;
            }
        }
    }
}
