using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppProwin.Areas.Admin.Models
{
    public class ViewSanPham:ModelBase
    {
        public List<Album> albums { get; set; }
        public List<ThuongHieu> NhomSP { get; set; }
        public List<DanhMucCon> DMCons { get; set; }
        public ViewSanPham()
        {
            ProwinShopEntities db = new ProwinShopEntities();

            albums = new List<Album>();
            NhomSP = new List<ThuongHieu>();
            DMCons = new List<DanhMucCon>();

            albums = db.Albums.ToList();
            NhomSP = db.ThuongHieux.ToList();
            DMCons = db.DanhMucCons.ToList();

        }
    }
}