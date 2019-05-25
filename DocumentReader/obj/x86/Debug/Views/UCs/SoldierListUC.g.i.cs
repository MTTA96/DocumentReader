﻿#pragma checksum "..\..\..\..\..\Views\UCs\SoldierListUC.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6C8FB2CF236815447AB457873C243BD1650BD1B5"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using DocumentReader;
using DocumentReader.Views.UCs;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using ShowMeTheXAML;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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


namespace DocumentReader.Views.UCs {
    
    
    /// <summary>
    /// SoldierListUC
    /// </summary>
    public partial class SoldierListUC : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\..\..\..\Views\UCs\SoldierListUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCreateSoldier;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\..\Views\UCs\SoldierListUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnEditSoldier;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\..\Views\UCs\SoldierListUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDeleteSoldier;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\..\Views\UCs\SoldierListUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnViewDocument;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\..\..\Views\UCs\SoldierListUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lvSoldierList;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/DocumentReader;component/views/ucs/soldierlistuc.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Views\UCs\SoldierListUC.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 11 "..\..\..\..\..\Views\UCs\SoldierListUC.xaml"
            ((DocumentReader.Views.UCs.SoldierListUC)(target)).Loaded += new System.Windows.RoutedEventHandler(this.UserControl_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnCreateSoldier = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\..\..\..\Views\UCs\SoldierListUC.xaml"
            this.btnCreateSoldier.Click += new System.Windows.RoutedEventHandler(this.BtnCreateSoldier_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnEditSoldier = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\..\..\..\Views\UCs\SoldierListUC.xaml"
            this.btnEditSoldier.Click += new System.Windows.RoutedEventHandler(this.BtnEditSoldier_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnDeleteSoldier = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\..\..\..\Views\UCs\SoldierListUC.xaml"
            this.btnDeleteSoldier.Click += new System.Windows.RoutedEventHandler(this.BtnDeleteSoldier_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnViewDocument = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\..\..\..\Views\UCs\SoldierListUC.xaml"
            this.btnViewDocument.Click += new System.Windows.RoutedEventHandler(this.BtnViewDocument_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.lvSoldierList = ((System.Windows.Controls.ListView)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
