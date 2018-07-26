using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EShopping.Models;

namespace EShopping.Controllers
{
    public class ShoppingCartController : Controller
    {
        ElectricStoreEntities db = new ElectricStoreEntities();
        //Lấy giỏ hàng
        public List<ItemGioHang> LayGioHang()
        {
            // Giỏ hàng đã tồn tại
            List<ItemGioHang> lstGioHang = Session["GioHang"] as List<ItemGioHang>;
            if (lstGioHang == null)
            {
                lstGioHang = new List<ItemGioHang>();
                Session["GioHang"] = lstGioHang;
            }
            return lstGioHang;
        } 
        //Thêm giỏ hàng thông thường load lại trang
        public ActionResult ThemGioHang(String ProduceCode, String strUrl)
        {
            // Kiểm tra sản phẩm có tồn tại trong CSLD hay không?
            Product sp = db.Products.SingleOrDefault(n => n.ProduceCode == ProduceCode);
            if (sp == null)
            {
                // Trang đường dẫn không hợp lệ
                Response.StatusCode = 404;
            }
            // Lấy giỏ hàng
            List<ItemGioHang> lstGioHang = LayGioHang();
            //TH1 sản phẩm đã tồn tại trong giỏ hàng
            ItemGioHang spCheck = lstGioHang.SingleOrDefault(n => n.ProduceCode == ProduceCode);
            if (spCheck != null)
            {
                if (sp.ProductSold == true)
                {
                    return View("ThongBao");
                }
                spCheck.ProductQty++;
                return Redirect(strUrl);
            }
            if (sp.ProductSold == true)
            {
                return View("ThongBao");
            }
            ItemGioHang itemGH = new ItemGioHang(ProduceCode);
            lstGioHang.Add(itemGH);
            return Redirect(strUrl);
        }
        public double TinhTongSoLuong()
        {
            List<ItemGioHang> lstGioHang = Session["GioHang"] as List<ItemGioHang>;
            if(lstGioHang == null){
                return 0;
            }
            return lstGioHang.Sum(n => n.ProductQty);
        }
        public decimal TinhTongTien()
        {
            List<ItemGioHang> lstGioHang = Session["GioHang"] as List<ItemGioHang>;
            if (lstGioHang == null)
            {
                return 0;
            }
            return lstGioHang.Sum(n => n.ProductPrice);

        }






        // GET: ShoppingCart
        public ActionResult XemGioHang()
        {
            return View();
        }
        public ActionResult ShoppingPartial()
        {
            if (TinhTongSoLuong() == 0)
            {
                ViewBag.TongSoLuong = 0;
                ViewBag.TongTien = 0;
                return PartialView();
            }
            ViewBag.TongSoLuong = TinhTongSoLuong();
            ViewBag.TongTien = TinhTongTien();
            return PartialView();
            
        }
    }
}