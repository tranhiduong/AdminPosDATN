﻿#pragma checksum "..\..\..\..\..\Pages\PageHoadon\PageHoadonDS.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "705E95F7B0BE55EF8144D826ADAD1524BFEA7E7D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using AdminPosDATN.Pages.PageLoaimon;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace AdminPosDATN.Pages.PageHoadon {
    
    
    /// <summary>
    /// PageHoadonDS
    /// </summary>
    public partial class PageHoadonDS : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 25 "..\..\..\..\..\Pages\PageHoadon\PageHoadonDS.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnXoa;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\..\Pages\PageHoadon\PageHoadonDS.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSua;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\..\..\Pages\PageHoadon\PageHoadonDS.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtTimKiem;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\..\..\Pages\PageHoadon\PageHoadonDS.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnTimKiem;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\..\..\Pages\PageHoadon\PageHoadonDS.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cboCuahang;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\..\..\Pages\PageHoadon\PageHoadonDS.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dg;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.7.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/AdminPosDATN;component/pages/pagehoadon/pagehoadonds.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Pages\PageHoadon\PageHoadonDS.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.7.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.btnXoa = ((System.Windows.Controls.Button)(target));
            return;
            case 2:
            this.btnSua = ((System.Windows.Controls.Button)(target));
            return;
            case 3:
            this.txtTimKiem = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.btnTimKiem = ((System.Windows.Controls.Button)(target));
            
            #line 46 "..\..\..\..\..\Pages\PageHoadon\PageHoadonDS.xaml"
            this.btnTimKiem.Click += new System.Windows.RoutedEventHandler(this.btnTimKiem_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.cboCuahang = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.dg = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

