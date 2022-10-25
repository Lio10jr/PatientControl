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
using ControlPacientes.DatosCD;
using ControlPacientes.DatosLN;
using ControlPacientes.Entidades;

namespace ControlPacientes.Inventario
{
    /// <summary>
    /// Lógica de interacción para frmAdminMedicamentos.xaml
    /// </summary>
    public partial class frmAdminMedicamentos : Window
    {
        public frmAdminMedicamentos()
        {
            InitializeComponent();
        }
        MedicamentoLN oln = new MedicamentoLN();
        public void ListarMedicamentos()
        {
            dgEnfermera.DataContext = oln.ViewMedicamentos();
        }
        public void ListarMedicamentosF(string val)
        {
            dgEnfermera.DataContext = oln.ViewMedicamentosFiltro(val);
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (txtBuscar.Text.Equals(""))
            {
                ListarMedicamentos();
            }
            else
            {
                string val = txtBuscar.Text;
                ListarMedicamentosF(val);
            }
        }

        public void Nuevo()
        {
            try
            {
                int i = 0;
                frmEditMedicamento frmep = new frmEditMedicamento();
                frmep.lbNombre.Content = "Insertar Medicamento";
                frmep.lbMensaje.Content = "Insertar Medicamento";
                frmep.ShowDialog();
                if (frmep.DialogResult == DialogResult.HasValue)
                {
                    foreach (var item in MedicamentoCD.ListarMedicamento())
                    {
                        i++;
                    }
                    Medicamentos op = frmep.CrearMedicamento(i+1);
                    oln.CreateMedicamentos(op);
                    frmep.Close();
                    lbEstado.Content = " Medicamento Insertado ";
                    ListarMedicamentos();
                }
            }
            catch (Exception ex)
            {
                lbEstado.Content = " Error Insertar Medicamento " + ex.Message;
            }
        }

        public void Actualizar()
        {
            try
            {
                if (dgEnfermera.SelectedItem != null)
                {
                    frmEditMedicamento frmep = new frmEditMedicamento("Modificar");
                    frmep.lbNombre.Content = "Insertar Medicamento";
                    frmep.lbMensaje.Content = "Insertar Medicamento";
                    Medicamentos obp = this.dgEnfermera.SelectedItem as Medicamentos;                    
                    frmep.setDatos(obp);
                    frmep.ShowDialog();
                    if (frmep.DialogResult == DialogResult.HasValue)
                    {
                        obp = frmep.CrearMedicamento(obp.IdMedicamento);
                        oln.UpdateMedicamentos(obp);
                        frmep.Close();
                        lbEstado.Content = " Medicamento Actualizado ";
                        ListarMedicamentos();
                    }
                }
                else
                    lbEstado.Content = " Selecciones la fila modificar";
            }
            catch (Exception ex)
            {
                lbEstado.Content = " error al modificar datos" + ex.Message;
            }
        }

        public void Eliminar()
        {
            try
            {
                if (dgEnfermera.CurrentCell != null)
                {
                    var res = MessageBox.Show("Desea eliminar Medicamento", "Eliminar Medicamento", MessageBoxButton.YesNo);
                    if (res.ToString().Equals("Yes"))
                    {
                        Medicamentos obp = this.dgEnfermera.SelectedItem as Medicamentos;
                        oln.DeleteMedicamentos(obp);
                        ListarMedicamentos();
                        lbEstado.Content = " Medicamento eliminada";
                    }
                    else
                        lbEstado.Content = " Eliminacion cancelada";
                }
                else
                    lbEstado.Content = " Selecciones la fila elimminar";
            }
            catch (Exception ex)
            {
                lbEstado.Content = " Error al eliminar datos" + ex.Message;
            }
        }

        private void btnRegistrar(object sender, RoutedEventArgs e)
        {
            Nuevo();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Actualizar();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Eliminar();
        }

        private void txtBuscar_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtBuscar.Text.Equals(""))
            {
                ListarMedicamentos();
            }
            else
            {
                string val = txtBuscar.Text;
                ListarMedicamentosF(val);
            }
        }
    }
}
