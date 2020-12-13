using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProceedToBuyService.Models;

namespace ProceedToBuyService.Provider
{
    public interface IProceedToBuyProvider
    {
        public Task<CartDto> GetSupply(int prodid,int cutsid,int zipcode,DateTime delidt);
        //public IEnumerable<Cart> Add(Cart entity);
        //public bool Add(Wishlist entity);
        public WishlistSuccess Wish(int custid, int prodid);
    }
}
