using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppProwin.Areas.Admin.Models
{
    public class AlbumModel:ModelBase
    {
        public int MaAlbum { set; get; }
        public string TenAlbum { set; get; }
        public string URL { get; set; }
        public AlbumModel()
        {
        }

        public List<AlbumModel> GetListAlbum()
        {
            ProwinShopEntities db = new ProwinShopEntities();
            List<AlbumModel> albums = new List<AlbumModel>();
            foreach (var item in db.Albums.Where(x=>x.TrangThai==1).ToList())
            {
                albums.Add(new AlbumModel
                {
                    MaAlbum = item.MaAlbum,
                    TenAlbum = item.TenAlbum,
                    URL = "Upload/"+item.TenAlbum
                });
            }
            return albums;
        }

        public List<HinhAnh> GetListHinhAnh(int id)
        {
            ProwinShopEntities db = new ProwinShopEntities();
            List<HinhAnh> list = new List<HinhAnh>();
            try
            {
                List<HinhAnh> hinhs = db.HinhAnhs.Where(x => x.MaAlbum == id).ToList();
                list = hinhs;
                return list;
            }
            catch
            {
                Message = "Xay ra loi";
                return list;
            }
        }

        public bool NewAlbum(string name)
        {
            try
            {
                ProwinShopEntities db = new ProwinShopEntities();
                var find = db.Albums.FirstOrDefault(x => x.TenAlbum == name);
                if (find == null)
                {
                    db.Albums.Add(new Album
                    {
                        NguoiUpload = "Admin",
                        NgayTao = DateTime.Now,
                        TrangThai = 1,
                        TenAlbum = name
                    });
                    db.SaveChanges();

                }
                return true;
            }
            catch
            {
                return false;

            }
           

        }
    }
}