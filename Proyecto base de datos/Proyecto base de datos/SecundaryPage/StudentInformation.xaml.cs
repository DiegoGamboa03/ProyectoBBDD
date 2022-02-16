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
    /// Interaction logic for StudentInformation.xaml
    /// </summary>
    public partial class StudentInformation : Page
    {
        public StudentInformation()
        {
            InitializeComponent();
            idTextBlock.Text = MainWindow.student.Id;
            nameTextBlock.Text = MainWindow.student.Name;
            phoneTextBlock.Text = MainWindow.student.PhoneNumber;
            mailTextBlock.Text = MainWindow.student.PersonalEmail;
            instucionalMailTextBlock.Text = MainWindow.student.UcabMail;
        }
    }
}
