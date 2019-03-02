using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2_Ch2_3_7
{
    class Program
    {
        static void Main(string[] args)
        {
            // 输入数据
            int len;
            do
            {
                Console.Write("请输入数字个数（正整数）：");
            }
            while (int.TryParse(Console.ReadLine(), out len) == false || len <= 0);

            int[] data = new int[len];
            for (int i = 0; i < len; ++i)
            {
                do
                {
                    Console.Write("请输入第" + (i + 1) + "个整数：");
                }
                while (int.TryParse(Console.ReadLine(), out data[i]) == false);
            }

            // 处理数据
            int minNum, maxNum, sumNum;
            minNum = maxNum = sumNum = data[0]; //基准默认为第一个数
            for(int i = 1; i < len; ++i)
            {
                minNum = minNum > data[i] ? data[i] : minNum;   //条件表达式

                if (maxNum < data[i])                           //if表达式
                    maxNum = data[i];

                sumNum += data[i];
            }

            // 输出结果
            Console.Write("数组");
            for (int i = 0; i < len; ++i) Console.Write(" " + data[i]);
            Console.Write(" 中最大的数为 " + maxNum + " 最小的数为 " + minNum + " 所有数字的和为 " + sumNum);
            Console.WriteLine("");
        }
    }
}
