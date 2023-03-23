using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MasterStoreDemo.ViewModel;
using NUnit.Framework;

namespace MasterStoreDemo.UnitTest
{
    [TestFixture]
    public class TestQuanLyNhanVien
    {
        private QuanLyNhanSu_ViewModel _QLNS;

        [SetUp]
        public void Setup()
        {
            _QLNS = new QuanLyNhanSu_ViewModel();
        }
    }

}