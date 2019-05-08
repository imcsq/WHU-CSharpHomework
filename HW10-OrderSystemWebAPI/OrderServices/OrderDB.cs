using System;
using System.Collections.Generic;
//using System.Data.Entity;
//using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW10_OrderSystemWebAPI
{
    public class OrderDB:DbContext
    {
        public OrderDB(DbContextOptions<OrderDB> options) : base(options) { }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
    
    }
}
