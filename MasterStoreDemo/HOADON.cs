//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MasterStoreDemo
{
    using System;
    using System.Collections.Generic;
    
    public partial class HOADON
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HOADON()
        {
            this.CT_HOADON = new HashSet<CT_HOADON>();
        }
    
        public string MaHoaDon { get; set; }
        public System.DateTime NgayLap { get; set; }
        public System.TimeSpan ThoiGian { get; set; }
        public string MaQuay { get; set; }
        public decimal TongTien { get; set; }
        public string MaNguoiLap { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_HOADON> CT_HOADON { get; set; }
        public virtual NGUOIDUNG NGUOIDUNG { get; set; }
        public virtual QUAY QUAY { get; set; }
    }
}
