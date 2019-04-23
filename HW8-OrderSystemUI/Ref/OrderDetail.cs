using System;

namespace HW5_OrderSystem2._0
{
    // 订单详情类，记录购买的某种商品和数量。
    [Serializable]
    public class OrderDetail
    {

        public Good item { get; set; }                       //名称为只读属性，不支持修改
        public int num { get; set; }  //数量为读写属性，支持修改

        public OrderDetail() { }

        public OrderDetail(Good item, int num)
        {
            this.item = item;
            this.num = num;
        }

        public double detailPrice
        {
            get => this.item.price * this.num;
        }

        public override string ToString() => "货物：" + this.item + "\t数量：" + this.num;  //便于打印

        // 拥有的商品项目相同即认为订单明细相同（或冲突）
        public override bool Equals(object obj) => obj is OrderDetail o && o.item.Equals(this.item);

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}