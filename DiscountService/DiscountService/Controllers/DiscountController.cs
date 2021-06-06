using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DiscountService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        [HttpGet("{code}")]
        public string Validate(string code)
        {
            if (code.Length != 6)
                return "Invalid Code-0";

            switch (code)
            {
                case "CD0010":
                    return "Valid-10";
                case "CD0020":
                    return "Valid-20";
                default:
                    return "Invalid Code-0";
            }
        }
    }
}
