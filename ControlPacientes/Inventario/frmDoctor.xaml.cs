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
using ControlPacientes.Entidades;
using ControlPacientes.DatosCD;
using ControlPacientes.DatosLN;

namespace ControlPacientes.Inventario
{
    /// <summary>
    /// Lógica de interacción para Doctor.xaml
    /// </summary>
    public partial class Doctor : Window
    {
        public Doctor()
        {
            InitializeComponent();
        }

        DoctorLN oln = new DoctorLN();
        PersonaLN olnp = new PersonaLN();
        public void Nuevo()
        {
            try
            {
                int i = 0;
                frmEditDoctor frmep = new frmEditDoctor();
                frmep.lbNombre.Content = "Insertar Doctor";
                frmep.ShowDialog();
                if (frmep.DialogResult == DialogResult.HasValue)
                {
                    foreach (var item in DoctorCD1.ListarDoctor())
                    {
                        i++;
                    }
                    Persona op = frmep.CrearPersona();
                    olnp.CreatePersona(op);
                    DoctorE oe = frmep.CrearDoctor(i + 1);
                    oln.CreateDoctor(oe);
                    frmep.Close();
                    lbEstado.Content = " Doctor Insertado ";
                    ListarDoctor();
                }
            }
            catch (Exception ex)
            {
                lbEstado.Content = " Error Insertar Doctor " + ex.Message;
            }
        }
        public void Actualizar()
        {
            try
            {
                if (dgDoctor.SelectedItem != null)
                {
                    frmEditDoctor frmep = new frmEditDoctor();
                    frmep.lbNombre.Content = "Insertar Doctor";
                    DoctorE obp = this.dgDoctor.SelectedItem as DoctorE;
                    Persona op = new Persona();
                    foreach (var rop in PersonaCD.ListarPersona())
                    {
                        if (rop.Cedula == obp.Ced)
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
                        obp = frmep.CrearDoctor(obp.Id);
                        oln.UpdateDoctor(obp);
                        frmep.Close();
                        lbEstado.Content = " Doctor Actualizado ";
                        ListarDoctor();
                    }
                }
                else
                    lbEstado.Content = " Selecciones la fila modificar";
            }
            catch (Exception ex)
            {
                lbEstado.Content = " Error al modificar datos" + ex.Message;
            }
        }

        public void Eliminar()
        {
            try
            {
                if (dgDoctor.CurrentCell != null)
                {
                    var res = MessageBox.Show("Desea Habilitar/Desahilitar Doctor", "Habilitar/Desahilitar Doctor", MessageBoxButton.YesNo);
                    if (res.ToString().Equals("Yes"))
                    {
                        DoctorE obp = this.dgDoctor.SelectedItem as DoctorE;
                        oln.DeleteDoctor(obp);
                        olnp.DeletePersona(obp.Ced);
                        ListarDoctor();
                        lbEstado.Content = " Enfermera eliminada";
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
        public void ListarDoctor()
        {
            dgDoctor.DataContext = oln.ViewDoctor();
        }

        private void Window(object sender, RoutedEventArgs e)
        {
            ListarDoctor();
        }

        private void btnRegistrar(object sender, RoutedEventArgs e)
        {
            Nuevo();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Actualizar();
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            Eliminar();
        }
    }
}
