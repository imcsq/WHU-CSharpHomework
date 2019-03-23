using System;
using System.Collections.Generic;

namespace HW5_OrderSystem2._0
{
    // 订单服务类。管理多份订单
    class OrderService
    {
        private List<Order> orders = new List<Order>(); //订单集

        // 通过顾客名获取顾客customer的所有订单。若不存在该用户的订单则抛出获取失败异常
        public List<Order> GetOrdersByCustomer(Customer customer)
        {
            List<Order> ret = new List<Order>();
            foreach (Order d in orders)
                if (d.customer.Equals(customer))
                    ret.Add(d);
            if (ret.Count == 0)
                throw new ItemNotFoundException("顾客", customer+"");
            else return ret;
        }

        // 通过商品类获取包含商品item的所有订单。若不存在包含商品item的订单则抛出获取失败异常
        public List<Order> GetOrdersByItem(Good item)
        {
            List<Order> ret = new List<Order>();
            foreach (Order d in orders)
                if (d.HasItem(item))
                    ret.Add(d);
            if (ret.Count == 0)
                throw new ItemNotFoundException("商品", item+"");
            else return ret;
        }

        // 通过订单ID获取对应订单。若不存在该ID对应的订单则抛出获取失败异常
        public Order GetOrderByID(int id)
        {
            foreach (Order d in orders)
                if (d.id == id)
                    return d;
            throw new ItemNotFoundException("订单ID", id.ToString());
        }

        // 通过订单ID删除对应订单。若不存在该ID对应的订单则抛出获取失败异常
        public void RemoveOrderByID(int id)
        {
            for (int i = 0; i < orders.Count; ++i)
                if (orders[i] != null && orders[i].id == id)
                {
                    orders.RemoveAt(i);
                    return;
                }
            throw new ItemNotFoundException("订单ID", id.ToString());
        }

        private bool CheckIDExisted(int id)
        {
            foreach (Order d in orders)
                if (d.id == id)
                    return true;
            return false;
        }

        // 通过订单集的下标获取对应订单。若不存在该下标对应的订单则抛出获取失败异常或超界异常
        public Order this[int index]
        {
            get => orders[index];
            // 若超界，将由系统出发 Index out of range错误。

            set
            {
                if (CheckIDExisted(value.id))
                    throw new ItemRepeatException("订单ID", value.id.ToString());
                orders[index] = value;
            }
        }

        // 向该订单服务中加入一个新的订单。若订单ID重复则抛出订单ID重复异常并汇报重复ID
        public void AddOrder(Order order)
        {
            if (CheckIDExisted(order.id))
                throw new ItemRepeatException("订单ID", order.id.ToString());
            this.orders.Add(order);
        }
    }
}
