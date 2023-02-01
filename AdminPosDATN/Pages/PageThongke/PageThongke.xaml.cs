using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AdminPosDATN.Models;

namespace AdminPosDATN.Pages.PageThongke
{
    /// <summary>
    /// Interaction logic for PageThongke.xaml
    /// </summary>
    public partial class PageThongke : Page
    {
        public PageThongke()
        {
            
            InitializeComponent();
            if (CFunctionAdminPosDATN.CheckInternet() == false)
            {
                MessageBox.Show("Kiểm tra lại kết nối internet");
                return;
            }
            var hoadons = Task.Run(() => XuLyHoaDon.GetHoadons()).Result;
            if (hoadons.Count == 0)
            {
                MessageBox.Show("Chưa đọc xong dữ liệu, thử lại sau ít phút");
                return;
            }
            cboCuahang.Items.Add("Tát cả");
            var cuahangs = Task.Run(() => XulyCuahang.GetCuahangs()).Result;
            foreach (var i in cuahangs)
            {
                cboCuahang.Items.Add(i);
            }
            cboCuahang.SelectedIndex = 0;
            cboThang.Items.Add("Tất cả");
            for(int i = 1; i <= 12; i++)
            {
                cboThang.Items.Add(i);
            }
            cboThang.SelectedIndex = 0;
            hoadons.Sort((x, y) =>x.Ngaytt.Date.CompareTo(y.Ngaytt.Date));
            cboNam.Items.Add("Tất cả");
            
            for (int i= hoadons.First().Ngaytt.Year; i<=DateTime.Now.Year ; i++)
            {
                cboNam.Items.Add(i);
            }
            cboNam.SelectedIndex = cboNam.Items.IndexOf(DateTime.Now.Year);
            cboNgay.Items.Add("Tất cả");
            cboNgay.SelectedIndex = 0;
            Hienthi();
        }
        void Hienthi()
        {
            if (cboNam.Items.Count == 0 || cboThang.Items.Count == 0 || cboNgay.Items.Count == 0)
            {
                return;
            }
            //List<Hoadon> hoadons=new List<Hoadon>();
            //hoadons.AddRange(XuLyHoaDon.hoadons);
            var hoadons = Task.Run(() => XuLyHoaDon.GetHoadons()).Result;
            if (cboCuahang.SelectedIndex != 0)
            {
                List<Hoadon> hoadonxoas = new List<Hoadon>();
                foreach (var i in hoadons)
                {
                    if (i.Mach != ((Cuahang)cboCuahang.SelectedItem).Mach)
                    {
                        hoadonxoas.Add(i);
                    }
                }
                foreach (var i in hoadonxoas)
                {
                    hoadons.Remove(i);
                }
            }
            if (cboNam.SelectedIndex != 0)
            {
                List<Hoadon> hoadonxoas = new List<Hoadon>();
                foreach (var i in hoadons)
                {
                    if (i.Ngaytt.Year != (int)cboNam.SelectedItem)
                    {
                        hoadonxoas.Add(i);
                    }
                }
                foreach(var i in hoadonxoas)
                {
                    hoadons.Remove(i);
                }
            }
            if (cboThang.SelectedIndex != 0)
            {
                List<Hoadon> hoadonxoas = new List<Hoadon>();
                foreach (var i in hoadons)
                {
                    if (i.Ngaytt.Month != (int)cboThang.SelectedItem)
                    {
                        hoadonxoas.Add(i);
                    }
                }
                foreach (var i in hoadonxoas)
                {
                    hoadons.Remove(i);
                }
            }
            if (cboNgay.SelectedIndex != 0)
            {
                List<Hoadon> hoadonxoas = new List<Hoadon>();
                foreach (var i in hoadons)
                {
                    if (i.Ngaytt.Day != (int)cboNgay.SelectedItem)
                    {
                        hoadonxoas.Add(i);
                    }
                }
                foreach (var i in hoadonxoas)
                {
                    hoadons.Remove(i);
                }
            }
            HienthiText(hoadons);



        }

        void HienthiText(List<Hoadon> hoadons)
        {
            txtSohoadon.Text = hoadons.Count.ToString();
            double tongTien = 0;
            foreach (var i in hoadons)
            {
                tongTien += i.Thanhtien/1000;
            }
            txtTongdoanhthu.Text = tongTien.ToString();
        }

        private void cboCuahang_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Hienthi();
        }

        private void cboNam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Hienthi();
        }

        private void cboThang_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboThang.SelectedIndex == 0)
            {
                cboNgay.Items.Clear();
                cboNgay.Items.Add("Tất cả");
                cboNgay.SelectedIndex = 0;
            }
            int thangchon = cboThang.SelectedIndex;
            if (new[] { 1, 3, 5, 7, 8, 10, 12 }.Contains(thangchon))
            {
                cboNgay.Items.Clear();
                cboNgay.Items.Add("Tất cả");
                for (int i = 1; i <= 31; i++)
                {
                    cboNgay.Items.Add(i);
                }
                cboNgay.SelectedIndex = 0;
            }
            if (new[] { 4, 6, 9, 11 }.Contains(thangchon))
            {
                cboNgay.Items.Clear();
                cboNgay.Items.Add("Tất cả");
                for (int i = 1; i <= 30; i++)
                {
                    cboNgay.Items.Add(i);
                }
                cboNgay.SelectedIndex = 0;
            }
            if (thangchon == 2)
            {
                cboNgay.Items.Clear();
                cboNgay.Items.Add("Tất cả");
                for (int i = 1; i <= 29; i++)
                {
                    cboNgay.Items.Add(i);
                }
                cboNgay.SelectedIndex = 0;
            }
            Hienthi();
        }

        private void cboNgay_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Hienthi();
        }
    }
}
