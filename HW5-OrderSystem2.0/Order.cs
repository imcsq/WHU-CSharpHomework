using System;
using System.Collections.Generic;

namespace HW5_OrderSystem2._0
{
    // 订单类，记录每张订单的信息
    class Order : IComparable
    {
        private int _id;            //订单编码
        private Customer _customer;   //订单客户名
        private List<OrderDetail> items;    //订单内容

        public Order(int id, Customer customer, List<OrderDetail> items = null)
        {
            this._id = id;
            this._customer = customer;
            if (items != null)
                this.items = items;
            else this.items = new List<OrderDetail>();
        }

        // 通过物品名称修改订单中该物品的数量（对于已有的修改替换，对于没有的直接新建）
        public void ModifyItemNumber(Good item, int val)
        {
            foreach (OrderDetail d in items)
                if (d.item.Equals(item))
                {
                    d.num = val;
                    return;
                }
            items.Add(new OrderDetail(item, val));
        }

        public int id { get => _id; }               //订单号，不可修改
        public Customer customer { get => _customer; }//顾客，不可修改（？）

        // 打印整张订单信息的所有商品
        public void ShowAllDetails()
        {
            Console.WriteLine("订单" + _id + "共" + items.Count + "个商品：");
            foreach (OrderDetail d in items)
                Console.WriteLine(d);
        }

        // 判断名为name的商品是否在本订单中（便于通过商品名索引订单）
        public bool HasItem(Good item)
        {
            foreach (OrderDetail d in items)
                if (d.item.Equals(item))
                    return true;
            return false;
        }

        // 通过商品名称获取商品name在本订单中的详情。若不存在该商品则抛出获取失败异常
        public int GetItemNumber(Good item)
        {
            foreach (OrderDetail d in items)
                if (d.item.Equals(item))
                    return d.num;
            throw new ItemNotFoundException("商品", item.ToString());
        }

        // 返回本订单的总额
        public double totalPrice
        {
            get
            {
                double tot = 0;
                items.ForEach((obj) => tot += obj.detailPrice);
                return tot;
            }
        }

        // 两订单ID相同则认为两订单相同
        public override bool Equals(object obj) => obj is Order o && o.id == this.id;

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString() => "订单号：" + this._id + "\t客户：" + this.customer;

        // 使用订单号作为compare
        public int CompareTo(object obj)
        {
            return id.CompareTo(((Order)obj).id);
        }
    }

}
