﻿#pragma checksum "..\..\..\..\Pages\RegisterStudent.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6B45B09B5619A6AA70EDE83E11D8606B12EA5332"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Proyecto_base_de_datos.pages;
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


namespace Proyecto_base_de_datos.pages {
    
    
    /// <summary>
    /// RegisterStudent
    /// </summary>
    public partial class RegisterStudent : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\..\Pages\RegisterStudent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox idTextBox;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\..\Pages\RegisterStudent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox nameTextBox;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\..\Pages\RegisterStudent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox phoneNumberTextBox;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\..\Pages\RegisterStudent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ucabMailTextBox;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\..\Pages\RegisterStudent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox mailTextBox;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\Pages\RegisterStudent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox passwordTextBox;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\..\Pages\RegisterStudent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox bonusAtributteTextBox;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\Pages\RegisterStudent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button RegisterButton;
        
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
            System.Uri resourceLocater = new System.Uri("/Proyecto base de datos;component/pages/registerstudent.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\RegisterStudent.xaml"
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
            this.idTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 10 "..\..\..\..\Pages\RegisterStudent.xaml"
            this.idTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.idTextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.nameTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 11 "..\..\..\..\Pages\RegisterStudent.xaml"
            this.nameTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.nameTextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.phoneNumberTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.ucabMailTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.mailTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.passwordTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.bonusAtributteTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.RegisterButton = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\..\..\Pages\RegisterStudent.xaml"
            this.RegisterButton.Click += new System.Windows.RoutedEventHandler(this.RegisterButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

