using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProceedToBuyService.Models;

namespace ProceedToBuyService.Repository
{
    public interface IProceedToBuyRepository
    {
        public WishlistDto addToWishlist(WishlistDto entity);
        public CartDto addToCart(CartDto entity);
    }
}
