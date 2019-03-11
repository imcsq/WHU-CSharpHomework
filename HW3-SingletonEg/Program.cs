using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3_SingletonEg //单例模式的具体实现。使用了能避免资源浪费和不使用复杂的同步机制的holder内部类实现方法。
{
    public class Singleton
    {
        private Singleton()
        {
            Console.WriteLine("Generate an instance.");
        }

        private static class Holder
        {
            public static Singleton instance = new Singleton();
        }

        public static Singleton GetInstance()
        {
            return Singleton.Holder.instance;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start."); // 在此之前不输出generate，说明避开了饿汉方法造成的资源占用

            Singleton instance1 = Singleton.GetInstance();
            Singleton instance2 = Singleton.GetInstance();

            Console.WriteLine(instance1 == instance2); // 输出true，说明获取到了同一个实例
        }
    }
}
