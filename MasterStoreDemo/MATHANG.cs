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
    
    public partial class MATHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MATHANG()
        {
            this.CT_HOADON = new HashSet<CT_HOADON>();
            this.CT_PHIEUNHAPKHO = new HashSet<CT_PHIEUNHAPKHO>();
            this.CT_PHIEUXUATKHO = new HashSet<CT_PHIEUXUATKHO>();
            this.CT_THONGKENGAY = new HashSet<CT_THONGKENGAY>();
            this.THEKHOes = new HashSet<THEKHO>();
        }
    
        public string MaMH { get; set; }
        public string TenMH { get; set; }
        public string MaNCC { get; set; }
        public string MaNSX { get; set; }
        public decimal GiaNhap { get; set; }
        public decimal GiaBan { get; set; }
        public int SoLuongTonGian { get; set; }
        public string DonViTinh { get; set; }
        public string HinhAnh { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_HOADON> CT_HOADON { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_PHIEUNHAPKHO> CT_PHIEUNHAPKHO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_PHIEUXUATKHO> CT_PHIEUXUATKHO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_THONGKENGAY> CT_THONGKENGAY { get; set; }
        public virtual NHACUNGCAP NHACUNGCAP { get; set; }
        public virtual NHASANXUAT NHASANXUAT { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<THEKHO> THEKHOes { get; set; }
    }
}
