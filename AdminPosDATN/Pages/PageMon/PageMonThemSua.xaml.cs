using AdminPosDATN.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace AdminPosDATN.Pages.PageMon
{
    /// <summary>
    /// Interaction logic for PageMonThemSua.xaml
    /// </summary>
    public partial class PageMonThemSua : Page
    {
        public bool flagSua=false;
        public Mon mon;
        public PageMonThemSua()
        {
            InitializeComponent();
            //cboLoaimon.Items.Add("Loại món");
            cboLoaimon.ItemsSource = Task.Run(() => XulyLoaimon.GetLoaimons()).Result;
            cboLoaimon.SelectedIndex = 0;
            
        }

        public PageMonThemSua(Mon mon)
        {
            InitializeComponent();
            var loaimons = Task.Run(() => XulyLoaimon.GetLoaimons()).Result;
            cboLoaimon.ItemsSource = loaimons;
            cboLoaimon.SelectedIndex = 0;
            flagSua = true;

            this.mon = mon;
            txtMamon.Text = mon.Mamon;
            txtTenmon.Text = mon.Tenmon;
            txtTenrutgon.Text = mon.Tenrutgon;
            txtDongia.Text = mon.Dongia.ToString();
            txtMamon.IsReadOnly = true;
            cboLoaimon.SelectedIndex = cboLoaimon.Items.IndexOf(loaimons.Find(x => x.Maloai == mon.Maloai));
            
        }


        private void btnLuu_Click(object sender, RoutedEventArgs e)
        {
            if (CFunctionAdminPosDATN.CheckInternet() == false)
            {
                MessageBox.Show("Kiểm tra lại kết nối internet");
                return;
            }
            if (txtMamon.Text == "")
            {
                MessageBox.Show("Mã món không được để trống");
                return;
            }
            if (txtTenmon.Text == "")
            {
                MessageBox.Show("Tên món không được để trống");
                return;
            }
            if (txtTenrutgon.Text == "")
            {
                MessageBox.Show("Tên rút gọn không được để trống");
                return;
            }
            if (txtDongia.Text == "")
            {
                MessageBox.Show("Đơn giá không được để trống");
                return;
            }
            if (flagSua == false)
            {
                if ((Task.Run(() => XulyMon.Getmons()).Result).Where(x => x.Mamon == txtMamon.Text).Count() > 0)
                {
                    MessageBox.Show("Mã đã tồn tại");
                    return;
                }
                Mon mon = new Mon();
                mon.Mamon = txtMamon.Text;
                mon.Tenmon = txtTenmon.Text;
                mon.Tenrutgon = txtTenrutgon.Text;
                mon.Dongia = int.Parse(txtDongia.Text);
                mon.Maloai = ((Loaimon)cboLoaimon.SelectedItem).Maloai;
                Task.Run(()=>XulyMon.AddMon(mon)).Wait();
               
                txtMamon.Text = "";
                txtTenmon.Text = "";
                txtTenrutgon.Text = "";
                txtDongia.Text = "";
                cboLoaimon.SelectedIndex = 0;
                MessageBox.Show("Thêm thành công");
            }
            else
            {

                this.mon.Tenmon = txtTenmon.Text;
                this.mon.Tenrutgon = txtTenrutgon.Text;
                this.mon.Dongia = int.Parse(txtDongia.Text);
                this.mon.Maloai = ((Loaimon)cboLoaimon.SelectedItem).Maloai;
                Task.Run(() => XulyMon.UpdateMon(this.mon)).Wait();
                MessageBox.Show("Sửa thành công");
            }
        }
    }
}
