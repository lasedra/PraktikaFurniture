﻿#pragma checksum "..\..\..\UpdaterWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "AB54137C5DDFEB90B94C64281D6CEAC2812E7A50"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using PraktikaFurniture;
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


namespace PraktikaFurniture {
    
    
    /// <summary>
    /// UpdaterWindow
    /// </summary>
    public partial class UpdaterWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\..\UpdaterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel MessageStackPanel;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\UpdaterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock AvailableVersionsTextBlock;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\UpdaterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock MessageTextBlock;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\UpdaterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DockPanel MessageDockPanel;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\UpdaterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox VersionsComboBox;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\UpdaterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button UpdateBttn;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\UpdaterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel DownloadPanel;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\UpdaterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TagNameTextBox;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\UpdaterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock NoteTextBox;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\UpdaterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ProgressBar DownloadProgressBar;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.9.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/PraktikaFurniture;V1.0.0.0;component/updaterwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UpdaterWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.9.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.MessageStackPanel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 2:
            this.AvailableVersionsTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.MessageTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.MessageDockPanel = ((System.Windows.Controls.DockPanel)(target));
            return;
            case 5:
            this.VersionsComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.UpdateBttn = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\..\UpdaterWindow.xaml"
            this.UpdateBttn.Click += new System.Windows.RoutedEventHandler(this.UpdateBttn_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.DownloadPanel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 8:
            this.TagNameTextBox = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.NoteTextBox = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 10:
            this.DownloadProgressBar = ((System.Windows.Controls.ProgressBar)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

