using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EShopping.Models;
using System.ComponentModel.DataAnnotations;

namespace EShopping.Models
{
    [MetadataTypeAttribute(typeof(Category.CategoryMetaData))]
    public partial class  Category
    {
        internal sealed class CategoryMetaData
        {
            public int CategoryId { get; set; }
            [Display(Name="Category")]
            public string CategoryName { get; set; }
            [Display(Name = "Details")]
            public string CategoryDetails { get; set; }
        }
    }
}