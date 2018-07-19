using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EShopping.Models;
using System.ComponentModel.DataAnnotations;
namespace EShopping.Areas.Administrator.Models
{
      [MetadataTypeAttribute(typeof(Region.RegionMetaData))]
    public partial class Region
    {
          internal sealed class RegionMetaData
          {
              public int RegionId { get; set; }
               [Display(Name = "Region")]
              public string RegionName { get; set; }
               [Display(Name = "Description")]
              public string RegionDescription { get; set; }
          }
    }
}