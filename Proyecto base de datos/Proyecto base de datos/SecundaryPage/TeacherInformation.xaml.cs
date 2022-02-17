using Proyecto_base_de_datos.Pages;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Proyecto_base_de_datos.SecundaryPage
{
    /// <summary>
    /// Interaction logic for TeacherInformation.xaml
    /// </summary>
    public partial class TeacherInformation : Page
    {
        public TeacherInformation()
        {
            InitializeComponent();
            idTextBlock.Text = MainWindow.teachers.Id;
            nameTextBlock.Text = MainWindow.teachers.Name;
            if (MainWindow.teachers.Type == "I")
            {
                typeTextBlock.Text = "Interno";
            }
            else if (MainWindow.teachers.Type == "E")
            {
                typeTextBlock.Text = "Externo";
            }
            else if (MainWindow.teachers.Type == "T")
            {
                typeTextBlock.Text = "Tutor Empresarial";
            }

        }

        private void addSpecialtyButton_Click(object sender, RoutedEventArgs e)
        {
            AddSpeciality page = new AddSpeciality();
            page.ShowDialog();
        }
    }
}
