using Proyecto_base_de_datos.SecundaryPage;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public static TeacherInformation mainPage;
        committeePage page;
        ViewerTeacherPage page2;
        CreateCouncil page3;
        EvaluateDegreeWorkxaml page4;
        CreateSpecialty page5;
        PageEvaluationCriteria page6;
        public TeacherWindow()
        {
            InitializeComponent();
            this.ResizeMode = ResizeMode.NoResize;
            mainPage = new TeacherInformation();
            mainFrame.Content = mainPage;
            page = new committeePage();
            Frame1.Content = page;
            page2 = new ViewerTeacherPage();
            Frame2.Content = page2;
            page3 = new CreateCouncil();
            Frame3.Content = page3;
            page4 = new EvaluateDegreeWorkxaml();
            Frame4.Content = page4;
            page5 = new CreateSpecialty();
            Frame5.Content = page5;
            page6 = new PageEvaluationCriteria();
            Frame6.Content = page6;
        }
        
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
