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
    public class InvoicesController : Controller
    {

        private readonly IInvoiceService _InvoiceService;
        public InvoicesController(IInvoiceService InvoiceService)
        {
            _InvoiceService = InvoiceService ?? throw new ArgumentNullException(nameof(InvoiceService));
        }
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Invoice> Get()
        {
            return _InvoiceService.ReadInvoices();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public ActionResult<Invoice> Get(int id)
        {
            return _InvoiceService.FindInvoiceWithID(id);
        }

        // POST api/<controller>
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult<Invoice> Post([FromBody]Invoice Invoice)
        {
            if (Invoice.date == null)
            {
                return BadRequest("Date required.");
            }
            _InvoiceService.Create(Invoice);
            return Ok("Invoice successfully created.");
        }

        // PUT api/<controller>/5
        [Authorize(Roles = "Administrator")]
        [HttpPut("{id}")]
        public ActionResult<Invoice> Put(int id, [FromBody] Invoice Invoice)
        {
            if (id < 1 || id != Invoice.ID)
            {
                return BadRequest("Parameter ID and Invoice ID must be the same.");
            }
            else if (Invoice.date == null)
            {
                return BadRequest("Date required.");
            }
            
            _InvoiceService.Update(Invoice);
            return Ok("Invoice was successfully updated.");
        }

        // DELETE api/<controller>/5
        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public ActionResult<Invoice> Delete(int id)
        {
            if (null == _InvoiceService.FindInvoiceWithID(id))
                return BadRequest("There is no Invoice with this ID.");
            else
            {
                _InvoiceService.Delete(id);
                return Ok("Invoice deleted.");
            }
        }
    }
}
