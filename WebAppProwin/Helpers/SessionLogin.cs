using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppProwin.Helpers
{
    public class SessionLogin
    {
        public string HoKH { get; set; }
        public string TenKH { get; set; }
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }
        public string Email { get; set; }
        public string MatKhau { get; set; }
        public string TenDN { get; set; }

        public SessionLogin()
        {

        }
        public SessionLogin(KhachHang kh)
        {
            this.HoKH = kh.Ho;
            this.TenDN = kh.TaiKhoan;
            this.TenKH = kh.Ten;
            this.NgaySinh = kh.NgaySN;
            this.GioiTinh = kh.GioiTinh;
            this.DiaChi = kh.DiaChi;
            this.Email = kh.Email;
            this.DienThoai = kh.DienThoai;
            this.MatKhau = kh.MatKhau;
        }

    }
}