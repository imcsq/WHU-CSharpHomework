using System;
namespace HW5_OrderSystem2._0
{
    [Serializable]
    public class Good
    {
        public Good() { }

        public string name_zh { get; set; }
        public string name_en { get; set; }

        public double price { get; set; }

        public Good(string name_zh, string name_en, double price)
        {
            this.price = price;
            this.name_en = name_en;
            this.name_zh = name_zh;
        }

        // 中文或英文名相同则认为相等（认为冲突）
        public override bool Equals(object obj) => obj is Good o &&
                (o.name_zh == this.name_zh || o.name_en == this.name_en);

        public override int GetHashCode()
        {
            return this.name_zh.GetHashCode();
        }

        public override string ToString() => name_zh + "(" + name_en + ")";
    }
}
