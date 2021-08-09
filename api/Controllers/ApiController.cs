using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Controllers
{
    
    [ApiController]
    public class ApiController : ControllerBase
    {
        [HttpGet]
        [Route("/taxaJuros")]
        public double Get()
        {
            return 0.01;
        }
    }
}
