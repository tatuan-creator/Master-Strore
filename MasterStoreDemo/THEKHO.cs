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
    
    public partial class THEKHO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public THEKHO()
        {
            this.CT_THEKHO = new HashSet<CT_THEKHO>();
        }
    
        public string MaTheKho { get; set; }
        public System.DateTime NgayLap { get; set; }
        public string MaNguoiLap { get; set; }
        public string MaMH { get; set; }
        public int SoLuongTonKho { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_THEKHO> CT_THEKHO { get; set; }
        public virtual MATHANG MATHANG { get; set; }
        public virtual NGUOIDUNG NGUOIDUNG { get; set; }
    }
}
