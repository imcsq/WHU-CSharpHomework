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
    public partial class ModifyOrderForm : Form
    {
        public ModifyOrderForm()
        {
            InitializeComponent();
        }

        public ModifyOrderForm(Order order) : this()
        {
            textBox_id.DataBindings.Add("Text", order, "ID");
            if (order.customer == null) order.customer = new Customer("", "", "");
            textBox_username.DataBindings.Add("Text", order.customer, "username");
            textBox_customer.DataBindings.Add("Text", order.customer, "realname");

            if (order.items == null) order.items = new List<OrderDetail>();
            bindingSource1.DataSource = order.items;
            //dataGridView1.DataSource = bindingSource1.DataSource;
            dataGridView1.DataSource = bindingSource1;
        }
    }
}
