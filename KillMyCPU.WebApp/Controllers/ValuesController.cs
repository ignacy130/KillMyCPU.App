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
        // GET api/values
        [HttpGet]
        public JsonResult Run()
        {
            return new JsonResult(new PrimeNumberCounter().Run());
        }
    }
}
