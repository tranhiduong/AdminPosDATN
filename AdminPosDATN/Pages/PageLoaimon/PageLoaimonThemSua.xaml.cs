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

namespace AdminPosDATN.Pages.PageLoaimon
{
    /// <summary>
    /// Interaction logic for PageLoaimonThem.xaml
    /// </summary>
    public partial class PageLoaimonThemSua : Page
    {
        public bool flagSua = false;
        public Loaimon loaimon;
        
        public PageLoaimonThemSua()
        {
            InitializeComponent();
        }
        public PageLoaimonThemSua(Loaimon loaimon)
        {
            InitializeComponent();
            flagSua = true;
            
            this.loaimon = loaimon;
            txtMaloai.Text = loaimon.Maloai;
            txtTenloai.Text = loaimon.Tenloai;
            txtMaloai.IsReadOnly = true;
        }

        private void btnLuu_Click(object sender, RoutedEventArgs e)
        {
            if (CFunctionAdminPosDATN.CheckInternet() == false)
            {
                MessageBox.Show("Kiểm tra lại kết nối internet");
                return;
            }
            if (txtMaloai.Text == "")
            {
                MessageBox.Show("Mã loại không được để trống");
                return;
            }
            if (txtTenloai.Text == "")
            {
                MessageBox.Show("Tên loại không được để trống");
                return;
            }
            if (flagSua == false)
            {
                var loaimons = Task.Run(() => XulyLoaimon.GetLoaimons()).Result;
                if (loaimons.Where(x => x.Maloai == txtMaloai.Text).Count() > 0)
                {
                    MessageBox.Show("Mã đã tồn tại");
                    return;
                }
                Loaimon loaimon = new Loaimon();
                loaimon.Maloai = txtMaloai.Text;
                loaimon.Tenloai = txtTenloai.Text;
                Task.Run(()=>XulyLoaimon.AddLoaimon(loaimon)).Wait();
                txtMaloai.Text = "";
                txtTenloai.Text = "";
                MessageBox.Show("Thêm thành công");
            }
            else
            {
                
                this.loaimon.Tenloai = txtTenloai.Text;
                Task.Run(() => XulyLoaimon.UpdateLoaimon(loaimon)).Wait();
                MessageBox.Show("Sửa thành công");
            }    
        }
    }
}
