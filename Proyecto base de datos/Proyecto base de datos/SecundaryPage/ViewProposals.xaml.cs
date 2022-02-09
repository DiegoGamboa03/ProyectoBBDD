using System;
using Proyecto_base_de_datos.Class;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for ViewProposals.xaml
    /// </summary>
    public partial class ViewProposals : Page
    {
        private ObservableCollection<DegreeWorks> proposals = new ObservableCollection<DegreeWorks>();
        public ViewProposals()
        {
            InitializeComponent();
            AddExample();
        }
        private void AddExample()
        {
            for (int i = 1; i <= 10; i++)
            {
                proposals.Add(new DegreeWorks(i, "Propuesta de prueba ", "02-07-2022", "Instrumental"));
            }
            proposalsList.ItemsSource = proposals;
        }
    }
    }
