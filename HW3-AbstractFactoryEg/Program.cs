using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3_AbstractFactoryEg //抽象工厂模式的具体实现
{
    // 按钮接口（抽象产品）
    public interface Button
    {
        void Display();
    }

    // 文本框（抽象产品）
    public interface TextField
    {
        void Display();
    }

    // Spring按钮（具体产品）
    class SpringButton: Button
    {
        public void Display()
        {
            Console.WriteLine("显示浅绿色按钮");
        }
    }

    // Spring文本框（具体产品）
    class SpringTextField : TextField
    {
        public void Display()
        {
            Console.WriteLine("显示绿色边框文本框");
        }
    }

    // Summer按钮（具体产品）
    class SummerButton : Button
    {
        public void Display()
        {
            Console.WriteLine("显示浅蓝色按钮");
        }
    }

    // Summer文本框（具体产品）
    class SummerTextField : TextField
    {
        public void Display()
        {
            Console.WriteLine("显示蓝色边框文本框");
        }
    }

    // 界面皮肤工厂（抽象工厂）
    public interface SkinFactory
    {
        Button CreateButton();
        TextField CreateTextField();
    }

    // Spring皮肤工厂（具体工厂）
    class SpringSkinFactory : SkinFactory
    {
        public Button CreateButton()
        {
            return new SpringButton();
        }
        public TextField CreateTextField()
        {
            return new SpringTextField();
        }
    }

    // Summer皮肤工厂（具体工厂）
    class SummerSkinFactory : SkinFactory
    {
        public Button CreateButton()
        {
            return new SummerButton();
        }

        public TextField CreateTextField()
        {
            return new SummerTextField();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            SkinFactory factory;

            // 避开复杂的配置处理，象征性的表示一下建立不同的工厂。
            if ((new Random()).Next() % 2 == 0)
                factory = new SpringSkinFactory();
            else factory = new SummerSkinFactory();

            Button b1 = factory.CreateButton();
            TextField t1 = factory.CreateTextField();
            b1.Display();
            t1.Display();
        }
    }
}
