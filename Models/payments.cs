//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace login
{
    using System;
    using System.Collections.Generic;
    
    public partial class payments
    {
        public int id { get; set; }
        public int uid { get; set; }
        public int category { get; set; }
        public System.DateTime time { get; set; }
        public decimal amount { get; set; }
        public string note { get; set; }
    
        public virtual category category1 { get; set; }
        public virtual logins logins { get; set; }
    }
}
