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
using Firebase.Database;
using Firebase.Database.Query;
using System.Reactive.Linq;
using FireSharp.Config;
using FireSharp;
using FireSharp.Response;

namespace AdminPosDATN.Pages.PageMon
{
    /// <summary>
    /// Interaction logic for PageMonDS.xaml
    /// </summary>
    public partial class PageMonDS : Page
    {
        public PageMonDS()
        {
            InitializeComponent();
            
            if (CFunctionAdminPosDATN.CheckInternet() == false)
            {
                MessageBox.Show("Kiểm tra lại kết nối internet");
                return;
            }
            cboLoaimon.Items.Add("Loại món(Tất cả)");
            foreach(var i in Task.Run(() => XulyLoaimon.GetLoaimons()).Result)
            {
                cboLoaimon.Items.Add(i);
            }
            cboLoaimon.SelectedIndex = 0;
            Hienthi(Task.Run(() => XulyMon.Getmons()).Result);
            //FirebaseConfig config = new FirebaseConfig
            //{
            //    BasePath = "https://banhangpos-42b12-default-rtdb.asia-southeast1.firebasedatabase.app/"
            //};
            //FireSharp.FirebaseClient client;
            //client = new FireSharp.FirebaseClient(config);
            //client.OnAsync("Mon", (sender, args, context) => {
            //    XulyMon.ReloadData();
            //    Hienthi(XulyMon.mons);
            //});


        }

        private void Hienthi(List<Mon> mons)
        {
            this.Dispatcher.Invoke(() =>
            {
                dg.ItemsSource = null;
                //dg.Items.Clear();
                //dg.DataContext = null;
                //dg.Items.Refresh();
                dg.ItemsSource = mons;
            });
                
            
            
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            if (dg.SelectedItem == null)
            {
                MessageBox.Show("Xin hãy chọn món để xóa");
                return;
            }
            if (CFunctionAdminPosDATN.CheckInternet() == false)
            {
                MessageBox.Show("Kiểm tra lại kết nối internet");
                return;
            }
            var mon = (Mon)dg.SelectedItem;
            Task.Run(() => XulyMon.DeleteMon(mon)).Wait();
            MessageBox.Show("Xóa thành công");
            Hienthi(Task.Run(() => XulyMon.Getmons()).Result);

        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            if (dg.SelectedItem == null)
            {
                MessageBox.Show("Xin hãy chọn món để sửa");
                return;

            }
            this.NavigationService.Navigate(new Pages.PageMon.PageMonThemSua(((Mon)dg.SelectedItem)));

        }

        private void btnTimKiem_Click(object sender, RoutedEventArgs e)
        {
            
            List<Mon> monst = Task.Run(() => XulyMon.Getmons()).Result;
            if (txtTimKiem.Text == "" &&cboLoaimon.SelectedIndex==0)
            {
                var mons = monst;
                Hienthi(mons);
                return;
            }
            if (txtTimKiem.Text == "" && cboLoaimon.SelectedIndex != 0)
            {
                var mons = monst.Where(x => x.Maloai == ((Loaimon)cboLoaimon.SelectedItem).Maloai).ToList();
                Hienthi(mons);
                return;
            }
            if(txtTimKiem.Text !=""&& cboLoaimon.SelectedIndex == 0)
            {
                var mons = monst.Where(x => (x.Mamon == txtTimKiem.Text)).ToList();
                Hienthi(mons);
                return;
            }
            if(txtTimKiem.Text != "" && cboLoaimon.SelectedIndex != 0)
            {
                var mons = monst.Where(x => (x.Mamon == txtTimKiem.Text)&&(x.Maloai== ((Loaimon)cboLoaimon.SelectedItem).Maloai)).ToList();
                Hienthi(mons);
                return;
            }
            
        }
    }
}
