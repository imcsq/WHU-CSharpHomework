using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1_Ch1_3_4
{
    class Program
    {
        static void Main(string[] args)
        {
            double num1, num2;
            try
            {
                Console.Write("请输入一个数字：");
                num1 = double.Parse(Console.ReadLine());
                Console.Write("请输入另一个数字：");
                num2 = double.Parse(Console.ReadLine());
                Console.WriteLine("" + num1 + "*" + num2 + "=" + (num1 * num2));
            }
            catch (Exception)
            {
                Console.WriteLine("当前输入错误！请输入合法数字进行运算。");
            }
        }
    }
}
