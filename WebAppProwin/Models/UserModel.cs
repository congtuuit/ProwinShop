using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppProwin.Models
{
    public class UserModel: ModelBase
    {
        public string HoKH { get; set; }
        public string TenKH { get; set; }
        public DateTime NgaySinh { get; set; }
        public bool GioiTinh { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }
        public string Email { get; set; }
        public string MatKhau1 { get; set; }
        public string MatKhau2 { get; set; }
        public DateTime NgayTao  { get; set; }
        public int TrangThai { get; set; }
        public string TenDN { get; set; }
        public int Online { get; set; }

        public UserModel()
        {
        }

        //Khach hang dang ky tai khoan
        public bool Add(UserModel m)
        {
            var db = new ProwinShopEntities();
            if(m.MatKhau1 == m.MatKhau2)
            {
                m.NgayTao = DateTime.Now;
                m.Online = 0;
                m.TrangThai = 1;

                db.KhachHangs.Add(new KhachHang
                {
                    //HoKH = m.HoKH,
                    //TenKH = m.TenKH,
                    //TenDN = m.TenDN,
                    //DiaChi = m.DiaChi,
                    //DienThoai = m.DienThoai,
                    //Email  = m.Email,
                    //GioiTinh = m.GioiTinh,
                    //MatKhau = m.MatKhau1,
                    //NgaySinh = m.NgaySinh,
                    //NgayTao = m.NgayTao,
                    //Online = m.Online,
                    //TrangThai = m.TrangThai,
                });
                db.SaveChanges();

                return true;
            } else
            {
                return false;
            }
        }

        //Khach hang dang nhap
        public int Login(string username,string password)
        {
            var db = new ProwinShopEntities();
            var find = db.KhachHangs.FirstOrDefault(x => x.TaiKhoan == username);
            if (find !=null)    
            {
                if (find.MatKhau == password)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                return 0;

            }
        }

        //Kiem tra ten tai khoan ton tai?
        public bool KiemTraTenTaiKhoan (string TenDN)
        {
            var db = new ProwinShopEntities();
            var find = db.KhachHangs.FirstOrDefault(x => x.TaiKhoan == TenDN);
            if (find != null)
            {
                return true;
            }
            return false;
        }
    }
}