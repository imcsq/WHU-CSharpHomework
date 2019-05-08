using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HW10_OrderSystemWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly OrderDB db;
        
        public OrdersController(OrderDB  context)
        {
            db = context;
        }

        // GET api/orders
        [HttpGet]
        public ActionResult<List<Order>> Get()
        {
            return db.Order.ToList();
        }

        // GET api/orders/5
        [HttpGet("{id}")]
        public ActionResult<Order> Get(String id)
        {
            return db.Order.Find(id);
        }

        // POST api/orders
        [HttpPost]
        public ActionResult<Order> Post(Order order)
        {
            db.Order.Add(order);
            db.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = order.Id }, order);
        }

        // PUT api/orders/5
        [HttpPut("{id}")]
        public ActionResult<Order> Put(String id, Order order)
        {
            if (id != order.Id)
            {
                return BadRequest();
            }

            db.Entry(order).State = EntityState.Modified;
            db.SaveChanges();
            return NoContent();
        }

        // DELETE api/orders/5
        [HttpDelete("{id}")]
        public ActionResult<Order> Delete(String id)
        {
            var order = db.Order.Find(id);

            if (order == null)
            {
                return NotFound();
            }

            db.Order.Remove(order);
            db.SaveChanges();
            return NoContent();
        }
    }
}
