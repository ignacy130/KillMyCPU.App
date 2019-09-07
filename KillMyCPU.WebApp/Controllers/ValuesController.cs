using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PrimeNumbersCounter;

namespace KillMyCPU.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrimesController : ControllerBase
    {
        // GET api/primes
        [HttpGet]
        public async Task<JsonResult> Run(int min = 100000, int max = 2000000)
        {
            return new JsonResult(await new PrimeNumberCounter().Run(min, max));
        }
    }
}
