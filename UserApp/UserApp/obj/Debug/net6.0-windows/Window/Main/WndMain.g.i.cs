﻿#pragma checksum "..\..\..\..\..\Window\Main\WndMain.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0B5129CDDC148E9CD5C4C20D6F756C186B46E4AE"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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
using UserApp;


namespace UserApp {
    
    
    /// <summary>
    /// WndMain
    /// </summary>
    public partial class WndMain : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\..\..\Window\Main\WndMain.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid background;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\..\Window\Main\WndMain.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Media.RotateTransform transform;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\..\Window\Main\WndMain.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame MainFrame;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\..\..\Window\Main\WndMain.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox NmBill;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\..\..\Window\Main\WndMain.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border brdrotate;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\..\..\Window\Main\WndMain.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock NmCard;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\..\..\Window\Main\WndMain.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock CVV;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\..\..\Window\Main\WndMain.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Validity;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\..\..\Window\Main\WndMain.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock fullname;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\..\..\Window\Main\WndMain.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Menu;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\..\..\..\Window\Main\WndMain.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock login;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/UserApp;component/window/main/wndmain.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Window\Main\WndMain.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 9 "..\..\..\..\..\Window\Main\WndMain.xaml"
            ((UserApp.WndMain)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.background = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            
            #line 12 "..\..\..\..\..\Window\Main\WndMain.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnHystory_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 20 "..\..\..\..\..\Window\Main\WndMain.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnMin_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 23 "..\..\..\..\..\Window\Main\WndMain.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnClose_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.transform = ((System.Windows.Media.RotateTransform)(target));
            return;
            case 7:
            this.MainFrame = ((System.Windows.Controls.Frame)(target));
            return;
            case 8:
            this.NmBill = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 9:
            this.brdrotate = ((System.Windows.Controls.Border)(target));
            
            #line 46 "..\..\..\..\..\Window\Main\WndMain.xaml"
            this.brdrotate.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Border_MouseDown);
            
            #line default
            #line hidden
            return;
            case 10:
            this.NmCard = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 11:
            this.CVV = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 12:
            this.Validity = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 13:
            this.fullname = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 14:
            
            #line 73 "..\..\..\..\..\Window\Main\WndMain.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnCreate_Click);
            
            #line default
            #line hidden
            return;
            case 15:
            this.Menu = ((System.Windows.Controls.Grid)(target));
            return;
            case 16:
            
            #line 78 "..\..\..\..\..\Window\Main\WndMain.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnPanel_Click);
            
            #line default
            #line hidden
            return;
            case 17:
            this.login = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 18:
            
            #line 91 "..\..\..\..\..\Window\Main\WndMain.xaml"
            ((System.Windows.Controls.ListViewItem)(target)).MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.ListView_Home);
            
            #line default
            #line hidden
            return;
            case 19:
            
            #line 99 "..\..\..\..\..\Window\Main\WndMain.xaml"
            ((System.Windows.Controls.ListViewItem)(target)).MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.ListView_Transfer);
            
            #line default
            #line hidden
            return;
            case 20:
            
            #line 107 "..\..\..\..\..\Window\Main\WndMain.xaml"
            ((System.Windows.Controls.ListViewItem)(target)).MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.ListView_History);
            
            #line default
            #line hidden
            return;
            case 21:
            
            #line 115 "..\..\..\..\..\Window\Main\WndMain.xaml"
            ((System.Windows.Controls.ListViewItem)(target)).MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.ListView_Settings);
            
            #line default
            #line hidden
            return;
            case 22:
            
            #line 123 "..\..\..\..\..\Window\Main\WndMain.xaml"
            ((System.Windows.Controls.ListViewItem)(target)).MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.ListView_Exit);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

