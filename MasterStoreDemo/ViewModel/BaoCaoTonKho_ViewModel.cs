using MasterStoreDemo.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Xps;
using System.Windows.Xps.Packaging;

namespace MasterStoreDemo.ViewModel
{
    public class BaoCaoTonKho_ViewModel : BaseViewModel
    {
        public ICommand StartDateChangedCommand { get; set; }
        public ICommand EndDateChangedCommand { get; set; }
        public ICommand YearChangedCommand { get; set; }
        public ICommand CheDoXemChangedCommand { get; set; }
        public ICommand PrintCommand { get; set; }
        private DateTime _SelectedStartDate;
        public DateTime SelectedStartDate { get => _SelectedStartDate; set { _SelectedStartDate = value; OnPropertyChanged(); } }
        private DateTime _SelectedEndDate;
        public DateTime SelectedEndDate { get => _SelectedEndDate; set { _SelectedEndDate = value; OnPropertyChanged(); } }

        private Visibility _VisibilityDatePickerPopup;
        public Visibility VisibilityDatePickerPopup { get => _VisibilityDatePickerPopup; set { _VisibilityDatePickerPopup = value; OnPropertyChanged(); } }
        private string _PopupContent;
        public string PopupContent { get => _PopupContent; set { _PopupContent = value; OnPropertyChanged(); } }
        private ObservableCollection<string> _ListCheDoXem;
        public ObservableCollection<string> ListCheDoXem { get => _ListCheDoXem; set { _ListCheDoXem = value; OnPropertyChanged(); } }
        private string _SelectedCheDoXem;
        public string SelectedCheDoXem { get => _SelectedCheDoXem; set { _SelectedCheDoXem = value; OnPropertyChanged(); } }
        private Visibility _VisibilityChonNam;
        public Visibility VisibilityChonNam { get => _VisibilityChonNam; set { _VisibilityChonNam = value; OnPropertyChanged(); } }
        private Visibility _VisibilityTuNgayDenNgay;
        public Visibility VisibilityTuNgayDenNgay { get => _VisibilityTuNgayDenNgay; set { _VisibilityTuNgayDenNgay = value; OnPropertyChanged(); } }
        private Visibility _VisibilityChart;
        public Visibility VisibilityChart { get => _VisibilityChart; set { _VisibilityChart = value; OnPropertyChanged(); } }

        private Visibility _VisibilityBang;
        public Visibility VisibilityBang { get => _VisibilityBang; set { _VisibilityBang = value; OnPropertyChanged(); } }
        private string _YearHeader;
        public string YearHeader { get => _YearHeader; set { _YearHeader = value; OnPropertyChanged(); } }
        private string _TomTatTon;
        public string TomTatTon { get => _TomTatTon; set { _TomTatTon = value; OnPropertyChanged(); } }
        private int _Maximum;
        public int Maximum { get => _Maximum; set { _Maximum = value; OnPropertyChanged(); } }
        private ObservableCollection<DiemBieuDoTonKho> _ChartData;
        public ObservableCollection<DiemBieuDoTonKho> ChartData
        {
            get => _ChartData;
            set { _ChartData = value; OnPropertyChanged(); }
        }
        private ObservableCollection<int> _ListYear;
        public ObservableCollection<int> ListYear { get => _ListYear; set { _ListYear = value; OnPropertyChanged(); } }
        private int _SelectedYear;
        public int SelectedYear { get => _SelectedYear; set { _SelectedYear = value; OnPropertyChanged(); } }
        public BaoCaoTonKho_ViewModel()
        {
            ListCheDoXem = new ObservableCollection<string>();
            ListCheDoXem.Add("Bảng");
            ListCheDoXem.Add("Biểu đồ cột");
            SelectedCheDoXem = "Bảng";
            showTableView();
            StartDateChangedCommand = new RelayCommand<object>((p) => { return true; },
            (p) =>
            {
                if (SelectedStartDate > SelectedEndDate)
                {
                    BaoCaoTonKho = new ObservableCollection<DongBaoCaoTonKho>();
                    VisibilityDatePickerPopup = Visibility.Visible;
                    PopupContent = "Ngày bắt đầu không được lớn hơn ngày kết thúc.";
                }
                else if (SelectedStartDate >= DateTime.Today || SelectedEndDate >= DateTime.Today)
                {
                    BaoCaoTonKho = new ObservableCollection<DongBaoCaoTonKho>();
                    VisibilityDatePickerPopup = Visibility.Visible;
                    PopupContent = "Phạm vi báo cáo phải từ quá khứ đến trước ngày hiện tại";
                }
                else if (SelectedStartDate.Year < 1900 || SelectedEndDate.Year < 1900)
                {
                    BaoCaoTonKho = new ObservableCollection<DongBaoCaoTonKho>();
                    VisibilityDatePickerPopup = Visibility.Visible;
                    PopupContent = "Năm được chọn phải sau thế kỷ thứ 18";
                }
                else

                    LoadData();
            });
            EndDateChangedCommand = new RelayCommand<object>((p) => { return true; },
            (p) =>
            {
                if (SelectedStartDate > SelectedEndDate)
                {
                    BaoCaoTonKho = new ObservableCollection<DongBaoCaoTonKho>();
                    VisibilityDatePickerPopup = Visibility.Visible;
                    PopupContent = "Ngày bắt đầu không được lớn hơn ngày kết thúc.";
                }
                else if (SelectedStartDate >= DateTime.Today || SelectedEndDate >= DateTime.Today)
                {
                    BaoCaoTonKho = new ObservableCollection<DongBaoCaoTonKho>();
                    VisibilityDatePickerPopup = Visibility.Visible;
                    PopupContent = "Phạm vi báo cáo phải từ quá khứ đến trước ngày hiện tại";
                }
                else if (SelectedStartDate.Year < 1900 || SelectedEndDate.Year < 1900)
                {
                    BaoCaoTonKho = new ObservableCollection<DongBaoCaoTonKho>();
                    VisibilityDatePickerPopup = Visibility.Visible;
                    PopupContent = "Năm được chọn phải sau thế kỷ thứ 18";
                }
                else
                    LoadData();
            });
            YearChangedCommand = new RelayCommand<object>((p) => { return true; },
            (p) =>
            {
                LoadChart();
            });
            CheDoXemChangedCommand = new RelayCommand<object>((p) => { return true; },
            (p) =>
            {
                if (SelectedCheDoXem == "Bảng")
                {
                    showTableView();
                }
                if (SelectedCheDoXem == "Biểu đồ cột")
                {
                    showChartView();
                }
            });
            PrintCommand = new RelayCommand<object>((q) =>
            {
                if (BaoCaoTonKho.Count == 0)
                    return false;
                return true;
            },
    (q) =>
    {
        BaoCaoTonKho_PrintPreview_ViewModel printPreviewBaoCaoTonKho = new BaoCaoTonKho_PrintPreview_ViewModel(BaoCaoTonKho, SelectedStartDate, SelectedEndDate, "*insert nguoi tao here");
        BaoCaoTonKho_PrintPreview PrintPreviewWindow = new BaoCaoTonKho_PrintPreview(printPreviewBaoCaoTonKho);
        PrintPreviewWindow.ShowDialog();
    }
);
        }

