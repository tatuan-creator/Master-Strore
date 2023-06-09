﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MasterStoreDemo.Model;
using MasterStoreDemo.ViewModel;
using NUnit.Framework;

namespace MasterStoreDemo.UnitTest
{
    [TestFixture]
    public class TestDuyetPhieuNhap
    {
        private DuyetPhieuNhap_ViewModel _DuyetPhieuNhap;

        [SetUp]
        public void Setup()
        {
            _DuyetPhieuNhap = new DuyetPhieuNhap_ViewModel();
        }

        [TestCase("CTTK", true)]
        [TestCase("CT",true)]
        [TestCase("KKK",false)]
        [TestCase("AXF",false)]
        [TestCase("Ksa", false)]
        [TestCase("9i39i", false)]
        public void TestCreateMa(string a, bool b)
        {
            Assert.IsTrue(_DuyetPhieuNhap.create_MaCTTK().Contains(a)==b);
        }
    
    }
}