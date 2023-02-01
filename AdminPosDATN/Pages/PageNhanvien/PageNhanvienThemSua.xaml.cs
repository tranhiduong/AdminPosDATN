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
    /// Interaction logic for PageNhanvienThemSua.xaml
    /// </summary>
    public partial class PageNhanvienThemSua : Page
    {
        public bool flagSua = false;
        public Nhanvien nv;
        public PageNhanvienThemSua()
        {
            InitializeComponent();
            var cuahangs = Task.Run(() => XulyCuahang.GetCuahangs()).Result;
            cboCuahang.ItemsSource = cuahangs;
            cboCuahang.SelectedIndex = 0;
            dpNgaysinh.SelectedDate = DateTime.Now;
        }

        public PageNhanvienThemSua(Nhanvien nv)
        {
            InitializeComponent();
            var cuahangs = Task.Run(() => XulyCuahang.GetCuahangs()).Result;
            cboCuahang.ItemsSource = cuahangs;
            cboCuahang.SelectedIndex = cboCuahang.Items.IndexOf(cuahangs.Find(x=>x.Mach==nv.Mach));
            flagSua = true;

            this.nv = nv;
            txtManv.Text = nv.Manv;
            txtManv.IsEnabled = false;
            txtTennv.Text = nv.Tennv;
            if (nv.Gioitinh == "Nam")
            {
                rdbNam.IsChecked = true;
            }
            else
            {
                rdbNu.IsChecked = false;
            }
            dpNgaysinh.SelectedDate = DateTime.Parse(nv.Ngaysinh);
            txtSdt.Text = nv.Sdt;
            txtDiachi.Text = nv.Diachi;
            txtEmail.Text = nv.Email;
            txtCmnd.Text = nv.Cmnd;
            txtMatkhau.Text = nv.Matkhau;

        }


        private void btnLuu_Click(object sender, RoutedEventArgs e)
        {
            if (CFunctionAdminPosDATN.CheckInternet() == false)
            {
                MessageBox.Show("Kiểm tra lại kết nối internet");
                return;
            }
            if (txtManv.Text == "")
            {
                MessageBox.Show("Mã nhân viên không được để trống");
                return;
            }
            if (txtTennv.Text == "")
            {
                MessageBox.Show("Tên nhân viên không được để trống");
                return;
            }
            if (txtSdt.Text == "")
            {
                MessageBox.Show("Số điện thoại không được để trống");
                return;
            }
            if (txtDiachi.Text == "")
            {
                MessageBox.Show("Địa chỉ không được để trống");
                return;
            }
            if (txtEmail.Text == "")
            {
                MessageBox.Show("Email không được để trống");
                return;
            }
            if (txtCmnd.Text == "")
            {
                MessageBox.Show("CMND không được để trống");
                return;
            }
            if (txtMatkhau.Text == "")
            {
                MessageBox.Show("Mật khẩu không được để trống");
                return;
            }
            if (flagSua == false)
            {
                var nhanviens = Task.Run(() => XuLyNhanVien.GetNhanviens()).Result;
                if (nhanviens.Where(x => x.Manv == txtManv.Text).Count() > 0)
                {
                    MessageBox.Show("Mã đã tồn tại");
                    return;
                }
                Nhanvien nv = new Nhanvien();
                nv.Manv = txtManv.Text;
                nv.Tennv = txtTennv.Text;
                nv.Ngaysinh = dpNgaysinh.SelectedDate.Value.ToShortDateString();
                nv.Sdt = txtSdt.Text;
                nv.Diachi = txtDiachi.Text;
                nv.Email = txtEmail.Text;
                nv.Cmnd = txtCmnd.Text;
                nv.Matkhau = txtMatkhau.Text;
                nv.Mach = ((Cuahang)cboCuahang.SelectedItem).Mach;
                if(rdbNam.IsChecked==true)
                {
                    nv.Gioitinh = "Nam";
                }
                else
                {
                    nv.Gioitinh = "Nữ";
                }
                Task.Run(()=>XuLyNhanVien.AddNhanvien(nv)).Wait();
                txtManv.Text = "";
                txtTennv.Text = "";
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

                this.nv.Manv = txtManv.Text;
                this.nv.Tennv = txtTennv.Text;
                this.nv.Ngaysinh = dpNgaysinh.SelectedDate.Value.ToShortDateString();
                this.nv.Sdt = txtSdt.Text;
                this.nv.Diachi = txtDiachi.Text;
                this.nv.Email = txtEmail.Text;
                this.nv.Cmnd = txtCmnd.Text;
                this.nv.Matkhau = txtMatkhau.Text;
                this.nv.Mach = ((Cuahang)cboCuahang.SelectedItem).Mach;
                if (rdbNam.IsChecked == true)
                {
                    this.nv.Gioitinh = "Nam";
                }
                else
                {
                    this.nv.Gioitinh = "Nữ";
                }
                Task.Run(()=>XuLyNhanVien.UpdateNhanvien(this.nv)).Wait();
                MessageBox.Show("Sửa thành công");
            }
        }
    }
}

