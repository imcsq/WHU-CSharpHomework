using System;
namespace HW5_OrderSystem2._0
{
    public class Good
    {
        private string _name_zh;
        private string _name_en;
        private double _price;

        public string name_zh
        {
            get => this._name_zh;
            set => this._name_zh = value;
        }

        public string name_en
        {
            get => this._name_en;
            set => this._name_en = value;
        }

        public double price
        {
            get => this._price;
            set
            {
                if (value <= 0)
                    throw new ValueError("商品单价", "单价不能为非正数");
                this._price = value;
            }
        }

        public Good(string name_zh, string name_en, double price)
        {
            this._price = price;
            this._name_en = name_en;
            this._name_zh = name_zh;
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
