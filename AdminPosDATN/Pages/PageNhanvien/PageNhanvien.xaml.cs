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

namespace AdminPosDATN.Pages.PageNhanvien
{
    /// <summary>
    /// Interaction logic for PageNhanvien.xaml
    /// </summary>
    public partial class PageNhanvien : Page
    {
        public PageNhanvien()
        {
            InitializeComponent();
            Main.Content = new PageNhanvienDS();
        }

        private void btnDS_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new PageNhanvienDS();
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new PageNhanvienThemSua();
        }
    }
}