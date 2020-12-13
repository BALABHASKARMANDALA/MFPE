using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendorMicroService.Models;
using VendorMicroService.Repository;

namespace VendorMicroService.Provider
{
    public class VendorProvider:IVendorProvider
    {
        private readonly IVendorRepository venrepository;
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(VendorProvider));
        public VendorProvider(IVendorRepository _venrepository)
        {
            venrepository = _venrepository;
        }
        public List<VendorDto> GetDetailsOfVendor(int ProductId)

        {
            try
            {

                _log4net.Info(" Http GET in provider is accesed");
               

                List<VendorDto> vendors= venrepository.GetVendorDetails();
                List<VendorStockDto> vendorstocksdto = venrepository.GetVendorStocks();
                var availablevendors = from p in vendorstocksdto where p.ProductId == ProductId && p.StockInHand >= 1 select p.VendorId;
                List<int> availableist = availablevendors.ToList();

                List<VendorDto> vendorslist = new List<VendorDto>();
                foreach (int i in availableist)
                {
                    VendorDto matched = vendors.FirstOrDefault(o => o.VendorId == i);

                    VendorDto m = new VendorDto() { VendorId = matched.VendorId, VendorName = matched.VendorName, DeliveryCharge = matched.DeliveryCharge, Rating = matched.Rating };
                    vendorslist.Add(m);

                }

                return vendorslist;

            }
            catch (Exception e)
            {
                _log4net.Error("exception rised"+e.Message);
                return null;
               
            }
        }
    }
}
