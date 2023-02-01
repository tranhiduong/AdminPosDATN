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
    /// Interaction logic for PageCuahangThemSua.xaml
    /// </summary>
    public partial class PageCuahangThemSua : Page
    {
        public bool flagSua = false;
        public Cuahang ch;
        public PageCuahangThemSua()
        {
            InitializeComponent();
        }

        public PageCuahangThemSua(Cuahang ch)
        {
            InitializeComponent();
            flagSua = true;

            this.ch = ch;
            txtMach.Text = ch.Mach;
            txtTench.Text = ch.Tench;
            txtDiachi.Text = ch.Diachi;
            txtSdt.Text = ch.Sdt;
            txtMach.IsReadOnly = true;

        }


        private void btnLuu_Click(object sender, RoutedEventArgs e)
        {
            if (CFunctionAdminPosDATN.CheckInternet() == false)
            {
                MessageBox.Show("Kiểm tra lại kết nối internet");
                return;
            }
            if (txtMach.Text == "")
            {
                MessageBox.Show("Mã cửa hàng không được để trống");
                return;
            }
            if (txtTench.Text == "")
            {
                MessageBox.Show("Tên cửa hàng không được để trống");
                return;
            }
            if (txtDiachi.Text == "")
            {
                MessageBox.Show("Địa chỉ không được để trống");
                return;
            }
            if (txtSdt.Text == "")
            {
                MessageBox.Show("Số điện thoại không được để trống");
                return;
            }
            if (flagSua == false)
            {
                var cuahangs = Task.Run(() => XulyCuahang.GetCuahangs()).Result;
                if (cuahangs.Where(x => x.Mach == txtMach.Text).Count() > 0)
                {
                    MessageBox.Show("Mã đã tồn tại");
                    return;
                }
                Cuahang ch = new Cuahang();
                ch.Mach = txtMach.Text;
                ch.Tench = txtTench.Text;
                ch.Diachi = txtDiachi.Text;
                ch.Sdt = txtSdt.Text;
                Task.Run(()=>XulyCuahang.AddCuahang(ch)).Wait();
                txtMach.Text = "";
                txtTench.Text = "";
                txtDiachi.Text = "";
                txtSdt.Text = "";
                MessageBox.Show("Thêm thành công");
            }
            else
            {

                this.ch.Tench = txtTench.Text;
                this.ch.Diachi = txtDiachi.Text;
                this.ch.Sdt = txtSdt.Text;
                Task.Run(()=>XulyCuahang.UpdateCuahang(ch)).Wait();
                MessageBox.Show("Sửa thành công");
            }

        }
    }
}
