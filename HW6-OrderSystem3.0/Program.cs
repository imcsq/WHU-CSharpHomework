using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace HW5_OrderSystem2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderService sys = new OrderService();

            try
            {
                Customer c1 = new Customer("xiaoxie", "xie", "15900000000");
                Customer c2 = new Customer("xiaochen", "chen", "15800000000");

                Good macbook = new Good("苹果笔记本", "MacBook", 9999);
                Good iphone = new Good("苹果手机", "iPhone", 5200);
                Good ipad = new Good("苹果平板", "iPad", 2520);
                Good itouch = new Good("苹果播放器", "iTouch", 1520.5);

                Order o1 = new Order(1903230003, c1);
                Order o2 = new Order(1903230004, c2);
                Order o3 = new Order(1903230001, c2);
                Order o4 = new Order(1903230005, c1);
                Order o5 = new Order(1903230002, c1);

                o1.ModifyItemNumber(macbook, 2);
                o2.ModifyItemNumber(ipad, 1);
                o2.ModifyItemNumber(itouch, 2);
                o3.ModifyItemNumber(macbook, 1);
                o3.ModifyItemNumber(iphone, 2);
                o4.ModifyItemNumber(ipad, 1);
                o4.ModifyItemNumber(iphone, 1);
                o5.ModifyItemNumber(itouch, 5);

                sys.AddOrder(o1);
                sys.AddOrder(o2);
                sys.AddOrder(o3);
                sys.AddOrder(o4);
                sys.AddOrder(o5);
                //sys.AddOrder(o5); // will throw exception. repeat same order.

                // sort by order id. implement by IComparable.
                List<Order> l1 = sys.GetOrdersByCustomer(c1);
                Console.WriteLine(c1 + "用户的所有订单（按订单号递增排序）");
                l1.Sort();
                l1.ForEach((obj) => Console.WriteLine(obj));
                
                // sort by total account descending. implement lambda expr.
                List<Order> l2 = sys.GetOrdersByCustomer(c2);
                Console.WriteLine(c2 + "用户的所有订单（按金额递增排序）");
                l2.Sort((obj1, obj2) => { return (obj1.totalPrice > obj2.totalPrice) ? 1 : 0; });
                l2.ForEach((obj) => Console.WriteLine(obj + "\t总金额：" + obj.totalPrice));

                // sort by order id descending. implement by linq.
                Console.WriteLine(c1 + "用户的所有订单（按订单号递减排序）");
                foreach (var item in from items in l1 orderby items.id descending select items)
                    Console.WriteLine(item);

                // sort by total account. implement by linq.
                Console.WriteLine(c2 + "用户的所有订单（按金额递减排序）");
                foreach (var item in from items in l2 orderby items.totalPrice descending select items)
                    Console.WriteLine(item + "\t总金额：" + item.totalPrice);

                // export all orders to a xml file.
                sys.ExportAllOrdersToXML("allorders.xml");
                Console.WriteLine("导出成功");

                // import all orders from a xml file.
                sys.ImportAllOrdersToXML("allorders.xml");
                Console.WriteLine("导入成功");

                // (replay some work to check whether importing works well. well done.)
                Console.WriteLine(c1 + "用户的所有订单（按订单号递减排序）");
                foreach (var item in from items in l1 orderby items.id descending select items)
                    Console.WriteLine(item);
                Console.WriteLine(c2 + "用户的所有订单（按金额递减排序）");
                foreach (var item in from items in l2 orderby items.totalPrice descending select items)
                    Console.WriteLine(item + "\t总金额：" + item.totalPrice);
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
            catch (ValueError e)
            {
                Console.WriteLine("错误：" + e.Message + "（字段：" + e.Data + "，要求：" + e.description + "）");
            }
            catch (Exception e) //处理报告包括输入数据Parse异常在内的所有其他系统异常。
            {
                Console.WriteLine("错误：" + "其他错误");
                Console.WriteLine(e);
            }
        }
    }

}
