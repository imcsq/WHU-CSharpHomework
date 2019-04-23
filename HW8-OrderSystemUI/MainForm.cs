using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HW5_OrderSystem2._0;

namespace HW8_OrderSystemUI
{
    public partial class MainForm : Form
    {
        private OrderService sys;

        private class Input
        {
            public string ID { get; set; }
            public string customer { get; set; }
            public string good { get; set; }
            public string detailnum { get; set; }
        }

        Input input = new Input();
        
        public MainForm()
        {
            InitializeComponent();

            sys = new OrderService();

            textBox_id.DataBindings.Add("Text", input, "ID");
            textBox_good.DataBindings.Add("Text", input, "good");
            textBox_customer.DataBindings.Add("Text", input, "customer");
            textBox_detailnum.DataBindings.Add("Text", input, "detailnum");

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
            }
            bindingSource1.DataSource = sys.orders;
            dataGridView1.DataSource = bindingSource1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int cur_id, cur_num;
            bool enable_id = int.TryParse(input.ID, out cur_id);
            bool enable_num = int.TryParse(input.detailnum, out cur_num);

            if (enable_id || enable_num || (input.customer != null && input.customer != "") || (input.good != null && input.good != ""))
                bindingSource1.DataSource = sys.orders.Where(o =>
                {
                    if (enable_id && o.id == cur_id) return true;
                    if (enable_num && o.items.Count == cur_num) return true;
                    if (o.customer.realname == input.customer) return true;
                    if (o.items.Exists(item => item.item.name_zh == input.good || item.item.name_en == input.good)) return true;
                    return false;
                }).ToList();
            else bindingSource1.DataSource = sys.orders;
        }

        private void bindingNavigatorAddNewItemOrModify_Click(object sender, EventArgs e)
        {
            var modifydataframe = new ModifyOrderForm(sys.orders[dataGridView1.SelectedCells[0].RowIndex]);
            modifydataframe.ShowDialog();
        }
    }
}
