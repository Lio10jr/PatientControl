using ControlPacientes.DatosLN;
using ControlPacientes.DatosCD;
using ControlPacientes.Entidades;
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
    /// Lógica de interacción para frmAdminPaciente.xaml
    /// </summary>
    public partial class frmAdminPaciente : Window
    {
        public frmAdminPaciente()
        {
            InitializeComponent();
        }

        PacienteLN oln = new PacienteLN();
        PersonaLN olnp = new PersonaLN();
        public void Nuevo()
        {
            try
            {
                int i = 0;
                frmEditPaciente frmep = new frmEditPaciente();
                frmep.lbNombre.Content = "Insertar Paciente";
                frmep.lbMensaje.Content = "...";
                frmep.ShowDialog();
                if (frmep.DialogResult == DialogResult.HasValue)
                {
                    foreach (var item in PacienteCD.ListarPaciente())
                    {
                        i++;
                    }
                    Persona op = frmep.CrearPersona();
                    olnp.CreatePersona(op);
                    Paciente oe = frmep.CrearPaciente(i + 1);
                    oln.CreatePaciente(oe);
                    frmep.Close();
                    lbEstado.Content = " Paciente Insertado ";
                    ListarPaciente();
                }
            }
            catch (Exception ex)
            {
                lbEstado.Content = " Error Insertar Paciente " + ex.Message;
            }
        }
        public void Actualizar()
        {
            try
            {
                if (dgDoctor.SelectedItem != null)
                {
                    frmEditPaciente frmep = new frmEditPaciente();
                    frmep.lbNombre.Content = "Actualizar Paciente";
                    frmep.lbMensaje.Content = "...";
                    Paciente obp = this.dgDoctor.SelectedItem as Paciente;
                    Persona op = new Persona();
                    foreach (var rop in PersonaCD.ListarPersona())
                    {
                        if (rop.Cedula == obp.Cedula)
                        {
                            op = new Persona(rop.Cedula, rop.Nombres, rop.Apellidos, rop.Direccion, rop.Ciudad, (DateTime)rop.FechaNacimiento, rop.Celular);
                        }
                    }
                    frmep.setDatos(obp, op);
                    frmep.ShowDialog();
                    if (frmep.DialogResult == DialogResult.HasValue)
                    {
                        Persona op1 = frmep.CrearPersona();
                        olnp.UpdatePersona(op1);
                        obp = frmep.CrearPaciente(obp.IdPaciente);
                        oln.UpdatePaciente(obp);
                        frmep.Close();
                        lbEstado.Content = " Paciente Actualizado ";
                        ListarPaciente();
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
                if (dgDoctor.CurrentCell != null)
                {
                    var res = MessageBox.Show("Desea eliminar Paciente", "Eliminar Paciente", MessageBoxButton.YesNo);
                    if (res.ToString().Equals("Yes"))
                    {
                        Paciente obp = this.dgDoctor.SelectedItem as Paciente;
                        oln.DeletePaciente(obp);
                        olnp.DeletePersona(obp.Cedula);
                        ListarPaciente();
                        lbEstado.Content = " Paciente eliminada";
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
        public void ListarPaciente()
        {
            dgDoctor.DataContext = oln.ViewPaciente();
        }
        public void ListarPacienteF(string val)
        {
            dgDoctor.DataContext = oln.ViewPacienteFiltro(val);
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
