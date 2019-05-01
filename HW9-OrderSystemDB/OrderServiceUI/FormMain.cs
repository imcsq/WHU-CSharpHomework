using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ordertest;

namespace OrderServiceUI
{
  public partial class FormMain : Form {
    OrderService orderService = new OrderService();
    public FormMain() {
      InitializeComponent();
      orderBindingSource.DataSource = orderService.GetAll();
    }

    private void refresh() {
      switch (comboBox1.SelectedIndex) {
        case 0:
          orderBindingSource.DataSource = orderService.GetAll();
          break;
        case 1:
          orderBindingSource.DataSource = orderService.GetOrder(textBox1.Text);
          break;
        case 2:
          orderBindingSource.DataSource = orderService.GetByCustormer(textBox1.Text);
          break;
        case 3:
          orderBindingSource.DataSource = orderService.GetByGoods(textBox1.Text);
          break;
        default:
          orderBindingSource.DataSource = orderService.GetAll();
        break;
      }
      orderBindingSource.ResetBindings(false);
      itemsBindingSource.ResetBindings(false);
    }

    private void button1_Click(object sender, EventArgs e) {
      refresh();
    }

    private void button2_Click(object sender, EventArgs e) {
      FormEdit editForm = new FormEdit(null);
      editForm.ShowDialog();
      refresh();
    }

    private void button3_Click(object sender, EventArgs e) {
      if (orderBindingSource.Current != null) {
        FormEdit editForm = new FormEdit((Order)orderBindingSource.Current);
        editForm.ShowDialog();
        refresh();
      }
      else {
        MessageBox.Show("No Order is selected!");
      }
    }
    private void button4_Click(object sender, EventArgs e) {
      if (orderBindingSource.Current != null) {
        Order order=(Order)orderBindingSource.Current;
        orderService.Remove(order.Id);
        refresh();
      }
      else {
        MessageBox.Show("No Order is selected!");
      }
    }
  }
}
