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
using ControlPacientes.DatosLN;

namespace ControlPacientes.Inventario
{
    
    public partial class frmAdminControl : Window
    {
        string buscar = "";
        public frmAdminControl()
        {
            InitializeComponent();
        }
        HistorialPacienteLN oln = new HistorialPacienteLN();
        public void ListarHistorial()
        {
            dgDoctor.DataContext = oln.ViewHistorialPaciente();
        }
        public void ListarHistorialF(string val)
        {
            dgDoctor.DataContext = oln.ViewHistorialPacienteFiltro(val);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (txtBuscar.Text.Equals(""))
            {
                ListarHistorial();
            }
            else
            {
                string val = txtBuscar.Text;
                ListarHistorialF(val);
            }
        }


        private void txtBuscar_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtBuscar.Text.Equals(""))
            {
                ListarHistorial();
            }
            else
            {
                string val = txtBuscar.Text;
                ListarHistorialF(val);
            }
        }
    }
}
