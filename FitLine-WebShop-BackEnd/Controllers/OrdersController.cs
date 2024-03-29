﻿using System;
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
    public class OrdersController : Controller
    {

        private readonly IOrderService _OrderService;
        public OrdersController(IOrderService OrderService)
        {
            _OrderService = OrderService;
        }
        // GET: api/<controller>
        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public IEnumerable<Order66> Get()
        {
            return _OrderService.ReadOrders();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public ActionResult<Order66> Get(int id)
        {
            return _OrderService.FindOrder66WithID(id);
        }

        // POST api/<controller>
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult<Order66> Post([FromBody]Order66 Order66)
        {
            if (Order66.DateOfPlacement == null)
            {
                return BadRequest("Date required.");
            }
           

            _OrderService.Create(Order66);
            return Ok("Order66 successfully created.");
        }

        // PUT api/<controller>/5
        [Authorize(Roles = "Administrator")]
        [HttpPut("{id}")]
        public ActionResult<Order66> Put(int id, [FromBody] Order66 Order66)
        {
            if (id < 1 || id != Order66.ID)
            {
                return BadRequest("Parameter ID and Order66 ID must be the same.");
            }
            else if (Order66.DateOfPlacement == null)
            {
                return BadRequest("Date required.");
            }
       
            _OrderService.Update(Order66);
            return Ok("Order66 was successfully updated.");
        }

        // DELETE api/<controller>/5
        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public ActionResult<Order66> Delete(int id)
        {
            if (null == _OrderService.FindOrder66WithID(id))
                return BadRequest("There is no Order66 with this ID.");
            else
            {
                _OrderService.Delete(id);
                return Ok("Order66 deleted.");
            }
        }
    }
}
