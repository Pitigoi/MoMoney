using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace login
{
    public class Entry
    {
        public Entry(string name, string vlaue, DateTime date, string category)
        {
            this._name = name;  //this is the description field
            this._category = category;
            this._value = vlaue;
            this._date = date;
        }
        public string _name { get; set; }
        public string _value { get; set; }
        public DateTime _date { get; set; }
        public string _category { get; set; }
    }
}
