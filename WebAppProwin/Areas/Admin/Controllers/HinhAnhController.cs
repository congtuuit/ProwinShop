using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppProwin.Areas.Admin.Models;

namespace WebAppProwin.Areas.Admin.Controllers
{
    public class HinhAnhController : Controller
    {
        // GET: Admin/HinhAnh
        ProwinShopEntities db = new ProwinShopEntities();
        public ActionResult Index()
        {
            AlbumModel model = new AlbumModel();
            return View(model.GetListAlbum());
        }

        public ActionResult GetListIMG(int id)
        {
            AlbumModel model = new AlbumModel();
            return View(model.GetListHinhAnh(id));
        }

        [HttpPost]
        public ActionResult CreateNewAlbum(string name)
        {
            AlbumModel model = new AlbumModel();

            if (model.NewAlbum(name))
            {
                string path = "~/Upload/" + name;
                try
                {
                    Directory.CreateDirectory(Server.MapPath(path));
                }catch
                {
                    return Json("Xay ra loi tao thu muc o server");
                }
                return RedirectToAction("Index");
            }
            else return Json("Xay ra loi");
        }
    }
}