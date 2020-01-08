using pricing.tool.api.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pricing.tool.api.Models
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public string TariffName { get; set; }
        public string AnnualCost { get; set; }
    }
}
