using Proyecto_base_de_datos.SecundaryPage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Proyecto_base_de_datos.pages
{
    /// <summary>
    /// Interaction logic for TeacherWindow.xaml
    /// </summary>
    public partial class TeacherWindow : Window
    {
        public TeacherWindow()
        {
            InitializeComponent();
            this.ResizeMode = ResizeMode.NoResize;
            committeePage page = new committeePage();
            Frame1.Content = page;
            ViewerTeacherPage page2 = new ViewerTeacherPage();
            Frame2.Content = page2;
            CreateCouncil page3 = new CreateCouncil();
            Frame3.Content = page3;
            EvaluateDegreeWorkxaml page4 = new EvaluateDegreeWorkxaml();
            Frame4.Content = page4;

        }
        
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
    }
}
