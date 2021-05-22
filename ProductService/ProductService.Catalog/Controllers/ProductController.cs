using Microsoft.AspNetCore.Mvc;
using ProductService.DataAccess;
using ProductService.Model;
using ProductService.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductService.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductManager _prodMgr;
        public ProductController(IProductManager productManager)
        {
            _prodMgr = productManager;
        }

        [HttpGet("categories")]
        public IEnumerable<string> Categories()
        {
            return _prodMgr.GetCategories();
        }

        // GET: api/<ProductController>
        [HttpGet("all")]
        public IEnumerable<ProductBase> Products()
        {
            return _prodMgr.GetProducts();
        }

        // GET api/<ProductController>/5
        [HttpGet("{prodId}")]
        public ProductVM GetProduct(string prodId)
        {
            return _prodMgr.GetProduct(prodId);
        }

        // POST api/<ProductController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
