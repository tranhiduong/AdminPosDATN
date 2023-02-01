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
    /// Interaction logic for PageCouponThemSua.xaml
    /// </summary>
    public partial class PageCouponThemSua : Page
    {
        bool flagSua = false;
        Coupon coupon;
        public PageCouponThemSua(Coupon coupon)
        {
            InitializeComponent();
           
            flagSua = true;

            this.coupon = coupon;
            txtMacp.Text =coupon.Macp;
            txtMucgiam.Text = coupon.Mucgiam;
            txtGiamtoida.Text = coupon.Giamtoida.ToString();
            txtSoluong.Text = coupon.Soluong.ToString();
            txtMacp.IsReadOnly = true;
            dpNgaybatdau.SelectedDate = DateTime.Parse(coupon.Ngaybatdau);
            dpNgayketthuc.SelectedDate = DateTime.Parse(coupon.Ngayketthuc);
            
           

        }
        public PageCouponThemSua()
        {
            InitializeComponent();
            txtGiamtoida.Text = 0.ToString();
            txtGiamtoida.IsEnabled = false;
            txtSoluong.Text = "0";
        }

        private void btnLuu_Click(object sender, RoutedEventArgs e)
        {
            if (CFunctionAdminPosDATN.CheckInternet() == false)
            {
                MessageBox.Show("Kiểm tra lại kết nối internet");
                return;
            }
            if (txtMacp.Text == "")
            {
                MessageBox.Show("Mã không được để trống");
                return;
            }
            if (txtMucgiam.Text == "")
            {
                MessageBox.Show("Mức giảm không được để trống");
                return;
            }
            int mucgiam;
            if (!int.TryParse(txtMucgiam.Text, out mucgiam))
            {
                MessageBox.Show("Mức giảm phải là số");
                return;
            }
            if (mucgiam <= 0)
            {
                MessageBox.Show("mức giảm không được bé hơn hoặc bằng không");
                return;
            }
            if (cbphantram.IsChecked == true)
            {
                if (mucgiam > 100)
                {
                    MessageBox.Show("Không được giảm trên 100%");
                    return;
                }
            }
            if (txtGiamtoida.Text == "")
            {
                    MessageBox.Show("Giảm tối đa không được để trống");
                    return;
                
            }
            int giamtoida;
            if (!int.TryParse(txtGiamtoida.Text, out giamtoida))
            {
                    MessageBox.Show("Giảm tối đa phải là số");
                    return;
                
            }
            if (giamtoida < 0)
            {
                
                    MessageBox.Show("Giảm tối đa phải lớn hơn hoặc bằng 0");
                    return;
            }
            int soluong;
            if (!int.TryParse(txtSoluong.Text, out soluong))
            {
                MessageBox.Show("Số lượng phải là số");
                return;

            }
            if (soluong < 0)
            {

                MessageBox.Show("số lượng phải lớn hơn hoặc bằng 0");
                return;
            }
            if (txtSoluong.Text == "")
            {
                MessageBox.Show("Số lượng không được để trống");
                return;
            }
            if(dpNgaybatdau.SelectedDate.Value.Date > dpNgayketthuc.SelectedDate.Value.Date)
            {
                MessageBox.Show("Ngày bắt đầu phải trước ngày kết thúc");
                return;
            }
            if (dpNgaybatdau.SelectedDate.Value.Date < DateTime.Now.Date)
            {
                MessageBox.Show("Ngày bắt đầu không được trước ngày hôm nay");
                return;
            }
            
            if (flagSua == false)
            {
                var coupons = Task.Run(() => XulyCoupon.GetCoupons()).Result;
                if (coupons.Where(x => x.Macp == txtMacp.Text).Count() > 0)
                {
                    MessageBox.Show("Mã đã tồn tại");
                    return;
                }
                Coupon coupon=new Coupon();
                coupon.Macp = txtMacp.Text;
                if (cbphantram.IsChecked == true)
                {
                    coupon.Mucgiam = txtMucgiam.Text+"%";

                }
                else
                {
                    coupon.Mucgiam = txtMucgiam.Text;
                }
                coupon.Makh = "";
                coupon.Giamtoida = int.Parse(txtGiamtoida.Text);
                if (cbsoluong.IsChecked == true)
                {
                    coupon.Soluong = -1;
                }
                else
                {
                    coupon.Soluong = int.Parse(txtSoluong.Text);
                }
                
                coupon.Ngaybatdau = dpNgaybatdau.SelectedDate.Value.Date.ToShortDateString();
                coupon.Ngayketthuc= dpNgayketthuc.SelectedDate.Value.Date.ToShortDateString();
                
                Task.Run(()=>XulyCoupon.AddCoupon(coupon)).Wait();
                txtMacp.Text = "";
                txtMucgiam.Text = "";
                txtGiamtoida.Text = "";
                txtSoluong.Text = "";
                txtGiamtoida.Text = 0.ToString();
                dpNgaybatdau.SelectedDate = DateTime.Now;
                dpNgayketthuc.SelectedDate = DateTime.Now;
                MessageBox.Show("Thêm thành công");

            }
            if (flagSua == true)
            {
                if (cbphantram.IsChecked == true)
                {
                    this.coupon.Mucgiam = txtMucgiam.Text + "%";

                }
                else
                {
                   this.coupon.Mucgiam = txtMucgiam.Text;
                }
                this.coupon.Makh = "";
                this.coupon.Giamtoida = int.Parse(txtGiamtoida.Text);
                this.coupon.Soluong = int.Parse(txtSoluong.Text);
                this.coupon.Ngaybatdau = dpNgaybatdau.SelectedDate.Value.Date.ToShortDateString();
                this.coupon.Ngayketthuc = dpNgayketthuc.SelectedDate.Value.Date.ToShortDateString();
                Task.Run(() => XulyCoupon.UpdateCoupon(this.coupon)).Wait();
                
                MessageBox.Show("Sửa thành công");
            }
        }



        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            txtGiamtoida.IsEnabled = true;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            txtGiamtoida.IsEnabled = false;
            txtGiamtoida.Text = 0.ToString();
        }

        private void cbsoluong_Checked(object sender, RoutedEventArgs e)
        {
            txtSoluong.IsEnabled = false;
            txtSoluong.Text = "0";
        }

        private void cbsoluong_Unchecked(object sender, RoutedEventArgs e)
        {
            txtSoluong.IsEnabled = true;
            txtSoluong.Text = "0";
        }
    }
}
