using ordertest;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderServiceUI
{
    public partial class FormEdit : Form
    {
        OrderService orderService = new OrderService();
        bool newflag = false;
        public Order CurrentOrder { get; set; }
        private List<OrderItem> OriginItemList;
        public FormEdit() {
            InitializeComponent();
        }

        public FormEdit(Order order):this()
        {
            if (order == null)
            {
                newflag = true;
                CurrentOrder = new Order();
                OriginItemList = null;
            }
            else
            {
                CurrentOrder = order;
                OriginItemList = order.Items.ToList();
            }
            orderBindingSource.DataSource = CurrentOrder;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (newflag)
                orderService.Insert(CurrentOrder);
            else
            {
                orderService.Remove(CurrentOrder.Id);
                orderService.Insert(CurrentOrder);
            }
            this.Close();
        }
  }
}
