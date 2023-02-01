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
using AdminPosDATN.Pages.PageCuahang;

namespace AdminPosDATN.Pages.PageCuahang
{
    /// <summary>
    /// Interaction logic for PageCuahang.xaml
    /// </summary>
    public partial class PageCuahang : Page
    {
        public PageCuahang()
        {
            InitializeComponent();
            Main.Content = new PageCuahangDS();
        }

        private void btnDS_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new PageCuahangDS();
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new PageCuahangThemSua();
        }
    }
}