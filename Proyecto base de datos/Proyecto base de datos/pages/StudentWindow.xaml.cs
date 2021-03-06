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
    /// Interaction logic for StudentWindow.xaml
    /// </summary>
    public partial class StudentWindow : Window
    {
        public StudentWindow()
        {
            InitializeComponent();
            this.ResizeMode = ResizeMode.NoResize;
            CreateProposal createProposal = new CreateProposal();
            Frame1.Content = createProposal;
            ViewCouncils v = new ViewCouncils();
            Frame2.Content = v;

            ViewProposals view = new ViewProposals();
            Frame3.Content = view;

            StudentInformation st = new StudentInformation();
            FramePrincipal.Content = st;
        }
    }
}
