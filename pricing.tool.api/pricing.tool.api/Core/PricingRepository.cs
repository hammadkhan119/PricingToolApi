using pricing.tool.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pricing.tool.api.Core
{
    public class PricingRepository : CoreRepository<Product>
    {
        public Product GetBasicElectricityTariff(int consumption)
        {
            var product = new Product();
            product.Id = 1;
            var annualCost = (5 * 12) + consumption * 22;
            product.TariffName = "basic electricity tariff";
            product.AnnualCost = string.Format("{0} €/year", annualCost);
            return product;
        }
        public Product GetPackagedTariff(int consumption) 
        {
            var product = new Product();
            product.TariffName = "Packaged tariff";
            product.Id = 2;
            var annualCost = 0;
            if (consumption <= 4000) { 
                annualCost = 800;
            }
            else
            {
                annualCost = 800 + ((consumption - 4000) * 30);
            }
            product.AnnualCost = string.Format("{0} €/year", annualCost);
            return product;
        }
    }
}
