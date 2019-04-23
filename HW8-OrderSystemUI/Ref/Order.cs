using System;
using System.Collections.Generic;
using System.Linq;

namespace HW5_OrderSystem2._0
{
    // 订单类，记录每张订单的信息
    [Serializable]
    public class Order : IComparable
    {
        public List<OrderDetail> items;    //订单内容

        public Order() : this(-1, null, null) { }
        public Order(int id, Customer customer, List<OrderDetail> items = null)
        {
            this.id = id;
            this.customer = customer;
            if (items != null)
                this.items = items;
            else this.items = new List<OrderDetail>();
        }

        // 通过物品名称修改订单中该物品的数量（对于已有的修改替换，对于没有的直接新建）【使用Linq重写】
        public void ModifyItemNumber(Good item, int val)
        {
            var targetd = items.Where(i => i.Equals(item));
            if (targetd.Any())
            {
                targetd.First().num = val;
                return;
            }
            items.Add(new OrderDetail(item, val));
        }

        public int id { get; set; }             //订单号，不可修改
        public Customer customer { get; set; }  //顾客，不可修改（？）

        // 打印整张订单信息的所有商品
        public void ShowAllDetails()
        {
            Console.WriteLine("订单" + id + "共" + items.Count + "个商品：");
            foreach (OrderDetail d in items)
                Console.WriteLine(d);
        }

        // 判断名为name的商品是否在本订单中（便于通过商品名索引订单）【使用Linq重写】
        public bool HasItem(Good item)
        {
            return items.Any(i => i.Equals(item));
        }

        // 通过商品名称获取商品name在本订单中的详情。若不存在该商品则抛出获取失败异常【使用Linq重写】
        public int GetItemNumber(Good item)
        {
            var targeti = items.Where(d => d.item.Equals(item));
            if (targeti.Any())
                return targeti.First().num;
            throw new ItemNotFoundException("商品", item.ToString());
        }

        // 返回本订单的总额【使用Linq重写】
        public double totalPrice
        {
            get => items.Sum(obj => obj.detailPrice);
        }

        // 两订单ID相同则认为两订单相同
        public override bool Equals(object obj) => obj is Order o && o.id == this.id;

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString() => "订单号：" + this.id + "\t客户：" + this.customer;

        // 使用订单号作为compare
        public int CompareTo(object obj)
        {
            return id.CompareTo(((Order)obj).id);
        }
    }

}
