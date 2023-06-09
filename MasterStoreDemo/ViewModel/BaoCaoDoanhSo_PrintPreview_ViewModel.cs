﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using MasterStoreDemo.Model;
using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;

namespace MasterStoreDemo.ViewModel
{
    public class BaoCaoDoanhSo_PrintPreview_ViewModel : BaseViewModel
    {
        #region Old code





        ////---------------


        #endregion


        private DateTime _StartDate;
        public DateTime StartDate
        {
            get { return _StartDate; }
            set { _StartDate = value; OnPropertyChanged(); }
        }
        private DateTime _EndDate;
        public DateTime EndDate
        {
            get { return _EndDate; }
            set { _EndDate = value; OnPropertyChanged(); }
        }
        //---------------
        private string _MaBaoCao;

        public string MaBaoCao
        {
            get { return _MaBaoCao; }
            set { _MaBaoCao = value; OnPropertyChanged(); }
        }

        private string _NguoiTaoPhieu;

        public string NguoiTaoPhieu
        {
            get { return _NguoiTaoPhieu; }
            set { _NguoiTaoPhieu = value; OnPropertyChanged(); }
        }


        private string _NgayThangNam;

        public string NgayThangNam
        {
            get { return _NgayThangNam; }
            set { _NgayThangNam = value; OnPropertyChanged(); }
        }

        //---------------
        private ObservableCollection<DongBaoCao> _ListBaoCaoDoanhSo;

        public ObservableCollection<DongBaoCao> ListBaoCaoDoanhSo
        {
            get { return _ListBaoCaoDoanhSo; }
            set { _ListBaoCaoDoanhSo = value; OnPropertyChanged(); }
        }
        //--------------

        public ICommand CloseWindowCommand { get; set; }
        public ICommand Print_Command { get; set; }

        public BaoCaoDoanhSo_PrintPreview_ViewModel(ObservableCollection<DongBaoCao> BaoCao, DateTime inputStartDate, DateTime inputEndDate, String inputNguoiTao)
        {
            ListBaoCaoDoanhSo = BaoCao;
            StartDate = inputStartDate;
            EndDate = inputEndDate;
            NguoiTaoPhieu = inputNguoiTao;
            //for (int i = 0; i < listBaoCao.Count(); i++)
            //    ListBaoCaoDoanhSo[i].SoThuTu = i + 1;

            if (LoginViewModel.TaiKhoanSuDung != null)
                NguoiTaoPhieu = LoginViewModel.TaiKhoanSuDung.HoTen;
            string date = DateTime.Now.ToString("dd/MM/yyyy");
            NgayThangNam = "Ngày " + date.Substring(0, 2) + ", tháng " + date.Substring(3, 2) + ", năm " + date.Substring(6, 4);
 
            CloseWindowCommand = new RelayCommand<object>((p) => { return p == null ? false : true; }, (p) =>
            {
                var ex = p as Window;
                ex.Close();

            });

            Print_Command = new RelayCommand<object>((p) => { return p == null ? false : true; }, (p) =>
            {
                var ex = p as Window;
                try
                {
                    System.Windows.Controls.PrintDialog printDialog = new System.Windows.Controls.PrintDialog();
                    if (printDialog.ShowDialog() == true)
                    {
                        printDialog.PrintVisual(ex, "Print report");

                    }
                }
                catch (Exception e)
                {
                    System.Windows.MessageBox.Show("Cannot print");
                }

            });


        }
    }


}
