using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCore.Application_Services;
using Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FitLine_WebShop_BackEnd.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {

        private readonly IProductService _ProductService;
        public ProductController(IProductService ProductService)
        {
            _ProductService = ProductService;
        }
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _ProductService.ReadProducts();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            return _ProductService.FindProductWithID(id);
        }

        
        // POST api/<controller>
        [HttpPost]
        public ActionResult<Product> Post([FromBody]Product Product)
        {
            if (string.IsNullOrEmpty(Product.Name))
            {
                return BadRequest("Name required.");
            }
            _ProductService.Create(Product);
            return Ok("Product successfully created.");
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public ActionResult<Product> Put(int id, [FromBody] Product Product)
        {
            if (id < 1 || id != Product.ID)
            {
                return BadRequest("Parameter ID and address ID must be the same.");
            }
            _ProductService.Update(Product);
            return Ok("Address was successfully updated.");
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public ActionResult<Product> Delete(int id)
        {
            if (null == _ProductService.FindProductWithID(id))
                return BadRequest("There is no Product with this ID.");
            else
            {
                _ProductService.Delete(id);
                return Ok("Product deleted.");
            }
        }
    }
}
