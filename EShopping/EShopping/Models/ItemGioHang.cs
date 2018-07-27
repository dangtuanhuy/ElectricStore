using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EShopping.Models
{
    public class ItemGioHang
    {
        public String ProduceCode { get; set; }
        public String ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int SizeName { get; set; }
        public int ColerName { get; set; }
        public int SoLuong { get; set; }
        public int ProductQty { get; set; }
        public String ProductImg { get; set; }
        public Decimal ThanhTien { get; set; }

        public ItemGioHang(String iProduceCode)
        {
            using (ElectricStoreEntities db = new ElectricStoreEntities())
            {
                this.ProduceCode = iProduceCode;
                Product sp = db.Products.Single(n => n.ProduceCode == iProduceCode);
                this.ProductName = sp.ProductName;
                this.ProductQty = 1;
                this.ProductPrice = sp.ProductPrice.Value;
                this.ThanhTien = sp.ProductQty.Value * sp.ProductPrice.Value;
                this.SizeName = sp.SizeId.Value;
                this.ColerName = sp.ColorId.Value;
                this.ProductImg = sp.ProductImg;
            }

        }

        public ItemGioHang(String iProduceCode, int Sl)
        {
            using (ElectricStoreEntities db = new ElectricStoreEntities())
            {
                this.ProduceCode = iProduceCode;
                Product sp = db.Products.Single(n => n.ProduceCode == iProduceCode);
                this.ProductName = sp.ProductName;
                this.ProductPrice = sp.ProductPrice.Value;
                this.SizeName = sp.SizeId.Value;
                this.ColerName = sp.ColorId.Value;
                this.ProductQty = Sl;
                this.ProductImg = sp.ProductImg;


            }    
        }
    }
}