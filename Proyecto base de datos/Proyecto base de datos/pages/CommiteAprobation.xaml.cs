using Npgsql;
using Proyecto_base_de_datos.Class;
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

namespace Proyecto_base_de_datos.Pages
{
    /// <summary>
    /// Interaction logic for CommiteAprobation.xaml
    /// </summary>
    public partial class CommiteAprobation : Window
    {
        public CommiteAprobation(DegreeWorks degreeWorks, String correlativeNumber)
        {
            InitializeComponent();
            titleTextBlock.Text = degreeWorks.Title;
            modalityTextBlock.Text = degreeWorks.Title;
            correlativeNumberTextBlock.Text = degreeWorks.CorrelativeNumber.ToString();
          
        }

        private void approveButton_Click(object sender, RoutedEventArgs e)
        {
            var conn = new Connection();
            conn.openConnection();
            using (var command = new NpgsqlCommand("INSERT INTO esrevisor (ncorrelativo, codigoc, cedulapi, fechasig,estatus,fecharev) VALUES (@n1,@n2,@n3)", conn.conn))
            {
                String dateTimeString = DateTime.Today.Year + "-" + DateTime.Today.Month + "-" + DateTime.Today.Day;
                DateTime dateTime = DateTime.Parse(dateTimeString);
                command.Parameters.AddWithValue("n4", dateTime);
                int nRows = command.ExecuteNonQuery();
                Console.Out.WriteLine(String.Format("Number of rows inserted={0}", nRows));
            }
        }


    }
}
