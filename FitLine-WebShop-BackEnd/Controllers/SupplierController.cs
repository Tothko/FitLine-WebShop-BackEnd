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
    public class SupplierController : Controller
    {

        private readonly ISupplierService _SupplierService;
        public SupplierController(ISupplierService SupplierService)
        {
            _SupplierService = SupplierService;
        }
        // GET: api/<controller>
        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public IEnumerable<Supplier> Get()
        {
            return _SupplierService.ReadSuppliers();
        }

        // GET api/<controller>/>
        [Authorize(Roles = "Administrator")]
        [HttpGet("{id}")]
        public ActionResult<Supplier> Get(int id)
        {
            return _SupplierService.FindSupplierWithID(id);
        }

        // POST api/<controller>
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult<Supplier> Post([FromBody]Supplier Supplier)
        {
            if (string.IsNullOrEmpty(Supplier.Name))
            {
                return BadRequest("City required.");
            }
            else if (string.IsNullOrEmpty(Supplier.Phone))
            {
                return BadRequest("Country required.");
            }
            else if (string.IsNullOrEmpty(Supplier.Email))
            {
                return BadRequest("PostalCode required.");
            }
            _SupplierService.Create(Supplier);
            return Ok("Address successfully created.");
        }

        // PUT api/<controller>/5
        [Authorize(Roles = "Administrator")]
        [HttpPut("{id}")]
        public ActionResult<Address> Put(int id, [FromBody] Supplier Supplier)
        {
            if (id < 1 || id != Supplier.ID)
            {
                return BadRequest("Parameter ID and address ID must be the same.");
            }
            if (string.IsNullOrEmpty(Supplier.Name))
            {
                return BadRequest("City required.");
            }
            else if (string.IsNullOrEmpty(Supplier.Phone))
            {
                return BadRequest("Country required.");
            }
            else if (string.IsNullOrEmpty(Supplier.Email))
            {
                return BadRequest("PostalCode required.");
            }
            _SupplierService.Update(Supplier);
            return Ok("Address was successfully updated.");
        }

        // DELETE api/<controller>/5
        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public ActionResult<Address> Delete(int id)
        {
            if (null == _SupplierService.FindSupplierWithID(id))
                return BadRequest("There is no Supplier with this ID.");
            else
            {
                _SupplierService.Delete(id);
                return Ok("Supplier deleted.");
            }
        }
    }
}
