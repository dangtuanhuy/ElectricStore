//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EShopping.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class News
    {
        public int NewsId { get; set; }
        public string NewTitles { get; set; }
        public string NewsDetails { get; set; }
        public string NewsBy { get; set; }
        public string NewsImgs { get; set; }
        public Nullable<System.DateTime> NewUpdate { get; set; }
    }
}
