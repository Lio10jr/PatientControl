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
    /// Lógica de interacción para frmListaRegistros.xaml
    /// </summary>
    public partial class frmListaRegistros : Window
    {
        public frmListaRegistros()
        {
            InitializeComponent();
        }
        RegistrarseLN oln = new RegistrarseLN();
        public void ListarRegistros()
        {
            dgDoctor.DataContext = oln.ViewRregistro();
        }
        public void ListarRegistrosF(string val)
        {
            dgDoctor.DataContext = oln.ViewRegistrosFiltro(val);
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (txtBuscar.Text.Equals(""))
            {
                ListarRegistros();
            }
            else
            {
                string val = txtBuscar.Text;
                ListarRegistrosF(val);
            }
        }

        private void txtBuscar_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtBuscar.Text.Equals(""))
            {
                ListarRegistros();
            }
            else
            {
                string val = txtBuscar.Text;
                ListarRegistrosF(val);
            }
        }
    }
}
