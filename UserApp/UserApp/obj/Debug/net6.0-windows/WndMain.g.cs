﻿#pragma checksum "..\..\..\WndMain.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "A344B8418D6516C00C4568F6DEB96CE900AEBA05"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

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
        
        
        #line 20 "..\..\..\WndMain.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnTransf;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\WndMain.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnMy;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\WndMain.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnYour;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\WndMain.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock NmCard;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\WndMain.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock CVV;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\WndMain.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Validity;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\WndMain.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock fullname;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\WndMain.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtSupport;
        
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
            System.Uri resourceLocater = new System.Uri("/UserApp;component/wndmain.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\WndMain.xaml"
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
            
            #line 8 "..\..\..\WndMain.xaml"
            ((UserApp.WndMain)(target)).Activated += new System.EventHandler(this.Window_Activated);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 19 "..\..\..\WndMain.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnHystory_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.BtnTransf = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\..\WndMain.xaml"
            this.BtnTransf.Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.BtnMy = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\..\WndMain.xaml"
            this.BtnMy.Click += new System.Windows.RoutedEventHandler(this.BtnMy1);
            
            #line default
            #line hidden
            return;
            case 5:
            this.BtnYour = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\..\WndMain.xaml"
            this.BtnYour.Click += new System.Windows.RoutedEventHandler(this.BtnYour1);
            
            #line default
            #line hidden
            return;
            case 6:
            this.NmCard = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.CVV = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.Validity = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.fullname = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 10:
            this.BtSupport = ((System.Windows.Controls.Button)(target));
            
            #line 51 "..\..\..\WndMain.xaml"
            this.BtSupport.Click += new System.Windows.RoutedEventHandler(this.BtnSupport_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

