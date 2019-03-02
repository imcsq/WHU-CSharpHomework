using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2_Ch2_3_6
{
    class Program
    {
        static void Main(string[] args)
        {
            int num;
            do
            {
                Console.Write("请输入待分析素数因子的正整数：");
            }
            while (int.TryParse(Console.ReadLine(), out num) == false || num < 0);  //直到得到合法输入后才继续

            Console.Write("" + num + "的素数因子有：");

            bool isPrime;
            for(int i = 2; i <= num; ++i)   //枚举因子
            {
                if (num % i != 0) continue;

                isPrime = true;
                for(int j = 2; j <= i / 2 && isPrime; ++j)  //判断因子素性。普通判法，枚举因子的因子，有非1和自己的因子时则非素数。
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                    }
                }
                if (isPrime)
                {
                    Console.Write(" " + i);
                }
            }
            Console.WriteLine("");
        }
    }
}
