#pragma checksum "..\..\..\..\Pages\EvaluateDegreeWorkWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "FEF2FAE345B4FF412DFEC5FF97DAFC341FC86ABC"
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
    /// EvaluateDegreeWorkWindow
    /// </summary>
    public partial class EvaluateDegreeWorkWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\..\..\Pages\EvaluateDegreeWorkWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock StudentName;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\..\Pages\EvaluateDegreeWorkWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock idStudent;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\Pages\EvaluateDegreeWorkWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TitleTDG;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\Pages\EvaluateDegreeWorkWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox criteriaEvaluationListBox;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\Pages\EvaluateDegreeWorkWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock adviseLabel;
        
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
            System.Uri resourceLocater = new System.Uri("/Proyecto base de datos;component/pages/evaluatedegreeworkwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\EvaluateDegreeWorkWindow.xaml"
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
            this.StudentName = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.idStudent = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.TitleTDG = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            
            #line 18 "..\..\..\..\Pages\EvaluateDegreeWorkWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.criteriaEvaluationListBox = ((System.Windows.Controls.ListBox)(target));
            
            #line 19 "..\..\..\..\Pages\EvaluateDegreeWorkWindow.xaml"
            this.criteriaEvaluationListBox.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.OnMouseDoubleClick);
            
            #line default
            #line hidden
            
            #line 19 "..\..\..\..\Pages\EvaluateDegreeWorkWindow.xaml"
            this.criteriaEvaluationListBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.criteriaEvaluationListBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.adviseLabel = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

