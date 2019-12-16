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
    public class UsersController : Controller
    {

        private readonly IUserService _UserService;
        public UsersController(IUserService UserService)
        {
            _UserService = UserService;
        }
        // GET: api/<controller>
        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _UserService.ReadUsers();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            return _UserService.FindUserWithID(id);
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult<User> Post([FromBody]User User)
        {
            if (string.IsNullOrEmpty(User.FirstName))
            {
                return BadRequest("FirstName required.");
            }
            else if (string.IsNullOrEmpty(User.LastName))
            {
                return BadRequest("LastName required.");
            }
            else if (string.IsNullOrEmpty(User.Password))
            {
                return BadRequest("Password required.");
            }
            else if (string.IsNullOrEmpty(User.Email))
            {
                return BadRequest("Email required.");
            }
            else if (string.IsNullOrEmpty(User.Phone))
            {
                return BadRequest("Phone required.");
            }
            _UserService.Create(User);
            return Ok("Address successfully created.");
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public ActionResult<User> Put(int id, [FromBody] User User)
        {
            if (id < 1 || id != User.ID)
            {
                return BadRequest("Parameter ID and address ID must be the same.");
            }
                if (string.IsNullOrEmpty(User.FirstName))
                {
                    return BadRequest("FirstName required.");
                }
                else if (string.IsNullOrEmpty(User.LastName))
                {
                    return BadRequest("LastName required.");
                }
                else if (string.IsNullOrEmpty(User.Password))
                {
                    return BadRequest("Password required.");
                }
                else if (string.IsNullOrEmpty(User.Email))
                {
                    return BadRequest("Email required.");
                }
                else if (string.IsNullOrEmpty(User.Phone))
                {
                    return BadRequest("Phone required.");
                }
                _UserService.Update(User);
            return Ok("Address was successfully updated.");
        }

        // DELETE api/<controller>/5
        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public ActionResult<User> Delete(int id)
        {
            if (null == _UserService.FindUserWithID(id))
                return BadRequest("There is no Address with this ID.");
            else
            {
                _UserService.Delete(id);
                return Ok("Address deleted.");
            }
        }
    }
}
