#pragma checksum "..\..\..\..\..\Pages\PageMon\PageMonThemSua.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "472D4056BB0E1AB2488CFB664C782C26EF930838"
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


namespace AdminPosDATN.Pages.PageMon {
    
    
    /// <summary>
    /// PageMonThemSua
    /// </summary>
    public partial class PageMonThemSua : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 25 "..\..\..\..\..\Pages\PageMon\PageMonThemSua.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtMamon;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\..\Pages\PageMon\PageMonThemSua.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtTenmon;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\..\Pages\PageMon\PageMonThemSua.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtTenrutgon;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\..\Pages\PageMon\PageMonThemSua.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtDongia;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\..\Pages\PageMon\PageMonThemSua.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cboLoaimon;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\..\..\Pages\PageMon\PageMonThemSua.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnLuu;
        
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
            System.Uri resourceLocater = new System.Uri("/AdminPosDATN;component/pages/pagemon/pagemonthemsua.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Pages\PageMon\PageMonThemSua.xaml"
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
            this.txtMamon = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.txtTenmon = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txtTenrutgon = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.txtDongia = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.cboLoaimon = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.btnLuu = ((System.Windows.Controls.Button)(target));
            
            #line 45 "..\..\..\..\..\Pages\PageMon\PageMonThemSua.xaml"
            this.btnLuu.Click += new System.Windows.RoutedEventHandler(this.btnLuu_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

