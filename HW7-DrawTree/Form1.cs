using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW7_DrawTree
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Graphics graphics;
        double th1 = 30 * Math.PI / 180;
        double th2 = 20 * Math.PI / 180;
        double per1 = 0.6;
        double per2 = 0.7;
        Pen pen = Pens.Blue;

        void drawCayleyTree(int n, double x0, double y0, double leng, double th)
        {
            if (n == 0) return;

            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);

            drawLine(x0, y0, x1, y1);

            drawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1);
            drawCayleyTree(n - 1, x1, y1, per2 * leng, th - th2);
        }

        void drawLine(double x0, double y0, double x1, double y1)
        {
            graphics.DrawLine(pen, (int)x0, (int)y0, (int)x1, (int)y1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            button2.BackColor = colorDialog1.Color;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (graphics == null) graphics = this.CreateGraphics();
            else graphics.Clear(this.BackColor);

            try
            {
                th1 = double.Parse(text_lrotate.Text) * Math.PI / 180;
                th2 = double.Parse(text_rrotate.Text) * Math.PI / 180;
                per1 = double.Parse(text_lratio.Text);
                per2 = double.Parse(text_rratio.Text);

                if (th1 > Math.PI || th1 < 0 || th2 > Math.PI || th2 < 0)
                    throw new Exception("度数无效");

                pen = new Pen(colorDialog1.Color, trackBar_penwidth.Value);

                drawCayleyTree(10, 200, 310, 100, -Math.PI / 2);
            }
            catch
            {
                MessageBox.Show("请在文本框中输入合法参数");
            }
        }
    }
}
