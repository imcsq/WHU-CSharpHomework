using System;
using System.Runtime.Serialization;

namespace HW5_OrderSystem2._0
{
    // 找不到项目异常，用于汇报找不到某订单或某商品等。带两个参数，寻键方法 和 键值
    public class ItemNotFoundException : ApplicationException
    {
        private string _indexMethod, _indexKey;
        public string indexMethod { get => _indexMethod; }
        public string indexKey { get => _indexKey; }

        public ItemNotFoundException(string indexMethod, string indexKey)
         : base("未找到所需要的项目")
        {
            this._indexMethod = indexMethod;
            this._indexKey = indexKey;
        }
    }

    // 键值重复异常，用于汇报ID等有唯一要求的键发生重复。带两个参数，寻键方法 和 键值
    public class ItemRepeatException : ApplicationException
    {
        private string _indexMethod, _indexKey;
        public string indexMethod { get => _indexMethod; }
        public string indexKey { get => _indexKey; }

        public ItemRepeatException(string indexMethod, string indexKey)
         : base("键值重复")
        {
            this._indexMethod = indexMethod;
            this._indexKey = indexKey;
        }
    }

    // 键值无效异常，用于价格等有取值要求的字段发生错误。带两个参数，错误字段名，错误描述
    public class ValueError : ApplicationException
    {
        private string _valuename, _description;
        public string valuename { get => _valuename; }
        public string description { get => _description; }

        public ValueError(string valuename, string description)
         : base("键值无效")
        {
            this._valuename = valuename;
            this._description = description;
        }
    }
}