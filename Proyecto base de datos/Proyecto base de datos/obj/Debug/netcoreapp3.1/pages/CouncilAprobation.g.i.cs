﻿#pragma checksum "..\..\..\..\Pages\CouncilAprobation.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "29AADEB8BA54A8E6C8089D4407C73DC35BC934AD"
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
    /// CouncilAprobation
    /// </summary>
    public partial class CouncilAprobation : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\..\Pages\CouncilAprobation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock titleTextBlock;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\Pages\CouncilAprobation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock modalityTextBlock;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\Pages\CouncilAprobation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock correlativeNumberTextBlock;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\Pages\CouncilAprobation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button approveButton;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\Pages\CouncilAprobation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DisapproveButton_;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\Pages\CouncilAprobation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox tutorList;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\Pages\CouncilAprobation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox firstJuryComboBox;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\Pages\CouncilAprobation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox firstsubstituteComboBox;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\Pages\CouncilAprobation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox secondJuryComboBox;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\..\Pages\CouncilAprobation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox secondSubstituteComboBox;
        
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
            System.Uri resourceLocater = new System.Uri("/Proyecto base de datos;component/pages/councilaprobation.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\CouncilAprobation.xaml"
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
            this.titleTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.modalityTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.correlativeNumberTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.approveButton = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\..\..\Pages\CouncilAprobation.xaml"
            this.approveButton.Click += new System.Windows.RoutedEventHandler(this.approveButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.DisapproveButton_ = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\..\..\Pages\CouncilAprobation.xaml"
            this.DisapproveButton_.Click += new System.Windows.RoutedEventHandler(this.DisapproveButton__Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.tutorList = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.firstJuryComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.firstsubstituteComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 9:
            this.secondJuryComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 10:
            this.secondSubstituteComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

