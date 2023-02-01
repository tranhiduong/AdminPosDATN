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
    /// Interaction logic for PageKhachhangThemSua.xaml
    /// </summary>
    public partial class PageKhachhangThemSua : Page
    {
        public bool flagSua = false;
        public Khachhang kh;
        public PageKhachhangThemSua()
        {
            InitializeComponent();
            
            dpNgaysinh.SelectedDate = DateTime.Now;
        }

        public PageKhachhangThemSua(Khachhang kh)
        {
            InitializeComponent();
           
            flagSua = true;

            this.kh = kh;
            txtMakh.Text = kh.Makh;
            txtMakh.IsEnabled = false;
            txtTenkh.Text = kh.Tenkh;
            if (kh.Gioitinh == "Nam")
            {
                rdbNam.IsChecked = true;
            }
            else
            {
                rdbNu.IsChecked = true;
            }
            dpNgaysinh.SelectedDate = DateTime.Parse(kh.Ngaysinh);
            txtSdt.Text = kh.Sdt;
            txtDiachi.Text = kh.Diachi;
            txtEmail.Text = kh.Email;
            txtCmnd.Text = kh.Cmnd;
            txtMatkhau.Text = kh.Matkhau;

        }


        private void btnLuu_Click(object sender, RoutedEventArgs e)
        {
            if (CFunctionAdminPosDATN.CheckInternet() == false)
            {
                MessageBox.Show("Kiểm tra lại kết nối internet");
                return;
            }
            if (txtMakh.Text == "")
            {
                MessageBox.Show("Mã khách hàng không được để trống");
                return;
            }
            if (txtTenkh.Text == "")
            {
                MessageBox.Show("Tên khách hàng không được để trống");
                return;
            }
            if (txtSdt.Text == "")
            {
                MessageBox.Show("Số điện thoại không được để trống");
                return;
            }
            
            if (flagSua == false)
            {
                var khachhangs = Task.Run(() => XulyKhachhang.GetKhachhangs()).Result;
                if (khachhangs.Where(x => x.Makh == txtMakh.Text).Count() > 0)
                {
                    MessageBox.Show("Mã đã tồn tại");
                    return;
                }
                Khachhang kh = new Khachhang();
                kh.Makh = txtMakh.Text;
                kh.Tenkh = txtTenkh.Text;
                kh.Ngaysinh = dpNgaysinh.SelectedDate.Value.ToShortDateString();
                kh.Sdt = txtSdt.Text;
                kh.Diachi = txtDiachi.Text;
                kh.Email = txtEmail.Text;
                kh.Cmnd = txtCmnd.Text;
                kh.Matkhau = txtMatkhau.Text;
                
                if (rdbNam.IsChecked == true)
                {
                    kh.Gioitinh = "Nam";
                }
                else
                {
                    kh.Gioitinh = "Nữ";
                }
                Task.Run(()=>XulyKhachhang.AddKhachhang(kh)).Wait();
                txtMakh.Text = "";
                txtTenkh.Text = "";
                rdbNam.IsChecked = true;
                dpNgaysinh.SelectedDate = DateTime.Now;
                txtSdt.Text = "";
                txtDiachi.Text = "";
                txtEmail.Text = "";
                txtCmnd.Text = "";
                txtMatkhau.Text = "";

                MessageBox.Show("Thêm thành công");
            }
            else
            {

                this.kh.Makh = txtMakh.Text;
                this.kh.Tenkh = txtTenkh.Text;
                this.kh.Ngaysinh = dpNgaysinh.SelectedDate.Value.ToShortDateString();
                this.kh.Sdt = txtSdt.Text;
                this.kh.Diachi = txtDiachi.Text;
                this.kh.Email = txtEmail.Text;
                this.kh.Cmnd = txtCmnd.Text;
                this.kh.Matkhau = txtMatkhau.Text;
                
                if (rdbNam.IsChecked == true)
                {
                    this.kh.Gioitinh = "Nam";
                }
                else
                {
                    this.kh.Gioitinh = "Nữ";
                }
                Task.Run(()=>XulyKhachhang.UpdateKhachhang(this.kh)).Wait();
                MessageBox.Show("Sửa thành công");
            }
        }
    }
}

