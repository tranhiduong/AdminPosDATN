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
using MahApps.Metro.Controls;
using AdminPosDATN.Models;
using AdminPosDATN.Pages.PageLoaimon;
using AdminPosDATN.Pages.PageMon;
using AdminPosDATN.Pages.PageCuahang;
using AdminPosDATN.Pages.PageNhanvien;
using AdminPosDATN.Pages.PageKhachhang;
using AdminPosDATN.Pages.PageHoadon;
using AdminPosDATN.Pages.PageCoupon;
using AdminPosDATN.Pages.PageThongke;

namespace AdminPosDATN
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
      
        public MainWindow()
        {
            InitializeComponent();
            
            
        }

        private void btnLoaiMon_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new PageLoaimon();
        }

        private void btnMon_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new PageMon();
        }

        private void btnNhanvien_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new PageNhanvien();
        }

        private void btnCuahang_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new PageCuahang();
        }

        private void btnKhachhang_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new PageKhachhang();
        }

        private void btnHoaDon_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new PageHoadon();
        }

        private void btnThongKe_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new PageThongke();
        }

        private void btnThongKe_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void btnCoupon_Click(object sender, RoutedEventArgs e)
        {
            Main.Content=new PageCoupon();
        }
    }
}
