using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppProwin.Areas.Admin.Models
{
    public class SanPhamModel:ModelBase
    {
        public int MaSP { get; set; }
        public int MaDMC { get; set; }
        public int MaAlbum { get; set; }
        public int MaTH { get; set; }
        public double GiaSP { get; set; }
        public string TenSP { get; set; }
        public string TenSPNU { get; set; }
        public string Mota { get; set; }
        public DateTime NgayTao { get; set; }
        public double Sale { get; set; }
        public string NoiDung { get; set; }
        public int LuotTruyCap { get; set; }
        public int TrangThai { get; set; }
        public SanPhamModel()
        {
            NoiDung = "";
            Sale = 0;
            NgayTao = DateTime.Now;
            TrangThai = 1;
            LuotTruyCap = 0;
        }

        public void Add(SanPhamModel m)
        {
            try
            {
                ProwinShopEntities db = new ProwinShopEntities();
                m.MaDMC = 1;
                db.SanPhams.Add(new SanPham
                {
                    MaTH = m.MaTH,
                    GiaSP = m.GiaSP,
                    TenSP = m.TenSP,
                    TenSPNU = "capnhat",
                    Mota = m.Mota,
                    Sale = m.Sale,
                    NgayTao = DateTime.Now,
                    NoiDung = m.NoiDung,
                    LuotTruyCap = m.LuotTruyCap,
                    TrangThai = m.TrangThai
                });

                db.SaveChanges();
            } catch
            {
                Message = "Phát sinh lỗi.";
            }
            
        }
    }

    
}