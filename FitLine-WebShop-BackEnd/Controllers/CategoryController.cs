using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCore.Appliaction_Services_Impl;
using AppCore.Application_Services;
using Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FitLine_WebShop_BackEnd.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {

        private readonly ICategoryService _CategoryService;
        public CategoryController(ICategoryService CategoryService)
        {
            _CategoryService = CategoryService;
        } 
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return _CategoryService.ReadCategories();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]   
        public ActionResult<Category> Get(int id)
        {
            return _CategoryService.FindCategoryWithID(id);
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult<Category> Post([FromBody]Category Category)
        {
            if (string.IsNullOrEmpty(Category.Name))
            {
                return BadRequest("Name required.");
            }
            _CategoryService.Create(Category);
            return Ok("Category successfully created.");
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public ActionResult<Category> Put(int id, [FromBody] Category Category)
        {
            if (id < 1 || id != Category.ID)
            {
                return BadRequest("Parameter ID and Category ID must be the same.");
            }
            else if (string.IsNullOrEmpty(Category.Name))
            {
                return BadRequest("Name required.");
            }
            _CategoryService.Update(Category);
            return Ok("Category was successfully updated.");
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public ActionResult<Category> Delete(int id)
        {
            if (null == _CategoryService.FindCategoryWithID(id))
                return BadRequest("There is no Category with this ID.");
            else
            {
                _CategoryService.Delete(id);
                return Ok("Category deleted.");
            }
        }
    }
}
