//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebAppProwin
{
    using System;
    using System.Collections.Generic;
    
    public partial class BaiViet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BaiViet()
        {
            this.Tags = new HashSet<Tag>();
        }
    
        public int MaBV { get; set; }
        public int MaAlbum { get; set; }
        public int MaNV { get; set; }
        public int MaDMC { get; set; }
        public string TenBV { get; set; }
        public System.DateTime NgayDang { get; set; }
        public string MoTa { get; set; }
        public string NoiDung { get; set; }
        public string LinkFB { get; set; }
        public int TrangThai { get; set; }
        public string URL { get; set; }
    
        public virtual Album Album { get; set; }
        public virtual DanhMucCon DanhMucCon { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tag> Tags { get; set; }
    }
}
