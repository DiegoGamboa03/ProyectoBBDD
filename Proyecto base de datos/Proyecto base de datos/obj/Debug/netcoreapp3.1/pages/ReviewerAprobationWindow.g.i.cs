﻿#pragma checksum "..\..\..\..\Pages\ReviewerAprobationWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "15384CC0B8F1C5CC83E7BBACF58D4E4333E3C79C"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Proyecto_base_de_datos.Pages;
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


namespace Proyecto_base_de_datos.Pages {
    
    
    /// <summary>
    /// ReviewerAprobationWindow
    /// </summary>
    public partial class ReviewerAprobationWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\..\Pages\ReviewerAprobationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ApprobationButton;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\..\Pages\ReviewerAprobationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button disapprovalButton;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\Pages\ReviewerAprobationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock titleTextBlock;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\Pages\ReviewerAprobationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock modalityTextBlock;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\Pages\ReviewerAprobationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock correlativeNumberTextBlock;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\Pages\ReviewerAprobationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock evaluationCriteriaTitleTextBlock;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.6.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Proyecto base de datos;V1.0.0.0;component/pages/revieweraprobationwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\ReviewerAprobationWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.6.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.ApprobationButton = ((System.Windows.Controls.Button)(target));
            
            #line 10 "..\..\..\..\Pages\ReviewerAprobationWindow.xaml"
            this.ApprobationButton.Click += new System.Windows.RoutedEventHandler(this.ApprobationButton_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.disapprovalButton = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\..\..\Pages\ReviewerAprobationWindow.xaml"
            this.disapprovalButton.Click += new System.Windows.RoutedEventHandler(this.disapprovalButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.titleTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.modalityTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.correlativeNumberTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.evaluationCriteriaTitleTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

