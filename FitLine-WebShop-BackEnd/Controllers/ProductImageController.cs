using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCore.Application_Services;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FitLine_WebShop_BackEnd.Controllers
{
    [Route("api/[controller]")]
    public class ProductImageController : Controller
    {

        private readonly IProductImageService _ProductImageService;
        public ProductImageController(IProductImageService ProductImageService)
        {
            _ProductImageService = ProductImageService;
        }
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<ProductImage> Get()
        {
            return _ProductImageService.ReadProductImages();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public ActionResult<ProductImage> Get(int id)
        {
            return _ProductImageService.FindProductImageWithID(id);
        }

        // POST api/<controller>
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult<ProductImage> Post([FromBody]ProductImage ProductImage)
        {
            if (string.IsNullOrEmpty(ProductImage.url))
            {
                return BadRequest("url required.");
            }
            _ProductImageService.Create(ProductImage);
            return Ok("ProductImage successfully created.");
        }

        // PUT api/<controller>/5
        [Authorize(Roles = "Administrator")]
        [HttpPut("{id}")]
        public ActionResult<ProductImage> Put(int id, [FromBody] ProductImage ProductImage)
        {
            if (id < 1 || id != ProductImage.ID)
            {
                return BadRequest("Parameter ID and address ID must be the same.");
            }
            _ProductImageService.Update(ProductImage);
            return Ok("Address was successfully updated.");
        }

        // DELETE api/<controller>/5
        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public ActionResult<ProductImage> Delete(int id)
        {
            if (null == _ProductImageService.FindProductImageWithID(id))
                return BadRequest("There is no ProductImage with this ID.");
            else
            {
                _ProductImageService.Delete(id);
                return Ok("ProductImage deleted.");
            }
        }
    }
}
