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
    
    public partial class PHIEUXUATKHO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PHIEUXUATKHO()
        {
            this.CT_PHIEUXUATKHO = new HashSet<CT_PHIEUXUATKHO>();
        }
    
        public string MaPhieuXK { get; set; }
        public System.DateTime NgayLap { get; set; }
        public string MaNguoiLap { get; set; }
        public string MaQuay { get; set; }
        public int TrangThai { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_PHIEUXUATKHO> CT_PHIEUXUATKHO { get; set; }
        public virtual NGUOIDUNG NGUOIDUNG { get; set; }
        public virtual QUAY QUAY { get; set; }
    }
}
