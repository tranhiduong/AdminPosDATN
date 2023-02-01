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

namespace AdminPosDATN.Pages.PageCuahang
{
    /// <summary>
    /// Interaction logic for PageCuahangDS.xaml
    /// </summary>
    public partial class PageCuahangDS : Page
    {
        public PageCuahangDS()
        {
            InitializeComponent();
            if (CFunctionAdminPosDATN.CheckInternet() == false)
            {
                MessageBox.Show("Kiểm tra lại kết nối internet");
                return;
            }
            Hienthi(Task.Run(()=>XulyCuahang.GetCuahangs()).Result);
        }

        private void Hienthi(List<Cuahang> cuahangs)
        {
            dg.ItemsSource = null;
            //dg.Items.Clear();
            //dg.DataContext = null;
            //dg.Items.Refresh();
            dg.ItemsSource = cuahangs;
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            if (dg.SelectedItem == null)
            {
                MessageBox.Show("Xin hãy chọn cửa hàng để xóa");
                return;
            }
            if (CFunctionAdminPosDATN.CheckInternet() == false)
            {
                MessageBox.Show("Kiểm tra lại kết nối internet");
                return;
            }
            var cuahang = (Cuahang)dg.SelectedItem;
            Task.Run(()=>XulyCuahang.DeleteCuahang(cuahang)).Wait();
            MessageBox.Show("Xóa thành công");
            Hienthi(Task.Run(() => XulyCuahang.GetCuahangs()).Result);
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            if (dg.SelectedItem == null)
            {
                MessageBox.Show("Xin hãy chọn cửa hàng để sửa");
                return;

            }
            this.NavigationService.Navigate(new Pages.PageCuahang.PageCuahangThemSua(((Cuahang)dg.SelectedItem)));

        }
    }
}
