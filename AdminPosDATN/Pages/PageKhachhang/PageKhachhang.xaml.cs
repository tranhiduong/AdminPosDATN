﻿using System;
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

namespace AdminPosDATN.Pages.PageKhachhang
{
    /// <summary>
    /// Interaction logic for PageKhachhang.xaml
    /// </summary>
    public partial class PageKhachhang : Page
    {
        public PageKhachhang()
        {
            InitializeComponent();
            Main.Content = new PageKhachhangDS();
        }

        private void btnDS_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new PageKhachhangDS();
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new PageKhachhangThemSua();
        }
    }
}