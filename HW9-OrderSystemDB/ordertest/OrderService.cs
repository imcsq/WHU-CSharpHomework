using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ordertest
{
    public class OrderService
    {
        public void Insert(Order order)
        {
            using (var db = new OrderDB())
            {
                db.Entry(order).State = EntityState.Added;
                db.SaveChanges();
            }
        }

        public void Remove(String orderId)
        {
            using (var db = new OrderDB())
            {
                var order = db.Order.Include("items").SingleOrDefault(o => o.Id == orderId);
                db.OrderItem.RemoveRange(order.Items);
                db.Order.Remove(order);
                db.SaveChanges();
            }
        }

        public Order GetOrder(String id)
        {
            using (var db = new OrderDB())
            {
                return db.Order.Include("items").SingleOrDefault(order => order.Id == id);
            }
        }

        public List<Order> GetAll()
        {
            using (var db = new OrderDB())
            {
                return db.Order.Include("items").ToList<Order>();
            }
        }

        public List<Order> GetByCustormer(String custormer)
        {
            using (var db = new OrderDB())
            {
                return db.Order.Include("items").Where(order => order.Customer.Equals(custormer)).ToList<Order>();
            }
        }

        public List<Order> GetByGoods(String good)
        {
            using (var db = new OrderDB())
            {
                return db.Order.Include("items").Where(order => order.Items.Where(item => item.Product.Equals(good)).Count() > 0).ToList<Order>();
            }
        }
    }
}