        private ObservableCollection<DongBaoCaoTonKho> _BaoCaoTonKho;
        public ObservableCollection<DongBaoCaoTonKho> BaoCaoTonKho
        {
            get => _BaoCaoTonKho;
            set { _BaoCaoTonKho = value; OnPropertyChanged(); }
        }

        void LoadChart()
        {
            ChartData = new ObservableCollection<DiemBieuDoTonKho>();
            YearHeader = "Năm " + SelectedYear.ToString();
            Maximum = 0;
            for (int i = 1; i < 13; i++)
            {
                DiemBieuDoTonKho diembieudotonkho = new DiemBieuDoTonKho();
                diembieudotonkho.Month = "Tháng " + i.ToString();
                var ThongKeNgay = new ObservableCollection<THONGKENGAY>(DataProvider.Ins.DB.THONGKENGAYs);
                var ChiTiet = new ObservableCollection<CT_THONGKENGAY>(DataProvider.Ins.DB.CT_THONGKENGAY);
                var MatHang = new ObservableCollection<MATHANG>(DataProvider.Ins.DB.MATHANGs);
                var DataQuery = from ct in ChiTiet
                                join tkn in ThongKeNgay on ct.MaThongKe equals tkn.MaThongKe
                                where (tkn.Ngay.Month == i && tkn.Ngay.Year==SelectedYear)
                                select new { ct.MaMH, ct.Nhap, ct.Xuat, ct.Ton };
                var GroupedDataQuery = DataQuery
                    .GroupBy(x => x.MaMH)
                    .Select(g => new
                    {
                        MaMH = g.Key,
                        Nhap = g.Sum(x => x.Nhap),
                        Xuat = g.Sum(x => x.Xuat),
                    });
                diembieudotonkho.Nhap = DataQuery.Sum(x => x.Nhap);
                diembieudotonkho.Xuat = DataQuery.Sum(x => x.Xuat);
                int TonCuoiThang = 0;
                foreach (var item in GroupedDataQuery)
                {
                    var toncuoithang = (from ct in ChiTiet
                                        join tkn in ThongKeNgay on ct.MaThongKe equals tkn.MaThongKe
                                        where (tkn.Ngay.Month == i && item.MaMH == ct.MaMH)
                                        select ct);
                    if (toncuoithang.Count() > 0)
                        TonCuoiThang += toncuoithang.Last().Ton;
                }
                diembieudotonkho.Ton = TonCuoiThang;
                if (diembieudotonkho.Nhap > Maximum)
                    Maximum = diembieudotonkho.Nhap;
                if (diembieudotonkho.Xuat > Maximum)
                    Maximum = diembieudotonkho.Xuat;
                if (TonCuoiThang > Maximum)
                    Maximum = TonCuoiThang;
                ChartData.Add(diembieudotonkho);
            }
            Maximum += 10;
        }
        void LoadData()
        {
            VisibilityDatePickerPopup = Visibility.Hidden;
            var ThongKeNgay = new ObservableCollection<THONGKENGAY>(DataProvider.Ins.DB.THONGKENGAYs);
            var ChiTiet = new ObservableCollection<CT_THONGKENGAY>(DataProvider.Ins.DB.CT_THONGKENGAY);
            var MatHang = new ObservableCollection<MATHANG>(DataProvider.Ins.DB.MATHANGs);
            var DataQuery = from ct in ChiTiet
                            join tkn in ThongKeNgay on ct.MaThongKe equals tkn.MaThongKe
                            where (tkn.Ngay >= SelectedStartDate && tkn.Ngay <= SelectedEndDate)
                            select new { ct.MaMH, ct.Nhap, ct.Xuat, ct.Ton };
            var GroupedDataQuery = DataQuery
                .GroupBy(x => x.MaMH)
                .Select(g => new
                {
                    MaMH = g.Key,
                    Nhap = g.Sum(x => x.Nhap),
                    Xuat = g.Sum(x => x.Xuat),
                });
            var ExtendedDataQuery = from gdq in GroupedDataQuery
                                    join mh in MatHang on gdq.MaMH equals mh.MaMH
                                    select new
                                    {
                                        gdq.MaMH,
                                        mh.TenMH,
                                        gdq.Nhap,
                                        gdq.Xuat,
                                    };
            BaoCaoTonKho = new ObservableCollection<DongBaoCaoTonKho>();
            int i = 1;
            foreach (var item in ExtendedDataQuery)
            {
                DongBaoCaoTonKho dongbaocao = new DongBaoCaoTonKho();
                dongbaocao.STT = i++;
                dongbaocao.MaMH = item.MaMH;
                dongbaocao.TenHang = item.TenMH;
                int tondauki = 0;
                int cotondauki = (from ct in ChiTiet
                                  join tkn in ThongKeNgay on ct.MaThongKe equals tkn.MaThongKe
                                  where (tkn.Ngay == SelectedStartDate.AddDays(-1) && item.MaMH == ct.MaMH)
                                  select ct).Count();
                if (cotondauki > 0)
                {
                    tondauki = (from ct in ChiTiet
                                join tkn in ThongKeNgay on ct.MaThongKe equals tkn.MaThongKe
                                where (tkn.Ngay == SelectedStartDate.AddDays(-1) && item.MaMH == ct.MaMH)
                                select ct).First().Ton;
                }
                dongbaocao.TonDauKi = tondauki;
                dongbaocao.Nhap = item.Nhap;
                dongbaocao.Xuat = item.Xuat;
                int toncuoiki = 0;
                int cotoncuoiki = (from ct in ChiTiet
                                   join tkn in ThongKeNgay on ct.MaThongKe equals tkn.MaThongKe
                                   where (tkn.Ngay == SelectedEndDate && item.MaMH == ct.MaMH)
                                   select ct).Count();
                if (cotoncuoiki > 0)
                {
                    toncuoiki = (from ct in ChiTiet
                                 join tkn in ThongKeNgay on ct.MaThongKe equals tkn.MaThongKe
                                 where (tkn.Ngay == SelectedEndDate && item.MaMH == ct.MaMH)
                                 select ct).First().Ton;
                }
                dongbaocao.TonCuoiKi = toncuoiki;
                BaoCaoTonKho.Add(dongbaocao);
            }
        }
        void showTableView()
        {
            VisibilityChonNam = Visibility.Hidden;
            VisibilityTuNgayDenNgay = Visibility.Visible;
            VisibilityChart = Visibility.Hidden;
            VisibilityBang = Visibility.Visible;
            VisibilityDatePickerPopup = Visibility.Hidden;
            SelectedStartDate = DateTime.Today.AddDays(-1);
            SelectedEndDate = DateTime.Today.AddDays(-1);
            LoadData();
        }

        void showChartView()
        {
            VisibilityTuNgayDenNgay = Visibility.Hidden;
            VisibilityChonNam = Visibility.Visible;
            ListYear = new ObservableCollection<int>();
            VisibilityBang = Visibility.Hidden;
            VisibilityChart = Visibility.Visible;
            for (int i = 4; i >= 0; i--)
            {
                ListYear.Add(DateTime.Today.Year - i);
            }
            SelectedYear = DateTime.Today.Year;
            LoadChart();
        }
 
    }
    public class DongBaoCaoTonKho
    {
        public int STT { get; set; }
        public string MaMH { get; set; }
        public string TenHang { get; set; }
        public int TonDauKi { get; set; }
        public int Nhap { get; set; }
        public int Xuat { get; set; }
        public int TonCuoiKi { get; set; }

    }
    public class DiemBieuDoTonKho
    {
        public string Month { get; set; }
        public int Nhap { get; set; }
        public int Xuat { get; set; }
        public int Ton { get; set; }
    }
}