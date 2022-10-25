using ControlPacientes.Inventario;
using ControlPacientes.Reports;
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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace ControlPacientes
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindow(string tipo)
        {
            InitializeComponent();
            MenuRegistro.IsEnabled = false;
            MenuTrabajadores.IsEnabled = false;
            MenuReportesCD.IsEnabled = false;
        }
        private void btnCrearFichasM_Click(object sender, RoutedEventArgs e)
        {
            frmEditFichaMedica frm = new frmEditFichaMedica();
            frm.ShowDialog();
        }

        private void btnverFichas_Click(object sender, RoutedEventArgs e)
        {
            frmAdminFichasMedicas frm = new frmAdminFichasMedicas();
            frm.ShowDialog();
        }

        private void btnCrearRecetas_Click(object sender, RoutedEventArgs e)
        {
            frmEditRecetas frm = new frmEditRecetas();
            frm.list.Clear();
            frm.ShowDialog();
        }

        private void btnControlP_Click(object sender, RoutedEventArgs e)
        {
            frmAdminControl frm = new frmAdminControl();
            frm.ShowDialog();
        }

        private void btVerMedicamentos_Click(object sender, RoutedEventArgs e)
        {
            frmAdminMedicamentos frm = new frmAdminMedicamentos();
            frm.ShowDialog();
        }

        private void btVerMedicamentos_Click1(object sender, RoutedEventArgs e)
        {
            frmAdminMedicamentos frm = new frmAdminMedicamentos();
            frm.ShowDialog();
        }

        private void btnCrearRecetas_Click1(object sender, RoutedEventArgs e)
        {
            frmEditMedicamento frm = new frmEditMedicamento();
            frm.ShowDialog();
        }

        private void btnVerRecetas_Click(object sender, RoutedEventArgs e)
        {
            frmAdminRecetas frm = new frmAdminRecetas();
            frm.ShowDialog();
        }

        private void AdminPacientes(object sender, RoutedEventArgs e)
        {
            frmAdminPaciente frm = new frmAdminPaciente();
            frm.ShowDialog();
        }
        private void AdminDoc(object sender, RoutedEventArgs e)
        {
            Doctor od = new Doctor();
            od.ShowDialog();
        }

        private void AdminEnfermeras(object sender, RoutedEventArgs e)
        {
            frmAdminEnfermera frm = new frmAdminEnfermera();
            frm.ShowDialog();
        }

        private void Regristrar(object sender, RoutedEventArgs e)
        {
            frmRegistrarse frm = new frmRegistrarse();
            frm.ShowDialog();
        }

        private void URegistros(object sender, RoutedEventArgs e)
        {
            frmListaRegistros frm = new frmListaRegistros();
            frm.ShowDialog();
        }

        private void MenuTrabajadores_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            frmCRFichasMedicas frm = new frmCRFichasMedicas();
            frm.ShowDialog();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            frmCRRecetas frm = new frmCRRecetas();
            frm.ShowDialog();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            frmCRHistorialPaciente frm = new frmCRHistorialPaciente();
            frm.ShowDialog();
        }
    }
}
