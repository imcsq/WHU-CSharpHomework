using System;
namespace HW5_OrderSystem2._0
{
    [Serializable]
    public class Customer
    {
        public string username { get; set; }

        public string realname { get; set; }

        public string phonenumber { get; set; }

        public Customer() { }

        public Customer(string username, string realname, string phonenumber)
        {
            this.phonenumber = phonenumber;
            this.username = username;
            this.realname = realname;
        }

        public Customer(string username) : this(username, "", "") { }

        public override bool Equals(object obj)
        {
            Customer o = obj as Customer;
            return o != null && 
                o.username == this.username && (
                o.phonenumber == this.phonenumber ||
                o.realname == this.realname
                );
        }

        public override int GetHashCode()
        {
            return username.GetHashCode();
        }

        public override string ToString()
        {
            return realname + "(" + username + ")";
        }
    }
}
