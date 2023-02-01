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

namespace AdminPosDATN.Pages.PageMon
{
    /// <summary>
    /// Interaction logic for PageMon.xaml
    /// </summary>
    public partial class PageMon : Page
    {
        public PageMon()
        {
            InitializeComponent();
            Main.Content = new PageMonDS();
        }

        private void btnDS_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new PageMonDS();
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new PageMonThemSua();
        }
    }
}
