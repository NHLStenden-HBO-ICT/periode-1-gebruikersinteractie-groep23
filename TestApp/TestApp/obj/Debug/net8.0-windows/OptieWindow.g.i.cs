﻿#pragma checksum "..\..\..\OptieWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "A06307EE71BA415D2D0E95E4D0564953076CA705"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
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
using TestApp;


namespace TestApp {
    
    
    /// <summary>
    /// OptieWindow
    /// </summary>
    public partial class OptieWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "..\..\..\OptieWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider sliderEffecten;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\OptieWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnTerug;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\OptieWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider sliderMuziek;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\OptieWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnEffecten;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\OptieWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image btnEffectenimg;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\OptieWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnMuziek;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\OptieWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image BtnMuziekimg;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\OptieWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtEffecten;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\OptieWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtMuziek;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.8.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/TestApp;component/optiewindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\OptieWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.8.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.sliderEffecten = ((System.Windows.Controls.Slider)(target));
            
            #line 23 "..\..\..\OptieWindow.xaml"
            this.sliderEffecten.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.sliderEffecten_ValueChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnTerug = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\..\OptieWindow.xaml"
            this.btnTerug.Click += new System.Windows.RoutedEventHandler(this.btnTerug_Click_1);
            
            #line default
            #line hidden
            return;
            case 3:
            this.sliderMuziek = ((System.Windows.Controls.Slider)(target));
            
            #line 27 "..\..\..\OptieWindow.xaml"
            this.sliderMuziek.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.sliderMuziek_ValueChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnEffecten = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\..\OptieWindow.xaml"
            this.btnEffecten.Click += new System.Windows.RoutedEventHandler(this.btnEffecten_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnEffectenimg = ((System.Windows.Controls.Image)(target));
            return;
            case 6:
            this.btnMuziek = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\..\OptieWindow.xaml"
            this.btnMuziek.Click += new System.Windows.RoutedEventHandler(this.btnMuziek_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.BtnMuziekimg = ((System.Windows.Controls.Image)(target));
            return;
            case 8:
            this.txtEffecten = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.txtMuziek = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

