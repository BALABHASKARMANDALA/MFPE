using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendorMicroService.Models;

namespace VendorMicroService.Repository
{
    public class VendorRepository : IVendorRepository
    {
        private List<Vendor> vendors;
        private List<VendorStock> vendorstocks;
         

        public   VendorRepository()
        {
            vendors = new List<Vendor>()
            {
                new Vendor { VendorId = 1, VendorName = "Reebok",  DeliveryCharge= 100,Rating = 2 },
                  new Vendor { VendorId = 2, VendorName = "Puma", DeliveryCharge = 200, Rating = 3 },
                    new Vendor { VendorId = 3, VendorName = "Adidas", DeliveryCharge = 150, Rating = 3 },

                    new Vendor { VendorId = 4, VendorName = "Nike", DeliveryCharge= 250, Rating = 5 },
                     new Vendor { VendorId = 5, VendorName = "checklast", DeliveryCharge = 300, Rating = 4 },
            };
            vendorstocks = new List<VendorStock>()
            {
                new VendorStock {ProductId=1, VendorId = 1,StockInHand=1,  ExpectedStockReplenishmentDate=new DateTime(2020,7,6) },
                 new VendorStock {ProductId=1, VendorId = 2,StockInHand=1,  ExpectedStockReplenishmentDate=new DateTime(2020,7,6) },
                  new VendorStock { ProductId = 2, VendorId = 1,StockInHand=1,  ExpectedStockReplenishmentDate=new DateTime(2020,6,15) },
                    new VendorStock { ProductId = 3,VendorId = 1,StockInHand=0,  ExpectedStockReplenishmentDate=new DateTime(2020,6,15) },

                    new VendorStock {ProductId = 4,VendorId = 1,StockInHand=0,  ExpectedStockReplenishmentDate=new DateTime(2020,6,15) },
                     new VendorStock {ProductId = 5, VendorId = 1,StockInHand=1,  ExpectedStockReplenishmentDate=new DateTime(2020,6,15) },
            };
        }

            public List<VendorDto> GetVendorDetails()
        {
            List<VendorDto> vendorsdto=new List<VendorDto>();
           
            foreach (Vendor ven in vendors)
            {
                VendorDto vendornewdto = new VendorDto()
                {
                    VendorId = ven.VendorId,
                    VendorName = ven.VendorName,
                    DeliveryCharge = ven.DeliveryCharge,
                    Rating = ven.Rating,
                };
                vendorsdto.Add(vendornewdto);
            }

            return vendorsdto;
        

        }
        public List<VendorStockDto> GetVendorStocks()
        {
            List<VendorStockDto> vendorstockdto=new List<VendorStockDto>();

            foreach (VendorStock venst in vendorstocks)
            {
                VendorStockDto vendorstocknewdto = new VendorStockDto()
                {
                   ProductId=venst.ProductId,
                   VendorId=venst.VendorId,
                   StockInHand=venst.StockInHand,
                   ExpectedStockReplenishmentDate=venst.ExpectedStockReplenishmentDate,
                };
                vendorstockdto.Add(vendorstocknewdto);
            }

            return vendorstockdto;
        }
    }
}
