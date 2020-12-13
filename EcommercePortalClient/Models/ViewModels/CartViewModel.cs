using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommercePortalClient.Models.ViewModels
{
    public class CartViewModel
    {
        public int Product_Id { get; set; }
        public int Customer_Id { get; set; }
        public int ZipCode { get; set; }
        public DateTime DeliveryDate { get; set; }

    }
}
