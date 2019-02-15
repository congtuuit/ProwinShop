using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppProwin.Helpers;
using WebAppProwin.Models;

namespace WebAppProwin.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        UserModel model = new UserModel();
        ProwinShopEntities db = new ProwinShopEntities();
        public ActionResult Index()
        {
            SessionLogin user = (SessionLogin)Session["UserLogin"];
            return View(user);
        }
        public ActionResult DangKy()
        {
            return View();
        }

        [HttpPost]
        public JsonResult DangKy(UserModel m)
        {
            bool add = model.Add(m);
            if (add)
            {
                return Json("Đăng ký thành công.");
            } else
            {
                return Json("Xảy ra lỗi.");
            }
        }
        public ActionResult DangNhap()
        {
            return View(model);
        }

        [HttpPost]
        public ActionResult DangNhap(string username,string password)
        {
            int login = model.Login(username, password);
            if(login == 1)
            {
                KhachHang find = db.KhachHangs.FirstOrDefault(x => x.TaiKhoan == username && x.MatKhau == password);
                SessionLogin user = new SessionLogin(find);
                Session["UserLogin"] = user;
                SessionLogin users = (SessionLogin)Session["UserLogin"];
                return RedirectToAction("Index");
            }
            
            if (login == -1)
            {
                model.Message = "Sai Mật Khẩu.";
            }
            if (login == 0)
            {
                model.Message = "Tài Khoản Không Tồn Tại.";
            }
            return View(model);
        }

        [HttpPost]
        public JsonResult KiemTra(string name)
        {
            bool check = model.KiemTraTenTaiKhoan(name);
            if (check)
            {
                return Json("Tên tài khoản đã tồn tại.");
            }
            return Json("Có thể sử dụng tên tài khoản này.");

        }
    }
}