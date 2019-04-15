using Microsoft.VisualStudio.TestTools.UnitTesting;
using ordertest;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ordertest.Tests
{
    [TestClass()]
    public class OrderServiceTests
    {
        //[TestMethod()]
        //public void OrderServiceTest()
        //{
        //    Assert.Fail();
        //}

        // 测试是否能成功插入一个全新的订单
        [TestMethod()]
        public void AddOrderTest_NewOrder()
        {
            try
            {
                OrderService sys = new OrderService();
                sys.AddOrder(new Order(123, new Customer(123, "abc")));
            }
            catch
            {
                Assert.Fail();
            }
        }

        // 测试当插入重复订单时是否会成功发现错误并报异常
        [TestMethod()]
        public void AddOrderTest_Duplicate()
        {
            try
            {
                OrderService sys = new OrderService();
                Order o1 = new Order(123, new Customer(123, "abc"));
                Order o2 = new Order(123, new Customer(123, "abc"));
                sys.AddOrder(o1);
                sys.AddOrder(o2);
            }
            catch
            {
                return;
            }
            Assert.Fail();
        }

        // 测试是否能成功更新一个已经存在的订单的数据
        [TestMethod()]
        public void UpdateTest_UpdatedOrder()
        {
            try
            {
                OrderService sys = new OrderService();
                Order o1 = new Order(123, new Customer(123, "abc"));
                sys.AddOrder(o1);
                o1.AddDetails(new OrderDetail(new Goods(1, "apple", 2), 2));
                sys.Update(o1);
            }
            catch
            {
                Assert.Fail();
            }
        }

        // 测试是否能成功插入一个不存在的订单（转为单纯的插入操作）
        [TestMethod()]
        public void UpdateTest_NewOrder()
        {
            OrderService sys = new OrderService();
            Order o1 = new Order(123, new Customer(123, "abc"));
            sys.Update(o1);
            Assert.IsTrue(sys.QueryByCustomerName("abc").Contains(o1));
        }

        // 测试是否能成功通过存在于系统中的订单ID找到该订单
        [TestMethod()]
        public void GetByIdTest_Existed()
        {
            OrderService sys = new OrderService();
            Order o1 = new Order(123, new Customer(123, "abc"));
            sys.Update(o1);
            Assert.IsNotNull(sys.GetById(123));
        }

        // 测试当输入不存在于系统中的订单ID时是否返回NULL
        [TestMethod()]
        public void GetByIdTest_NotExisted()
        {
            OrderService sys = new OrderService();
            Order o1 = new Order(123, new Customer(123, "abc"));
            Assert.IsNull(sys.GetById(123));
        }

        // 测试是否能成功根据存在于系统中的订单ID删除该订单
        [TestMethod()]
        public void RemoveOrderTest_Existed()
        {
            OrderService sys = new OrderService();
            Order o1 = new Order(123, new Customer(123, "abc"));
            sys.AddOrder(o1);
            Assert.IsNotNull(sys.GetById(123));
            sys.RemoveOrder(123);
            Assert.IsNull(sys.GetById(123));
        }

        // 测试输入一个不存在于系统中的订单ID是否会导致系统崩溃
        [TestMethod()]
        public void RemoveOrderTest_NotExisted()
        {
            try
            {
                OrderService sys = new OrderService();
                Order o1 = new Order(123, new Customer(123, "abc"));
                sys.RemoveOrder(123);
                Assert.IsNull(sys.GetById(123));
            }
            catch
            {
                Assert.Fail();
            }
        }

        // 测试是否能导出所有插入的订单
        [TestMethod()]
        public void QueryAllTest_Normal()
        {
            OrderService sys = new OrderService();
            Order o1 = new Order(123, new Customer(123, "abc"));
            Order o2 = new Order(124, new Customer(123, "abc"));
            Order o3 = new Order(125, new Customer(124, "ab"));
            o2.AddDetails(new OrderDetail(new Goods(1, "apple", 1), 2));
            o3.AddDetails(new OrderDetail(new Goods(2, "banana", 2), 3));
            sys.AddOrder(o1);
            sys.AddOrder(o2);
            sys.AddOrder(o3);
            List<Order> list = new List<Order>();
            list.Add(o1);
            list.Add(o2);
            list.Add(o3);
            CollectionAssert.AreEqual(sys.QueryAll(), list);
        }

        // 测试系统中无订单时是否能正确返回一个空列表
        [TestMethod()]
        public void QueryAllTest_Empty()
        {
            OrderService sys = new OrderService();
            List<Order> list = new List<Order>();
            CollectionAssert.AreEqual(sys.QueryAll(), list);
        }

        // 测试是否能根据商品名成功找到包含该商品的所有订单
        [TestMethod()]
        public void QueryByGoodsNameTest_ExistedGood()
        {
            OrderService sys = new OrderService();
            Order o1 = new Order(123, new Customer(123, "abc"));
            Order o2 = new Order(124, new Customer(123, "abc"));
            Order o3 = new Order(125, new Customer(124, "ab"));
            Order o4 = new Order(126, new Customer(124, "ab"));
            Goods g1 = new Goods(1, "apple", 1);
            Goods g2 = new Goods(2, "banana", 2);
            o2.AddDetails(new OrderDetail(g1, 2));
            o3.AddDetails(new OrderDetail(g2, 3));
            o4.AddDetails(new OrderDetail(g1, 4));
            sys.AddOrder(o1);
            sys.AddOrder(o2);
            sys.AddOrder(o3);
            sys.AddOrder(o4);
            List<Order> list = new List<Order>();
            list.Add(o2);
            list.Add(o4);
            CollectionAssert.AreEqual(sys.QueryByGoodsName("apple"), list);
        }

        // 测试当输入一个不存在于系统中的商品名时系统是否能正常运行并返回空列表
        [TestMethod()]
        public void QueryByGoodsNameTest_NotExistedGood()
        {
            OrderService sys = new OrderService();
            Order o1 = new Order(123, new Customer(123, "abc"));
            Order o2 = new Order(124, new Customer(123, "abc"));
            Order o3 = new Order(125, new Customer(124, "ab"));
            Order o4 = new Order(126, new Customer(124, "ab"));
            Goods g1 = new Goods(1, "apple", 1);
            Goods g2 = new Goods(2, "banana", 2);
            o2.AddDetails(new OrderDetail(g1, 2));
            o3.AddDetails(new OrderDetail(g2, 3));
            o4.AddDetails(new OrderDetail(g1, 4));
            sys.AddOrder(o1);
            sys.AddOrder(o2);
            sys.AddOrder(o3);
            sys.AddOrder(o4);
            List<Order> list = new List<Order>();
            CollectionAssert.AreEqual(sys.QueryByGoodsName("phone"), list);
        }

        // 测试是否能根据订单包含的物品数量成功找到符合要求的所有订单
        [TestMethod()]
        public void QueryByTotalAmountTest()
        {
            OrderService sys = new OrderService();
            Order o1 = new Order(123, new Customer(123, "abc"));
            Order o2 = new Order(124, new Customer(123, "abc"));
            Order o3 = new Order(125, new Customer(124, "ab"));
            Order o4 = new Order(126, new Customer(124, "ab"));
            Goods g1 = new Goods(1, "apple", 1);
            Goods g2 = new Goods(2, "banana", 2);
            o2.AddDetails(new OrderDetail(g1, 2));
            o3.AddDetails(new OrderDetail(g2, 3));
            o4.AddDetails(new OrderDetail(g1, 4));
            sys.AddOrder(o1);
            sys.AddOrder(o2);
            sys.AddOrder(o3);
            sys.AddOrder(o4);
            List<Order> list = new List<Order>();
            list.Add(o2);
            list.Add(o3);
            list.Add(o4);
            CollectionAssert.AreEqual(sys.QueryByTotalAmount(1), list);
        }

        // 测试是否能根据鹅湖名称成功找到该客户的所有订单
        [TestMethod()]
        public void QueryByCustomerNameTest_Existed()
        {
            OrderService sys = new OrderService();
            Order o1 = new Order(123, new Customer(123, "abc"));
            Order o2 = new Order(124, new Customer(123, "abc"));
            Order o3 = new Order(125, new Customer(124, "ab"));
            Order o4 = new Order(126, new Customer(124, "ab"));
            Goods g1 = new Goods(1, "apple", 1);
            Goods g2 = new Goods(2, "banana", 2);
            o2.AddDetails(new OrderDetail(g1, 2));
            o3.AddDetails(new OrderDetail(g2, 3));
            o4.AddDetails(new OrderDetail(g1, 4));
            sys.AddOrder(o1);
            sys.AddOrder(o2);
            sys.AddOrder(o3);
            sys.AddOrder(o4);
            List<Order> list = new List<Order>();
            list.Add(o1);
            list.Add(o2);
            CollectionAssert.AreEqual(sys.QueryByCustomerName("abc"), list);
        }

        // 测试当输入一个不存在于系统中的用户名时系统是否能正常运行并返回空列表
        [TestMethod()]
        public void QueryByCustomerNameTest_NotExistedCustomer()
        {
            OrderService sys = new OrderService();
            Order o1 = new Order(123, new Customer(123, "abc"));
            Order o2 = new Order(124, new Customer(123, "abc"));
            Order o3 = new Order(125, new Customer(124, "ab"));
            Order o4 = new Order(126, new Customer(124, "ab"));
            Goods g1 = new Goods(1, "apple", 1);
            Goods g2 = new Goods(2, "banana", 2);
            o2.AddDetails(new OrderDetail(g1, 2));
            o3.AddDetails(new OrderDetail(g2, 3));
            o4.AddDetails(new OrderDetail(g1, 4));
            sys.AddOrder(o1);
            sys.AddOrder(o2);
            sys.AddOrder(o3);
            sys.AddOrder(o4);
            List<Order> list = new List<Order>();
            CollectionAssert.AreEqual(sys.QueryByCustomerName("a"), list);
        }

        // 测试系统排序功能是否正确
        [TestMethod()]
        public void SortTest()
        {
            OrderService sys = new OrderService();
            Order o1 = new Order(123, new Customer(123, "abc"));
            Order o2 = new Order(124, new Customer(123, "abc"));
            Order o3 = new Order(125, new Customer(124, "ab"));
            Order o4 = new Order(126, new Customer(124, "ab"));
            Goods g1 = new Goods(1, "apple", 1);
            Goods g2 = new Goods(2, "banana", 2);
            o2.AddDetails(new OrderDetail(g1, 2));
            o3.AddDetails(new OrderDetail(g2, 3));
            o4.AddDetails(new OrderDetail(g1, 4));
            sys.AddOrder(o3);
            sys.AddOrder(o2);
            sys.AddOrder(o1);
            sys.AddOrder(o4);
            List<Order> list = new List<Order>();
            list.Add(o1);
            list.Add(o2);
            list.Add(o3);
            list.Add(o4);
            list.Sort();
            sys.Sort((i1, i2) => i1.Id - i2.Id);
            CollectionAssert.AreEqual(sys.QueryAll(), list);
        }

        // 测试系统导入导出功能是否正确
        [TestMethod()]
        public void ExportImportTest()
        {
            OrderService sys = new OrderService();
            Order o1 = new Order(123, new Customer(123, "abc"));
            Order o2 = new Order(124, new Customer(123, "abc"));
            Order o3 = new Order(125, new Customer(124, "ab"));
            Order o4 = new Order(126, new Customer(124, "ab"));
            Goods g1 = new Goods(1, "apple", 1);
            Goods g2 = new Goods(2, "banana", 2);
            o2.AddDetails(new OrderDetail(g1, 2));
            o3.AddDetails(new OrderDetail(g2, 3));
            o4.AddDetails(new OrderDetail(g1, 4));
            sys.AddOrder(o3);
            sys.AddOrder(o2);
            sys.AddOrder(o1);
            sys.AddOrder(o4);
            sys.Export("data.xml");

            OrderService newsys = new OrderService();
            newsys.Import("data.xml");

            CollectionAssert.AreEqual(sys.QueryAll(), newsys.QueryAll());
        }
    }
}