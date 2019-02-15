using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppProwin.Areas.Admin.Models
{
    public class ViewChiTiet
    {
        public List<MauSac> mausac { get; set; }
        public List<KichThuoc> kichthuoc { get; set; }
        public ViewChiTiet()
        {
            mausac = new List<MauSac>();
            kichthuoc = new List<KichThuoc>();
        }

    }
}