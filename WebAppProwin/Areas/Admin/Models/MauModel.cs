using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppProwin.Areas.Admin.Models
{
    public class MauModel
    {
        public int MaSP { get; set; }
        public int MaMau { get; set; }
        public string TenMau { get; set; }
        public string TenFile { get; set; }
        public int Soluong { get; set; }
        public int MaLoaiMau { get; set; }

        public List<int> kich_thuoc { get; set; }
        public List<string> SL_kich_thuoc { get; set; }

        public MauModel()
        {

        }

        public void Add(int? idsanpham, MauModel m)
        {
            ProwinShopEntities db = new ProwinShopEntities();
            m.MaLoaiMau = 1;
            db.MauSacs.Add(new MauSac
            {
                MaSP = idsanpham,
                TenMau = m.TenMau,
                Mau = m.TenMau,
                TenFile = m.TenFile,
                SoLuong = m.Soluong
            });
            db.SaveChanges();

            MauSac find = db.MauSacs.FirstOrDefault(x => x.MaSP == idsanpham && x.TenMau == m.TenMau);

            for (int i = 0; i < kich_thuoc.Count; i++)
            {
                int _size = kich_thuoc[i];
                KichThuoc find_size = db.KichThuocs.FirstOrDefault(x => x.MaKT == _size);

                MaMau_MaKT mkt = new MaMau_MaKT
                {
                    MaKT = find_size.MaKT,
                    MaMau = find.MaMau,
                    SoLuong = 0
                };

                find.MaMau_MaKT.Add(mkt);

                db.SaveChanges();
            }
        }
    }
}