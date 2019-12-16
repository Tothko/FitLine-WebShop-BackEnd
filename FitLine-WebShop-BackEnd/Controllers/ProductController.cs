using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCore.Application_Services;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NLog.Fluent;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FitLine_WebShop_BackEnd.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {

        private readonly IProductService _productService;
        public ProductController(IProductService ProductService)
        {
            _productService = ProductService;
        }

        private ProductDTO toDto(Product product)
        {
            var rval =  new ProductDTO
            {
                Id = product.ID,
                Name = product.Name,
                CategoryId = product.Category.ID,
                Description = product.Description,
                Price = product.Price,
                Rating = product.Rating
            };

            if(product.Images != null && product.Images.Count > 0)
            {
                rval.Image = product.Images.ElementAt(product.Images.Count - 1).url;
            }

            if(product.Supplier != null)
            {
                rval.Supplier = new SupplierDTO { Id = product.Supplier.ID, Name = product.Supplier.Name };
            }

            return rval;
        }


        // GET api/products
        [HttpGet]
        public ActionResult<IEnumerable<ProductDTO>> Get([FromQuery] ProductsFilter filter)
        {
            try
            {
                IEnumerable<Product> products;

                if(filter != null)
                {
                    products = _productService.ReadFiltered(filter);
                }
                else
                {
                    products = _productService.ReadProducts();
                }                

                if (products == null || products.Count() < 1)
                {
                    return NotFound("There are no products in database");
                }
                else
                {
                    List<ProductDTO> productDTOs = new List<ProductDTO>();
                    foreach (var item in products)
                    {
                        productDTOs.Add(toDto(item));
                    }
                    return Ok(productDTOs);
                }
            }
            catch (Exception ex)
            {
                Log.Error($"Exception occured on ProductsController GetAll\n Stack Trace: {ex.StackTrace}");
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/products/5
        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            if (id < 1)
            {
                return BadRequest("Product Id has to be bigger than 0");
            }

            try
            {
                var product = _productService.FindProductWithID(id);

                if (product == null)
                    return NotFound($"There is no product by id: {id}");

                return Ok(product);
            }
            catch (ArgumentException err)
            {
                return BadRequest(err.Message);
            }
            catch (Exception ex)
            {
                Log.Error($"Exception occured on ProductsController GetById on id: {id}\n Stack Trace: {ex.StackTrace}");
                return StatusCode(500, ex.Message);
            }
        }


        // POST api/<controller>
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult<Product> Post([FromBody]Product Product)
        {
            if(Product == null)
            {
                return BadRequest("Post Product cant be null");
            }

            if (string.IsNullOrEmpty(Product.Name))
            {
                return BadRequest("Name required.");
            }

            try
            {
                var newProduct = _productService.Create(Product);

                if (newProduct != null)
                {
                    return Ok(newProduct);
                }
                else
                {
                    return BadRequest("Product creation failed");
                }
            }
            catch (ArgumentException err)
            {
                return BadRequest(err.Message);
            }
            catch (Exception ex)
            {
                Log.Error($"Exception occured on ProductsController Post on object: {Product}\n Stack Trace: {ex.StackTrace}");
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<controller>/5
        [Authorize(Roles = "Administrator")]
        [HttpPut("{id}")]
        public ActionResult<Product> Put(int id, [FromBody] Product Product)
        {
            if (Product == null)
            {
                return BadRequest("Post Product cant be null");
            }

            if (id < 1 || id != Product.ID)
            {
                return BadRequest("Parameter ID and url ID must be the same.");
            }

            if (string.IsNullOrEmpty(Product.Name))
            {
                return BadRequest("Name required.");
            }

            try
            {
                var newProduct = _productService.Update(Product);

                if (newProduct != null)
                {
                    return Ok(newProduct);
                }
                else
                {
                    return BadRequest("Product creation failed");
                }
            }
            catch (ArgumentException err)
            {
                return BadRequest(err.Message);
            }
            catch (Exception ex)
            {
                Log.Error($"Exception occured on ProductsController Put on object: {Product}\n Stack Trace: {ex.StackTrace}");
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE api/<controller>/5
        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public ActionResult<Product> Delete(int id)
        {
            if (null == _productService.FindProductWithID(id))
            {
                return BadRequest("There is no Product with this ID.");
            }
            else
            {
                try
                {
                    var deletedProduct = _productService.Delete(id);

                    if (deletedProduct != null)
                    {
                        return Ok(deletedProduct);
                    }
                    else
                    {
                        return NotFound("No such product exist");
                    }
                }
                catch (ArgumentException err)
                {
                    return BadRequest(err.Message);
                }
                catch (Exception ex)
                {
                    Log.Error($"Exception occured on ProductsController Delete on id: {id}\n Stack Trace: {ex.StackTrace}");
                    return StatusCode(500, ex.Message);
                }
            }
        }
    }
}
