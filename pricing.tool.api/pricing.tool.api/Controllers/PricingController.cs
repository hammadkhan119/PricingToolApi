using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyMDB.Controllers;
using pricing.tool.api.Core;
using pricing.tool.api.Data;
using pricing.tool.api.Models;

namespace pricing.tool.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PricingController : ApiBaseController<Product, PricingRepository>
    {
        PricingRepository _repository;
        public PricingController(PricingRepository repository) : base(repository)
        {
            _repository = repository;

        }
        [HttpGet("{consumption}/compare")]
        public ActionResult<IEnumerable<Product>> Compare(int consumption)
        {
            var result = new List<Product>();
            result.Add(_repository.GetBasicElectricityTariff(consumption));
            result.Add(_repository.GetPackagedTariff(consumption));
            return Ok(result.OrderBy(x => x.AnnualCost).ToList());
        }
    }
}

