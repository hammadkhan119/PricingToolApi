using Microsoft.AspNetCore.Mvc;
using pricing.tool.api.Controllers;
using pricing.tool.api.Core;
using pricing.tool.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace pricing.tool.test
{
    public class PricingTest
    {
        [Fact]
        public void When_GetCalled_Return_OkResult()
        {
            PricingRepository pricingRepository = new PricingRepository();
            PricingController pricingController = new PricingController(pricingRepository);

            var okResult = pricingController.Compare(3000);
            Assert.IsType<OkObjectResult>(okResult.Result);
        }
        [Fact]
        public void When_GetCalled_Return_Tariff()
        {
            PricingRepository pricingRepository = new PricingRepository();
            PricingController pricingController = new PricingController(pricingRepository);

            var okResult = pricingController.Compare(3000);
            var items = Assert.IsType<List<Product>>(((ObjectResult)okResult.Result).Value);
            Assert.Equal(2, items.Count);
        }
    }
}
