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

namespace AdminPosDATN.Pages.PageCoupon
{
    /// <summary>
    /// Interaction logic for PageCouponDS.xaml
    /// </summary>
    public partial class PageCouponDS : Page
    {
        public PageCouponDS()
        {
            InitializeComponent();
            if (CFunctionAdminPosDATN.CheckInternet() == false)
            {
                MessageBox.Show("Kiểm tra lại kết nối internet");
                return;
            }
            var coupons = Task.Run(() => XulyCoupon.GetCoupons()).Result;
            Hienthi(coupons);
        }
        private void Hienthi(List<Coupon> coupons)
        {
            
            this.Dispatcher.Invoke(() =>
            {
                dg.ItemsSource = null;
                //dg.Items.Clear();
                //dg.DataContext = null;
                //dg.Items.Refresh();
                dg.ItemsSource = coupons;
            });



        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {

            if (dg.SelectedItem == null)
            {
                MessageBox.Show("Xin hãy chọn coupon để xóa");
                return;
            }
            if (CFunctionAdminPosDATN.CheckInternet() == false)
            {
                MessageBox.Show("Kiểm tra lại kết nối internet");
                return;
            }
            var orders = Task.Run(() => XulyOrder.GetOrders()).Result;
            var coupon = (Coupon)dg.SelectedItem;
            if (orders.Exists(x => x.Coupon == coupon.Macp))
            {
                MessageBox.Show("Không thể xóa vì coupon đã tồn tại trong đơn hàng");
                return;
            }
            Task.Run(()=>XulyCoupon.DeleteCoupon(coupon)).Wait();
            MessageBox.Show("Xóa thành công");
            var coupons = Task.Run(() => XulyCoupon.GetCoupons()).Result;
            Hienthi(coupons);
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            if (CFunctionAdminPosDATN.CheckInternet() == false)
            {
                MessageBox.Show("Kiểm tra lại kết nối internet");
                return;
            }
            if (dg.SelectedItem == null)
            {
                MessageBox.Show("Xin hãy chọn coupon để sửa");
                return;

            }
            this.NavigationService.Navigate(new Pages.PageCoupon.PageCouponThemSua(((Coupon)dg.SelectedItem)));
        }

        private void btnTimKiem_Click(object sender, RoutedEventArgs e)
        {
            var coupons = Task.Run(() => XulyCoupon.GetCoupons()).Result;
            if (txtTimKiem.Text == "")
            {
                var couponts = coupons;
                Hienthi(couponts);
                return;
            }
            if (txtTimKiem.Text != "")
            {
                var couponts = coupons.Where(x => x.Macp == txtTimKiem.Text).ToList();
                Hienthi(couponts);
                return;
            }
        }
    }
}
