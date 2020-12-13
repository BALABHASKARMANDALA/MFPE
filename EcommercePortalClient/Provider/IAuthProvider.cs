using EcommercePortalClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EcommercePortalClient.Provider
{
    public interface IAuthProvider
    {
        public Task<HttpResponseMessage> Login(User user);
    }
}
