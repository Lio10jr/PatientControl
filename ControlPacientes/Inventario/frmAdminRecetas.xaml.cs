using ControlPacientes.DatosLN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ControlPacientes.Inventario
{
    /// <summary>
    /// Lógica de interacción para frmAdminRecetas.xaml
    /// </summary>
    public partial class frmAdminRecetas : Window
    {
        public frmAdminRecetas()
        {
            InitializeComponent();
        }
        RecetaLN oln = new RecetaLN();
        public void ListarPaciente()
        {
            dgDoctor.DataContext = oln.ViewReceta();
        }
        public void ListarPacienteF(string val)
        {
            dgDoctor.DataContext = oln.ViewRecetaFiltro(val);
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (txtBuscar.Text.Equals(""))
            {
                ListarPaciente();
            }
            else
            {
                string val = txtBuscar.Text;
                ListarPacienteF(val);
            }
        }

        private void txtBuscar_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtBuscar.Text.Equals(""))
            {
                ListarPaciente();
            }
            else
            {
                string val = txtBuscar.Text;
                ListarPacienteF(val);
            }
        }
    }
}
