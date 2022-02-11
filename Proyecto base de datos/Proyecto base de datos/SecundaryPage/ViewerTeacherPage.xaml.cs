using Npgsql;
using Proyecto_base_de_datos.Pages;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Proyecto_base_de_datos.pages;
using System.Diagnostics;

namespace Proyecto_base_de_datos.SecundaryPage
{
    /// <summary>
    /// Interaction logic for ViewerTeacherPage.xaml
    /// </summary>
    public partial class ViewerTeacherPage : Page
    {
        private List<DegreeWorks> list;
        public ViewerTeacherPage()
        {
            InitializeComponent();
            list = new List<DegreeWorks>();
            var conn = new Connection();
            conn.openConnection();

            using (var command = new NpgsqlCommand("SELECT \"T\".* FROM \"trabajos_de_grado\" AS \"T\", \"esrevisor\" AS \"ER\" WHERE \"T\".ncorrelativo = \"ER\".ncorrelativo AND \"ER\".cedulapi = '" + MainWindow.teachers.Id.ToString() + "' AND \"ER\".fecharev IS NULL ", conn.conn))
            {
                var reader = command.ExecuteReader();
                while(reader.Read())
                {
                    int correlativeNumber = Int32.Parse((String)reader["ncorrelativo"]);
                    String title = (String)reader["titulo"];
                    String modality = (String)reader["modalidad"];
                    DateTime dateTime = (DateTime)reader["fechacreacion"];
                    Trace.WriteLine(title);
                    Trace.WriteLine("AAAAAAA");
                    DegreeWorks degreeWorks = new DegreeWorks(correlativeNumber, title, dateTime.ToString(), modality);
                    list.Add(degreeWorks);
                    ViewerTeacherList.Items.Add(degreeWorks.CorrelativeNumber.ToString() + ", " + degreeWorks.Title);
                }
                reader.Close();
            }
        }

        private void RevisionButton_Click(object sender, RoutedEventArgs e)
        {
            var SelectedItem = ViewerTeacherList.Items.IndexOf(ViewerTeacherList.SelectedItem);
            ReviewerWindow reviewPage = new ReviewerWindow(list[SelectedItem]);
            reviewPage.ShowDialog();
        }

        private void ViewerTeacherList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        void OnMouseDoubleClick(object sender, MouseEventArgs e)
        {
            var list = (ListBox)sender;

            // This is your selected item
            int item = list.SelectedIndex;
            Trace.WriteLine(item);
            AddEvaluationCriteriaReviewer page = new AddEvaluationCriteriaReviewer(this.list[item]);
            page.ShowDialog();

        }
    }
}
