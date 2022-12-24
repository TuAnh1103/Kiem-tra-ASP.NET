using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ngay22_12_2.Models;
namespace Ngay22_12_2.Controllers
{
    public class NVienController : Controller
    {
        // GET: NVien
        QLNhanVienDB db = new QLNhanVienDB();
        public ActionResult Index(string min,string max)
        {
            var query = db.NhanViens.Select(p=>p);
            
            if (!String.IsNullOrEmpty(min)&&!String.IsNullOrEmpty(max))
            {
                float m = float.Parse(min);
                float M = float.Parse(max);
                query = query.Where(x=>x.Luong>=m && x.Luong<=M);
            }   
           
            return View(query.ToList());
        }
        [HttpGet]
        public ActionResult ChiTiet(string id)
        {
            var query = db.NhanViens.Where(x => x.Manv == id).First();
            return View(query);
        }
        [HttpGet]
        public ActionResult Them()
        {
            ViewData["Phong"] = new SelectList(db.Phongs, "MaPhong", "TenPhong");
            return View();
        }
        [HttpPost]
        public ActionResult Them(FormCollection f,NhanVien nv)
        {
            
            var ma = f["Manv"];
            var ten = f["Hoten"];
            var phong = f["Phong"];
            var luong = f["Luong"];
            var query = db.NhanViens.Where(x => x.Manv == ma).FirstOrDefault();

            if (String.IsNullOrEmpty(ma))
            {
                ViewData["Loi1"] = "Mã nhân viên không được để trống!";
            }    
            else if(String.IsNullOrEmpty(ten))
            {
                ViewData["Loi2"] = "Họ tên không đượ để trống ";
            }    
            else if(String.IsNullOrEmpty(luong))
            {
                ViewData["Loi3"] = "Lương không được để trống";
            }
            else if(query!=null)
            {
                ViewData["Loi4"] = "Mã nhân viên này đã tồn tại!";
            }    
            else
            {
                nv.Manv = ma;
                nv.Hoten = ten;
                nv.Maphong = phong;
                nv.Luong = Double.Parse(luong);
                db.NhanViens.Add(nv);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return this.Them();
        }
        [HttpGet]
        public ActionResult Sua(string id)
        {
            var query = db.NhanViens.Where(x => x.Manv == id).First();
            ViewData["Phong"] = new SelectList(db.Phongs, "Maphong", "Tenphong");
            return View(query);
        }
        [HttpPost]
        public ActionResult Sua(string id,FormCollection f)
        {
            var nv = db.NhanViens.Where(x => x.Manv == id).First();
            var ten = f["Hoten"];
            var phong = f["Phong"];
            var luong = f["Luong"];
            if(String.IsNullOrEmpty(ten))
            {
                ViewData["Loi1"] = "Họ tên không được để trống!";
            }
            else if(String.IsNullOrEmpty(luong))
            {
                ViewData["Loi2"] = "Lương không được để trống";
            }
            else
            {
                nv.Hoten = ten;
                nv.Maphong = phong;
                nv.Luong = Convert.ToDouble(luong);
                UpdateModel(nv);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return this.Sua(id);
        }
        [HttpGet]
        public ActionResult Xoa(string id)
        {
            var query = db.NhanViens.Where(x => x.Manv == id).First();
            return View(query);
        }
        [HttpPost]
        public ActionResult Xoa(string id,FormCollection Data)
        {
            var query = db.NhanViens.Where(m => m.Manv == id).First();
            db.NhanViens.Remove(query);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}