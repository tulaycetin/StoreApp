
using Microsoft.AspNetCore.Mvc;
using Repositories;
using Services.Contracts;

namespace StoreApp.Components
{
    public class ProductSummaryViewComponent:ViewComponent
    {
        private readonly IServicesManager _servicesManager ;

        public ProductSummaryViewComponent(IServicesManager  servicesManager)
        {
            _servicesManager = servicesManager;
        }
        public String Invoke()
        {
            //urun sayısı alınacak
            return _servicesManager.ProductServices.GetAllProducts(false).Count().ToString();  
        }
    }
}
