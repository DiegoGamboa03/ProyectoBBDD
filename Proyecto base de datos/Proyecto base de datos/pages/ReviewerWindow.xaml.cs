using Proyecto_base_de_datos.Class;
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
    /// Interaction logic for ReviewerWindow.xaml
    /// </summary>
    public partial class ReviewerWindow : Window
    {
        private DegreeWorks degreeWorks;
        public ReviewerWindow(DegreeWorks DegreeWork)
        {
            InitializeComponent();
            this.degreeWorks = DegreeWork;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        void OnMouseDoubleClick(object sender, MouseEventArgs e)
        {
            var list = (ListBox)sender;

            // This is your selected item
            int item = list.SelectedIndex;

            Trace.WriteLine("AAAAA");
        }
    }
}
