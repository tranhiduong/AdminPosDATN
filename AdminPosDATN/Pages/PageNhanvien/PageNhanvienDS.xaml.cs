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

namespace AdminPosDATN.Pages.PageNhanvien
{
    /// <summary>
    /// Interaction logic for PageNhanvienDS.xaml
    /// </summary>
    public partial class PageNhanvienDS : Page
    {
        public PageNhanvienDS()
        {
            InitializeComponent();
            if (CFunctionAdminPosDATN.CheckInternet() == false)
            {
                MessageBox.Show("Kiểm tra lại kết nối internet");
                return;
            }
            cboCuahang.Items.Add("Cửa hàng(Tất cả)");
            var cuahangs = Task.Run(() => XulyCuahang.GetCuahangs()).Result;
            foreach (var i in cuahangs)
            {
                cboCuahang.Items.Add(i);
            }
            cboCuahang.SelectedIndex = 0;
            var nhanviens = Task.Run(() => XuLyNhanVien.GetNhanviens()).Result;
            Hienthi(nhanviens);
        }

        private void Hienthi(List<Nhanvien> nhanviens)
        {
            dg.ItemsSource = null;
            
            dg.ItemsSource = nhanviens;
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            if (dg.SelectedItem == null)
            {
                MessageBox.Show("Xin hãy chọn nhân viên để xóa");
                return;
            }
            if (CFunctionAdminPosDATN.CheckInternet() == false)
            {
                MessageBox.Show("Kiểm tra lại kết nối internet");
                return;
            }
            var nhanvien = (Nhanvien)dg.SelectedItem;
            Task.Run(()=>XuLyNhanVien.DeleteNhanvien(nhanvien)).Wait();
          
            MessageBox.Show("Xóa thành công");
            var nhanviens = Task.Run(() => XuLyNhanVien.GetNhanviens()).Result;
            Hienthi(nhanviens);
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            if (dg.SelectedItem == null)
            {
                MessageBox.Show("Xin hãy nhân viên món để sửa");
                return;

            }
            if (CFunctionAdminPosDATN.CheckInternet() == false)
            {
                MessageBox.Show("Kiểm tra lại kết nối internet");
                return;
            }
            this.NavigationService.Navigate(new Pages.PageNhanvien.PageNhanvienThemSua(((Nhanvien)dg.SelectedItem)));

        }

        private void btnTimKiem_Click(object sender, RoutedEventArgs e)
        {
            var nhanvient = Task.Run(() => XuLyNhanVien.GetNhanviens()).Result;
            if (txtTimKiem.Text == "" && cboCuahang.SelectedIndex == 0)
            {

                var nhanviens = nhanvient;
                Hienthi(nhanviens);
                return;
            }
            if (txtTimKiem.Text == "" && cboCuahang.SelectedIndex != 0)
            {
                var nhanviens = nhanvient.Where(x => x.Mach == ((Cuahang)cboCuahang.SelectedItem).Mach).ToList();
                Hienthi(nhanviens);
                return;
            }
            if (txtTimKiem.Text != "" && cboCuahang.SelectedIndex == 0)
            {
                var nhanviens = nhanvient.Where(x => (x.Manv == txtTimKiem.Text)).ToList();
                Hienthi(nhanviens);
                return;
            }
            if (txtTimKiem.Text != "" && cboCuahang.SelectedIndex != 0)
            {
                var nhanviens = nhanvient.Where(x => (x.Manv == txtTimKiem.Text) && (x.Mach == ((Cuahang)cboCuahang.SelectedItem).Mach)).ToList();
                Hienthi(nhanviens);
                return;
            }
        }
    }
}
