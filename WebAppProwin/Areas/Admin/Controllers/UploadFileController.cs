using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppProwin.Areas.Admin.Controllers
{
    public class UploadFileController : Controller
    {
        // GET: Admin/UploadFile
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(IEnumerable<HttpPostedFileBase> files, int TenAlbum)
        {
            ProwinShopEntities db = new ProwinShopEntities();
            Album myAlbum = db.Albums.FirstOrDefault(x => x.MaAlbum == TenAlbum);
            foreach (var file in files)
            {
                try
                {
                    db.HinhAnhs.Add(new HinhAnh
                    {
                        MaLoai = 1,
                        MaAlbum = TenAlbum,
                        path = myAlbum.TenAlbum + "/" + file.FileName,
                        TrangThai = 1
                    });
                    db.SaveChanges();
                    var filename = Path.Combine(Server.MapPath("~/Upload/"+myAlbum.TenAlbum), file.FileName);
                    file.SaveAs(filename);
                }
                catch
                {
                    return Json(new { name = "ERROR!" });
                }
            }
            return Json(files.Select(x => new { name = x.FileName }));
        }
    }
}