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

namespace Proyecto_base_de_datos.Pages
{
    /// <summary>
    /// Interaction logic for ExternalTeacherWindow.xaml
    /// </summary>
    public partial class ExternalTeacherWindow : Window
    {
        public ExternalTeacherWindow()
        {
            InitializeComponent();
            this.ResizeMode = ResizeMode.NoResize;
            TeacherInformation mainPage = new TeacherInformation();
            mainFrame.Content = mainPage;
            EvaluateDegreeWorkExternal page4 = new EvaluateDegreeWorkExternal();
            Frame4.Content = page4;
            CreateSpecialty page5 = new CreateSpecialty();
            Frame5.Content = page5;
            PageEvaluationCriteria page6 = new PageEvaluationCriteria();
            Frame6.Content = page6;
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
