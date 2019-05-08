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
    public class OrderItemsController : ControllerBase
    {
        private readonly OrderDB db;

        public OrderItemsController(OrderDB context)
        {
            db = context;
        }

        // GET api/orderitems
        [HttpGet]
        public ActionResult<List<OrderItem>> Get()
        {
            return db.OrderItem.ToList();
        }

        // GET api/orderitems/5
        [HttpGet("{id}")]
        public ActionResult<OrderItem> Get(String id)
        {
            return db.OrderItem.Find(id);
        }

        // POST api/orderitems
        [HttpPost]
        public ActionResult<OrderItem> Post(OrderItem item)
        {
            db.OrderItem.Add(item);
            db.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = item.Id }, item);
        }

        // PUT api/orderitems/5
        [HttpPut("{id}")]
        public ActionResult<OrderItem> Put(String id, OrderItem item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
            return NoContent();
        }

        // DELETE api/orderitems/5
        [HttpDelete("{id}")]
        public ActionResult<OrderItem> Delete(String id)
        {
            var item = db.OrderItem.Find(id);

            if (item == null)
            {
                return NotFound();
            }

            db.OrderItem.Remove(item);
            db.SaveChanges();
            return NoContent();
        }
    }
}
