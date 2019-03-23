namespace HW5_OrderSystem2._0
{
    // 订单详情类，记录购买的某种商品和数量。
    class OrderDetail
    {
        private Good _item;
        private int _num;

        public Good item { get => this._item; }                       //名称为只读属性，不支持修改
        public int num { get => this._num; set => this._num = value; }  //数量为读写属性，支持修改

        public OrderDetail(Good item, int num)
        {
            this._item = item;
            this._num = num;
        }

        public double detailPrice
        {
            get => this._item.price * this._num;
        }

        public override string ToString() => "货物：" + this._item + "\t数量：" + this._num;  //便于打印

        // 拥有的商品项目相同即认为订单明细相同（或冲突）
        public override bool Equals(object obj) => obj is OrderDetail o && o.item.Equals(this.item);

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}