﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class QLSieuThiEntities : DbContext
    {
        public QLSieuThiEntities()
            : base("name=QLSieuThiEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CHUCNANG> CHUCNANGs { get; set; }
        public virtual DbSet<CT_HOADON> CT_HOADON { get; set; }
        public virtual DbSet<CT_PHIEUNHAPKHO> CT_PHIEUNHAPKHO { get; set; }
        public virtual DbSet<CT_PHIEUXUATKHO> CT_PHIEUXUATKHO { get; set; }
        public virtual DbSet<CT_THEKHO> CT_THEKHO { get; set; }
        public virtual DbSet<CT_THONGKENGAY> CT_THONGKENGAY { get; set; }
        public virtual DbSet<HOADON> HOADONs { get; set; }
        public virtual DbSet<MATHANG> MATHANGs { get; set; }
        public virtual DbSet<NGUOIDUNG> NGUOIDUNGs { get; set; }
        public virtual DbSet<NHACUNGCAP> NHACUNGCAPs { get; set; }
        public virtual DbSet<NHASANXUAT> NHASANXUATs { get; set; }
        public virtual DbSet<NHOMNGUOIDUNG> NHOMNGUOIDUNGs { get; set; }
        public virtual DbSet<PHANQUYEN> PHANQUYENs { get; set; }
        public virtual DbSet<PHIEUNHAPKHO> PHIEUNHAPKHOes { get; set; }
        public virtual DbSet<PHIEUXUATKHO> PHIEUXUATKHOes { get; set; }
        public virtual DbSet<QUAY> QUAYs { get; set; }
        public virtual DbSet<THAMSO> THAMSOes { get; set; }
        public virtual DbSet<THEKHO> THEKHOes { get; set; }
        public virtual DbSet<THONGBAO> THONGBAOs { get; set; }
        public virtual DbSet<THONGKENGAY> THONGKENGAYs { get; set; }
    }
}
