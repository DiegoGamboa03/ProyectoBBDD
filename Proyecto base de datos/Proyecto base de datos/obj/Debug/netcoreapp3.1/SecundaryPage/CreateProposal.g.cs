﻿#pragma checksum "..\..\..\..\SecundaryPage\CreateProposal.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "20731541FB41053383EE440C06595EFA93B0E309"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Proyecto_base_de_datos.SecundaryPage;
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


namespace Proyecto_base_de_datos.SecundaryPage {
    
    
    /// <summary>
    /// CreateProposal
    /// </summary>
    public partial class CreateProposal : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\..\SecundaryPage\CreateProposal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox teammatesComboBox;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\..\SecundaryPage\CreateProposal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox titleTextBox;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\..\SecundaryPage\CreateProposal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton instrumentalRadioButton;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\SecundaryPage\CreateProposal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton experimentalRadioButton;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\SecundaryPage\CreateProposal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox auxTextBox;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\SecundaryPage\CreateProposal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock endorsedTeacherText;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\SecundaryPage\CreateProposal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock businessTutorText;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\..\SecundaryPage\CreateProposal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock companyName;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\SecundaryPage\CreateProposal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox companyNameTextBox;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.12.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Proyecto base de datos;component/secundarypage/createproposal.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\SecundaryPage\CreateProposal.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.12.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.teammatesComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 2:
            this.titleTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.instrumentalRadioButton = ((System.Windows.Controls.RadioButton)(target));
            
            #line 16 "..\..\..\..\SecundaryPage\CreateProposal.xaml"
            this.instrumentalRadioButton.Checked += new System.Windows.RoutedEventHandler(this.RadioButton_Checked);
            
            #line default
            #line hidden
            return;
            case 4:
            this.experimentalRadioButton = ((System.Windows.Controls.RadioButton)(target));
            
            #line 17 "..\..\..\..\SecundaryPage\CreateProposal.xaml"
            this.experimentalRadioButton.Checked += new System.Windows.RoutedEventHandler(this.experimentalRadioButton_Checked);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 18 "..\..\..\..\SecundaryPage\CreateProposal.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.auxTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.endorsedTeacherText = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.businessTutorText = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.companyName = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 10:
            this.companyNameTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

