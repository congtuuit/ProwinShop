using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAppProwin.Areas.Admin.Models;

namespace WebAppProwin.Areas.Admin.Controllers
{
    public class SanPhamController : Controller
    {
        // GET: Admin/SanPham
        ProwinShopEntities db = new ProwinShopEntities();
        static int? temp_id_SanPham = 1;
        public ActionResult Index()
        {
            List<SanPham> m = db.SanPhams.ToList();
            return View(m);
        }
        public ActionResult ThemSanPham()
        {
            ViewSanPham m = new ViewSanPham();
            return View(m);
        }

        [HttpPost]
        public ActionResult ThemSanPham(SanPhamModel m)
        {
            m.Add(m);
            ViewSanPham view = new ViewSanPham();
            view.Message = "Thêm Sản Phẩm Thành Công.";
            return View(view);
        }

        public ActionResult ChiTietSP(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            temp_id_SanPham = id;
            ViewChiTiet view = new ViewChiTiet();

            List<MauSac> listMau = db.MauSacs.Where(x => x.MaSP == id).ToList();

            view.mausac = listMau;
            view.kichthuoc = db.KichThuocs.ToList();
            return View(view);
        }


        [HttpPost]
        public ActionResult ThemMau(MauModel model, HttpPostedFileBase[] img)
        {
            model.TenFile = img[0].FileName;
            model.Add(temp_id_SanPham, model);
            return RedirectToAction("ChiTietSP/"+temp_id_SanPham);
        }
    }
}