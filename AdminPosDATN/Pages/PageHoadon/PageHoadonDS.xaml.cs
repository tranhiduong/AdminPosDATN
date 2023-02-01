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

namespace AdminPosDATN.Pages.PageHoadon
{
    /// <summary>
    /// Interaction logic for PageHoadonDS.xaml
    /// </summary>
    public partial class PageHoadonDS : Page
    {
        public PageHoadonDS()
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
            var hoadons = Task.Run(() => XuLyHoaDon.GetHoadons()).Result;
            Hienthi(hoadons);
        }

        private void Hienthi(List<Hoadon> hoadons)
        {
            dg.ItemsSource = null;

            dg.ItemsSource = hoadons;
        }

        private void btnTimKiem_Click(object sender, RoutedEventArgs e)
        {
            var hoadons = Task.Run(() => XuLyHoaDon.GetHoadons()).Result;
            if (txtTimKiem.Text == "" && cboCuahang.SelectedIndex == 0)
            {
                var hoadont = hoadons;
                Hienthi(hoadont);
                return;
            }
            if (txtTimKiem.Text == "" && cboCuahang.SelectedIndex != 0)
            {
                var hoadont = hoadons.Where(x => x.Mach == ((Cuahang)cboCuahang.SelectedItem).Mach).ToList();
                Hienthi(hoadont);
                return;
            }
            if (txtTimKiem.Text != "" && cboCuahang.SelectedIndex == 0)
            {
                var hoadont = hoadons.Where(x => (x.Mahd == txtTimKiem.Text)).ToList();
                Hienthi(hoadont);
                return;
            }
            if (txtTimKiem.Text != "" && cboCuahang.SelectedIndex != 0)
            {
                var hoadont = hoadons.Where(x => (x.Mahd == txtTimKiem.Text) && (x.Mach == ((Cuahang)cboCuahang.SelectedItem).Mach)).ToList();
                Hienthi(hoadont);
                return;
            }

        }
    }
}
