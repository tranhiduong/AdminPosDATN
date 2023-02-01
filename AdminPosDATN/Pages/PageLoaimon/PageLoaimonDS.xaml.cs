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
using AdminPosDATN.Pages;


namespace AdminPosDATN.Pages.PageLoaimon
{
    /// <summary>
    /// Interaction logic for PageLoaimonDS.xaml
    /// </summary>
    public partial class PageLoaimonDS : Page
    {
        public PageLoaimonDS()
        {
            InitializeComponent();
            if (CFunctionAdminPosDATN.CheckInternet() == false)
            {
                MessageBox.Show("Kiểm tra lại kết nối internet");
                return;
            }
            var loaimons = Task.Run(() => XulyLoaimon.GetLoaimons()).Result;
            Hienthi(loaimons);
        }

        private void Hienthi(List<Loaimon> loaimons)
        {
            dg.ItemsSource = null;
            //dg.Items.Clear();
            //dg.DataContext = null;
            //dg.Items.Refresh();
            dg.ItemsSource = loaimons;
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            if(dg.SelectedItem==null)
            {
                MessageBox.Show("Xin hãy chọn loại món để xóa");
                return;
            }
            if (CFunctionAdminPosDATN.CheckInternet() == false)
            {
                MessageBox.Show("Kiểm tra lại kết nối internet");
                return;
            }
            var loaimon= (Loaimon)dg.SelectedItem;
            Task.Run(()=>XulyLoaimon.DeleteLoaimon(loaimon)).Wait();
            MessageBox.Show("Xóa thành công");
            Hienthi(Task.Run(() => XulyLoaimon.GetLoaimons()).Result);
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            if (dg.SelectedItem == null)
            {
                MessageBox.Show("Xin hãy chọn loại món để sửa");
                return;

            }
            this.NavigationService.Navigate(new Pages.PageLoaimon.PageLoaimonThemSua(((Loaimon)dg.SelectedItem)));
            
        }

        private void btnTimKiem_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
