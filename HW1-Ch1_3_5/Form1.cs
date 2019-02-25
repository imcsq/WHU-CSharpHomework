using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW1_CH1_3_5
{
    public partial class 计算 : Form
    {
        public 计算()
        {
            InitializeComponent();
        }

        private void button_calc_Click(object sender, EventArgs e)
        {
            double num1, num2;
            try
            {
                num1 = double.Parse(this.textBox_num1.Text);
                num2 = double.Parse(this.textBox_num2.Text);
                MessageBox.Show("" + num1 + "*" + num2 + "=" + (num1 * num2), "计算结果");
            }
            catch (Exception)
            {
                MessageBox.Show("计算失败！请输入合法数字进行运算。", "错误");
            }
        }
    }
}
