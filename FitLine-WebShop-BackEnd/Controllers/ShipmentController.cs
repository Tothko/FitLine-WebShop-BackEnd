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
    public class ShipmentController : Controller
    {

        private readonly IShipmentService _ShipmentService;
        public ShipmentController(IShipmentService ShipmentService)
        {
            _ShipmentService = ShipmentService;
        }
        // GET: api/<controller>
        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public IEnumerable<Shipment> Get()
        {
            return _ShipmentService.ReadShipments();
        }

        // GET api/<controller>/5
        
        [HttpGet("{id}")]
        public ActionResult<Shipment> Get(int id)
        {
            return _ShipmentService.FindShipmentWithID(id);
        }

        // POST api/<controller>
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult<Shipment> Post([FromBody]Shipment Shipment)
        {
            if (Shipment.Date == null)
            {
                return BadRequest("Date required.");
            }
            _ShipmentService.Create(Shipment);
            return Ok("Address successfully created.");
        }

        // PUT api/<controller>/5
        [Authorize(Roles = "Administrator")]
        [HttpPut("{id}")]
        public ActionResult<Shipment> Put(int id, [FromBody] Shipment Shipment)
        {
            if (id < 1 || id != Shipment.ID)
            {
                return BadRequest("Parameter ID and address ID must be the same.");
            }
            else if (Shipment.Date == null)
            {
                return BadRequest("Date required.");
            }
            _ShipmentService.Update(Shipment);
            return Ok("Address was successfully updated.");
        }

        // DELETE api/<controller>/5
        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public ActionResult<Shipment> Delete(int id)
        {
            if (null == _ShipmentService.FindShipmentWithID(id))
                return BadRequest("There is no Shipment with this ID.");
            else
            {
                _ShipmentService.Delete(id);
                return Ok("Shipment deleted.");
            }
        }
    }
}
