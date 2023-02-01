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
namespace AdminPosDATN.Pages.PageKhachhang
{
    /// <summary>
    /// Interaction logic for PageKhachhangDS.xaml
    /// </summary>
    public partial class PageKhachhangDS : Page
    {
        public PageKhachhangDS()
        {
            InitializeComponent();
            if (CFunctionAdminPosDATN.CheckInternet() == false)
            {
                MessageBox.Show("Kiểm tra lại kết nối internet");
                return;
            }
            var khachhangs = Task.Run(() => XulyKhachhang.GetKhachhangs()).Result;
            Hienthi(khachhangs);
        }

        private void Hienthi(List<Khachhang> khachhangs)
        {
            dg.ItemsSource = null;

            dg.ItemsSource = khachhangs;
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {

            if (dg.SelectedItem == null)
            {
                MessageBox.Show("Xin hãy khách hàng để xóa");
                return;
            }
            if (CFunctionAdminPosDATN.CheckInternet() == false)
            {
                MessageBox.Show("Kiểm tra lại kết nối internet");
                return;
            }
            var khachhang = (Khachhang)dg.SelectedItem;
            Task.Run(()=>XulyKhachhang.DeleteKhachhang(khachhang)).Wait();

            MessageBox.Show("Xóa thành công");
            var khachhangs = Task.Run(() => XulyKhachhang.GetKhachhangs()).Result;
            Hienthi(khachhangs);
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            if (dg.SelectedItem == null)
            {
                MessageBox.Show("Xin hãy nhân viên món để sửa");
                return;

            }
            this.NavigationService.Navigate(new Pages.PageKhachhang.PageKhachhangThemSua(((Khachhang)dg.SelectedItem)));

        }

        private void btnTimKiem_Click(object sender, RoutedEventArgs e)
        {
            var khachhangs = Task.Run(() => XulyKhachhang.GetKhachhangs()).Result;
            if (txtTimKiem.Text == "")
            {
                var khachhangt = khachhangs;
                Hienthi(khachhangt);
                return;
            }
            if (txtTimKiem.Text != "")
            {
                var khachhangt = khachhangs.Where(x => x.Makh == txtTimKiem.Text).ToList();
                Hienthi(khachhangt);
                return;
            }
        }
    }
}
