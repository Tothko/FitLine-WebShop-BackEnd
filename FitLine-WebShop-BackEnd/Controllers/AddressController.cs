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
    public class AddressController : Controller
    {

        private readonly IAddressService _AddressService;
        public AddressController(IAddressService AddressService)
        {
            _AddressService = AddressService;
        }
        // GET: api/<controller>
        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public IEnumerable<Address> Get()
        {
            return _AddressService.ReadAddresses();
        }

        // GET api/<controller>/5
        [Authorize]
        [HttpGet("{id}")]   
        public ActionResult<Address> Get(int id)
        {
            return _AddressService.FindAddressWithID(id);
        }

        // POST api/<controller>
        [Authorize]
        [HttpPost]
        public ActionResult<Address> Post([FromBody]Address address)
        {
            if (string.IsNullOrEmpty(address.City))
            {
                return BadRequest("City required.");
            }
            else if (string.IsNullOrEmpty(address.Country))
            {
                return BadRequest("Country required.");
            }
            else if (string.IsNullOrEmpty(address.PostalCode))
            {
                return BadRequest("PostalCode required.");
            }
            else if (string.IsNullOrEmpty(address.BuildingNumber))
            {
                return BadRequest("BuildingNumber required.");
            }
            else if (string.IsNullOrEmpty(address.Floor))
            {
                return BadRequest("Floor required.");
            }
            _AddressService.Create(address);
            return Ok("Address successfully created.");
        }

        // PUT api/<controller>/5
        [Authorize]
        [HttpPut("{id}")]
        public ActionResult<Address> Put(int id, [FromBody] Address address)
        {
            if (id < 1 || id != address.ID)
            {
                return BadRequest("Parameter ID and address ID must be the same.");
            }
            else if (string.IsNullOrEmpty(address.City))
            {
                return BadRequest("City required.");
            }
            else if (string.IsNullOrEmpty(address.Country))
            {
                return BadRequest("Country required.");
            }
            else if (string.IsNullOrEmpty(address.PostalCode))
            {
                return BadRequest("PostalCode required.");
            }
            else if (string.IsNullOrEmpty(address.BuildingNumber))
            {
                return BadRequest("BuildingNumber required.");
            }
            else if (string.IsNullOrEmpty(address.Floor))
            {
                return BadRequest("Floor required.");
            }
            _AddressService.Update(address);
            return Ok("Address was successfully updated.");
        }

        // DELETE api/<controller>/5
        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public ActionResult<Address> Delete(int id)
        {
            if (null == _AddressService.FindAddressWithID(id))
                return BadRequest("There is no Address with this ID.");
            else
            {
                _AddressService.Delete(id);
                return Ok("Address deleted.");
            }
        }
    }
}
