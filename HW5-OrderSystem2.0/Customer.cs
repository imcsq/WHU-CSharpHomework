using System;
namespace HW5_OrderSystem2._0
{
    public class Customer
    {
        private string _username;
        private string _realname;
        private string _phonenumber;

        public string username
        {
            get => this._username;
            set
            {
                // check valid username
                this._username = value;
            }
        }

        public string realname
        {
            get => this._realname;
            set
            {
                // check valid realname
                this._realname = value;
            }
        }

        public string phonenumber
        {
            get => this._phonenumber;
            set
            {
                // check valid phonenumber
                this._phonenumber = value;
            }
        }

        public Customer(string username, string realname, string phonenumber)
        {
            this._phonenumber = phonenumber;
            this._username = username;
            this._realname = realname;
        }

        public Customer(string username) : this(username, "", "") { }

        public override bool Equals(object obj)
        {
            Customer o = obj as Customer;
            return o != null && 
                o._username == this._username && (
                o._phonenumber == this._phonenumber ||
                o._realname == this._realname
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
