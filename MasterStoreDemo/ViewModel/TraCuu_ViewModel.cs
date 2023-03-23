using MasterStoreDemo.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using MasterStoreDemo.Helper;
using System.Data;
using System.Windows.Documents;
using MaterialDesignColors;
using System.Windows.Controls;

namespace MasterStoreDemo.ViewModel
{
    public class TraCuu_ViewModel : BaseViewModel
    {

        // new code from this hihi

        #region Declare Binding Variables
        private ObservableCollection<ListTheKho> _ListTK;
        public ObservableCollection<ListTheKho> ListTK
        {
            get { return _ListTK; }
            set { _ListTK = value; OnPropertyChanged(); }
        }

        private ObservableCollection<ListCTTheKho> _ListCTTK;
        public ObservableCollection<ListCTTheKho> ListCTTK
        {
            get { return _ListCTTK; }
            set { _ListCTTK = value; OnPropertyChanged(); }
        }

        private ListTheKho _SelectedTheKho;
        public ListTheKho SelectedTheKho
        {
            get { return _SelectedTheKho; }
            set { _SelectedTheKho = value; OnPropertyChanged(); }
        }

        private string _txtTenMH;
        public string txtTenMH
        {
            get { return _txtTenMH; }
            set { _txtTenMH = value; OnPropertyChanged(); }
        }

        private string _txtMaMH;
        public string txtMaMH
        {
            get { return _txtMaMH; }
            set { _txtMaMH = value; OnPropertyChanged(); }
        }

        #endregion

        #region Declare Icommand
        public ICommand SearchCommand { get; set; }
        public ICommand SelectionChangedCommand { get; set; }
        #endregion

        #region Sub Functions
        public void seach_TheKho()
        {
            if (string.IsNullOrWhiteSpace(txtTenMH))
                txtTenMH = "";
            if (String.IsNullOrWhiteSpace(txtMaMH))
                txtMaMH = "";

            ObservableCollection<THEKHO> list_TheKho = new ObservableCollection<THEKHO>(DataProvider.Ins.DB.THEKHOes);
            ListTK = new ObservableCollection<ListTheKho>();

            int stt = 1;

            foreach (var tk in list_TheKho)
                if (tk.MaMH.ToLower().Contains(txtMaMH) && tk.MATHANG.TenMH.ToLower().Contains(txtTenMH))
                {
                    ListTheKho temp = new ListTheKho(stt, tk);
                    stt++;
                    ListTK.Add(temp);
                }    
        }

        public void display_CTTK()
        {
            ListCTTK = new ObservableCollection<ListCTTheKho>();

            if (SelectedTheKho == null) return;
            string maThe = SelectedTheKho.MaThe;

            ObservableCollection<CT_THEKHO> list_CT = new ObservableCollection<CT_THEKHO>(DataProvider.Ins.DB.CT_THEKHO);
            int stt = 1;
            foreach (var ct in list_CT)
                if (ct.MaTheKho == maThe)
            {
                ListCTTheKho temp = new ListCTTheKho(stt, ct);
                stt++;
                ListCTTK.Add(temp);
            }
        }
        #endregion

        public TraCuu_ViewModel()
        {
            seach_TheKho();
            SearchCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {
                seach_TheKho();
            });

            SelectionChangedCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {
                display_CTTK();
            });
        }
    }
}