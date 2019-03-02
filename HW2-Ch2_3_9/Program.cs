using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2_Ch2_3_9
{
    class Program
    {
        static void Main(string[] args)
        {
            // 初始化，所有数字都先被认为是素数
            bool[] isPrime = new bool[101];
            for (int i = 2; i <= 100; ++i) isPrime[i] = true;

            // 枚举，筛去每个数的倍数
            for(int i = 2; i <= 100; ++i)
            {
                //若该数已经非素数，则其倍数肯定已经被其因子筛过
                if (!isPrime[i]) continue;

                //未被筛掉的是素数，输出
                Console.WriteLine(i);

                //用素数筛去其倍数（含有该素数因子的数）
                for (int j = i + i; j <= 100; j += i)
                    isPrime[j] = false;
            }
        }
    }
}
