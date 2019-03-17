using System;
using System.Collections.Generic;

namespace HW4_OrderSystem
{
    // 找不到项目异常，用于汇报找不到某订单或某商品等。带两个参数，寻键方法 和 键值
    public class ItemNotFoundException : ApplicationException
    {
        private string _indexMethod, _indexKey;
        public string indexMethod { get => _indexMethod; }
        public string indexKey { get => _indexKey; }

        public ItemNotFoundException(string indexMethod,  string indexKey)
         : base("未找到所需要的项目") {
            this._indexMethod = indexMethod;
            this._indexKey = indexKey;
        }
    }

    // 键值重复异常，用于汇报ID等有唯一要求的键发生重复。带两个参数，寻键方法 和 键值
    public class ItemRepeatException : ApplicationException
    {
        private string _indexMethod, _indexKey;
        public string indexMethod { get => _indexMethod; }
        public string indexKey { get => _indexKey; }

        public ItemRepeatException(string indexMethod, string indexKey)
         : base("键值重复")
        {
            this._indexMethod = indexMethod;
            this._indexKey = indexKey;
        }
    }

    // 订单详情类，记录购买的某种商品和数量。
    class OrderDetail
    {
        private string _name;
        private int _num;

        public string name { get => this._name; }                       //名称为只读属性，不支持修改
        public int num { get => this._num; set => this._num = value; }  //数量为读写属性，支持修改

        public OrderDetail(string name, int num)
        {
            this._name = name; 
            this._num = num;
        }

        override public string ToString() => "名称：" + this._name + "\t数量：" + this._num;  //便于打印
    }

    // 订单类，记录每张订单的信息
    class Order
    {
        private int _id;            //订单编码
        private string _customer;   //订单客户名
        private List<OrderDetail> items;    //订单内容

        public Order(int id, string customer, List<OrderDetail> items = null)
        {
            this._id = id;
            this._customer = customer;
            if (items != null)
                this.items = items;
            else this.items = new List<OrderDetail>();
        }

        // 通过物品名称修改订单中该物品的数量（对于已有的修改替换，对于没有的直接新建）
        public void ModifyItemNumber(string name, int val)
        {
            foreach (OrderDetail d in items)
                if (d.name == name)
                {
                    d.num = val;
                    return;
                }
            items.Add(new OrderDetail(name, val));
        }

        public int id { get => _id; }               //订单号，不可修改
        public string customer { get => _customer; }//顾客名，不可修改（？）

        override public string ToString() => "订单号：" + this._id + "\t客户：" + this.customer;

        // 打印整张订单信息的所有商品
        public void ShowAllDetails()
        {
            Console.WriteLine("订单" + _id + "共" + items.Count + "个商品：");
            foreach (OrderDetail d in items)
                Console.WriteLine(d);
        }

        // 判断名为name的商品是否在本订单中（便于通过商品名索引订单）
        public bool HasItem(string name)
        {
            foreach (OrderDetail d in items)
                if (d.name == name)
                    return true;
            return false;
        }

        // 通过商品名称获取商品name在本订单中的详情。若不存在该商品则抛出获取失败异常
        public int GetItemNumber(string name)
        {
            foreach (OrderDetail d in items)
                if (d.name == name)
                    return d.num;
            throw new ItemNotFoundException("商品名称", name);
        }
    }

    // 订单服务类。管理多份订单
    class OrderService
    {
        private List<Order> orders = new List<Order>(); //订单集

        // 通过顾客名获取顾客customer的所有订单。若不存在该用户的订单则抛出获取失败异常
        public List<Order> GetOrdersByCustomer(string customer)
        {
            List<Order> ret = new List<Order>();
            foreach (Order d in orders)
                if (d.customer == customer)
                    ret.Add(d);
            if (ret.Count == 0)
                throw new ItemNotFoundException("顾客名称", customer);
            else return ret;
        }

