﻿#pragma checksum "..\..\..\..\Pages\RegisterTeacher.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5E072659AB185818394AB3FB9F75886B07FFEFE5"
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
    /// RegisterTeacher
    /// </summary>
    public partial class RegisterTeacher : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\..\Pages\RegisterTeacher.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox idTextBox;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\..\Pages\RegisterTeacher.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox nameTextBox;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\..\Pages\RegisterTeacher.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox directionTextBox;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\..\Pages\RegisterTeacher.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox phoneNumberTextBox;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\..\Pages\RegisterTeacher.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox institutionTextBox;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\Pages\RegisterTeacher.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox TeacherTypeListComboBox;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\..\Pages\RegisterTeacher.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button RegisterButton;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\Pages\RegisterTeacher.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox passwordTextBox;
        
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
            System.Uri resourceLocater = new System.Uri("/Proyecto base de datos;component/pages/registerteacher.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\RegisterTeacher.xaml"
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
            return;
            case 2:
            this.nameTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.directionTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.phoneNumberTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.institutionTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.TeacherTypeListComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.RegisterButton = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\..\Pages\RegisterTeacher.xaml"
            this.RegisterButton.Click += new System.Windows.RoutedEventHandler(this.RegisterButton_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.passwordTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

