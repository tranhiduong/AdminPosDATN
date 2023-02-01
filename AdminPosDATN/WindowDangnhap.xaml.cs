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
using System.Windows.Shapes;
using MahApps.Metro.Controls;

namespace AdminPosDATN
{
    /// <summary>
    /// Interaction logic for WindowDangnhap.xaml
    /// </summary>
    public partial class WindowDangnhap : MetroWindow
    {
        public WindowDangnhap()
        {
            InitializeComponent();
        }

        private void btnSignin_Click(object sender, RoutedEventArgs e)
        {
            
            if(txtUsername.Text!="admin")
            {
                MessageBox.Show("Tài khoản không tồn tại");
                return;
            }
            if(pwdPassword.Password!="admin")
            {
                MessageBox.Show("Sai mật khẩu");
                return;
            }
            if(CFunctionAdminPosDATN.CheckInternet()==false)
            {
                MessageBox.Show("Kiểm tra lại kết nối internet");
                return;
            }
            MessageBox.Show("Đăng nhập thành công");
            MainWindow mainWindow = new MainWindow();
            this.Hide();
            mainWindow.ShowDialog();
            this.Show();
        }
    }
}