        // 通过商品类获取包含商品item的所有订单。若不存在包含商品item的订单则抛出获取失败异常
        public List<Order> GetOrdersByItem(string item)
        {
            List<Order> ret = new List<Order>();
            foreach (Order d in orders)
                if (d.HasItem(item))
                    ret.Add(d);
            if (ret.Count == 0)
                throw new ItemNotFoundException("商品名称", item);
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

            set {
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

    class Program
    {
        static void Main(string[] args)
        {
            OrderService sys = new OrderService();

            string customer, itemname;
            int id, num;
            Order tmporder;

            while (true)
            {
                Console.WriteLine("输入0插入新订单");
                Console.WriteLine("输入1通过订单ID查找目标订单");
                Console.WriteLine("输入2通过顾客姓名查找目标订单");
                Console.WriteLine("输入3通过商品名称查找目标订单");
                Console.WriteLine("输入4通过订单ID删除订单");
                Console.WriteLine("输入5通过订单ID修改订单");
                Console.Write("请输入指令：");

                try
                {
                    switch (Console.ReadLine())
                    {
                        case "0":
                            Console.Write("请输入新插入的订单的订单号：");
                            id = int.Parse(Console.ReadLine());
                            Console.Write("请输入新插入的订单的顾客姓名：");
                            customer = Console.ReadLine();
                            Console.Write("请输入新插入的订单的商品总数：");
                            id = int.Parse(Console.ReadLine());
                            tmporder = new Order(id, customer);
                            for(int i = 1; i <= id; ++i)
                            {
                                Console.Write("请输入第" + i + "种商品名称（重名将直接覆盖之前的输入）：");
                                itemname = Console.ReadLine();
                                Console.Write("请输入第" + i + "种商品" + itemname + "数量：");
                                num = int.Parse(Console.ReadLine());
                                tmporder.ModifyItemNumber(itemname, num);
                            }
                            sys.AddOrder(tmporder);
                            tmporder = null;
                            break;
                        case "1":
                            Console.Write("请输入希望查找的订单的ID：");
                            id = int.Parse(Console.ReadLine());
                            sys.GetOrderByID(id).ShowAllDetails();
                            break;
                        case "2":
                            Console.Write("请输入希望查询的订单的顾客姓名：");
                            customer = Console.ReadLine();
                            foreach (Order d in sys.GetOrdersByCustomer(customer))
                                d.ShowAllDetails();
                            break;
                        case "3":
                            Console.Write("请输入希望查询的订单具有的商品种类：");
                            itemname = Console.ReadLine();
                            foreach (Order d in sys.GetOrdersByItem(itemname))
                                d.ShowAllDetails();
                            break;
                        case "4":
                            Console.Write("请输入希望删除的订单的ID：");
                            id = int.Parse(Console.ReadLine());
                            sys.RemoveOrderByID(id);
                            break;
                        case "5":
                            Console.Write("请输入希望修改的订单的ID：");
                            // ……不再多写复杂的IO逻辑内容
                            break;
                        default: Console.WriteLine("错误的指令。"); break;
                    }
                }
                // catch将捕获上述操作中发生的所有类型的异常，并带有合适的异常说明。
                catch (ItemNotFoundException e) //处理报告希望通过某类关键字查询但提供的关键字对应的项目不存在的异常
                {
                    Console.WriteLine("错误：" + e.Message + "（索引方式：" + e.indexMethod + "，键值：" + e.indexKey + "）");
                }
                catch (ItemRepeatException e) //处理报告某具有唯一性要求的关键字（如商品ID）发生重复的异常
                {
                    Console.WriteLine("错误：" + e.Message + "（索引方式：" + e.indexMethod + "，键值：" + e.indexKey + "）");
                }
                catch (IndexOutOfRangeException e) //处理报告List的越界异常及其他数组越界错误
                {
                    Console.WriteLine("错误：" + "越界错误");
                    Console.WriteLine(e);
                }
                catch (Exception e) //处理报告包括输入数据Parse异常在内的所有其他系统异常。
                {
                    Console.WriteLine("错误：" + "其他错误");
                    Console.WriteLine(e);
                }

                Console.WriteLine("");
            }
        }
    }
}
