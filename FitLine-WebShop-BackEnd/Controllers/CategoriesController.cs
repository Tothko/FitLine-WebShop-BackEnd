using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCore.Appliaction_Services_Impl;
using AppCore.Application_Services;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NLog.Fluent;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FitLine_WebShop_BackEnd.Controllers
{
    [Route("api/[controller]")]
    public class CategoriesController : Controller
    {

        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService CategoryService)
        {
            _categoryService = CategoryService;
        } 

        // GET: api/<controller>
        [HttpGet]
        public ActionResult<IEnumerable<object>> Get()
        {
            try
            {
                var categories = _categoryService.ReadCategories();

                if (categories == null || categories.Count() < 1)
                {
                    return NotFound("There are no categories in database");
                }
                else
                {
                    var categoryDTOs = new List<object>();
                    foreach (var item in categories)
                    {
                        categoryDTOs.Add(new
                        {
                            Id = item.ID,
                            Name = item.Name
                        });
                    }
                    return Ok(categoryDTOs);
                }
            }
            catch (Exception ex)
            {
                Log.Error($"Exception occured on CategoryController GetAll\n Stack Trace: {ex.StackTrace}");
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<controller>/nameOfCat
        [HttpGet("{name}")]   
        public ActionResult<Category> Get(string name)
        {
            try
            {
                if(String.IsNullOrEmpty(name))
                {
                    return BadRequest("Cannot read category by name without provided name");
                }

                var category = _categoryService.FindCategoryProductsByCategoryName(name);

                if(category == null)
                {
                    return NotFound($"There is no category by name: {name}");
                }

                return Ok(category);
            }
            catch (ArgumentException err)
            {
                return BadRequest(err.Message);
            }
            catch (Exception ex)
            {
                Log.Error($"Exception occured on CategoryController GetByName on name: {name}\n Stack Trace: {ex.StackTrace}");
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/<controller>
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult<Category> Post([FromBody]Category category)
        {
            if(category == null)
            {
                return BadRequest("Cannot create null category");
            }

            if (string.IsNullOrEmpty(category.Name))
            {
                return BadRequest("Category name is required.");
            }

            try
            {
                var cat = _categoryService.Create(category);

                if(cat == null)
                {
                    return BadRequest("Category creation failed");
                }

                return Ok(cat);
            }
            catch (ArgumentException err)
            {
                return BadRequest(err.Message);
            }
            catch (Exception ex)
            {
                Log.Error($"Exception occured on CategoryController Post on object: {category}\n Stack Trace: {ex.StackTrace}");
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<controller>/5
        [Authorize(Roles = "Administrator")]
        [HttpPut("{id}")]
        public ActionResult<Category> Put(int id, [FromBody] Category category)
        {
            if(category == null)
            {
                return BadRequest("You must provide category to update category");
            }

            if (id < 1 || id != category.ID)
            {
                return BadRequest("Parameter ID and Category ID must be the same.");
            }
            else if (string.IsNullOrEmpty(category.Name))
            {
                return BadRequest("Category name is required.");
            }

            try
            {
                var cat = _categoryService.Update(category);

                if(cat == null)
                {
                    return BadRequest("Category update has failed");
                }

                return Ok(cat);
            }
            catch (ArgumentException err)
            {
                return BadRequest(err.Message);
            }
            catch (Exception ex)
            {
                Log.Error($"Exception occured on CategoryController Put on object: {category}\n Stack Trace: {ex.StackTrace}");
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE api/<controller>/5
        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public ActionResult<Category> Delete(int id)
        {
            if (null == _categoryService.FindCategoryWithID(id))
            {
                return BadRequest("There is no Category with this ID.");
            }
            else
            {
                try
                {
                    var deletedCategory = _categoryService.Delete(id);

                    if (deletedCategory  != null)
                    {
                        return Ok(deletedCategory);
                    }
                    else
                    {
                        return NotFound("No such category exist");
                    }
                }
                catch (ArgumentException err)
                {
                    return BadRequest(err.Message);
                }
                catch (Exception ex)
                {
                    Log.Error($"Exception occured on CategoryController Delete on id: {id}\n Stack Trace: {ex.StackTrace}");
                    return StatusCode(500, ex.Message);
                }
            }
        }
    }
}
