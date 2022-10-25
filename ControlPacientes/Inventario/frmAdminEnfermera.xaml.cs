using ControlPacientes.DatosCD;
using ControlPacientes.DatosLN;
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
    /// Lógica de interacción para frmAdminEnfermera.xaml
    /// </summary>
    public partial class frmAdminEnfermera : Window
    {
        public frmAdminEnfermera()
        {
            InitializeComponent();
        }
        EnfermeraLN oln = new EnfermeraLN();
        PersonaLN olnp = new PersonaLN();
        public void Nuevo()
        {
            try
            {
                int i = 0;
                frmEditEnfermera frmep = new frmEditEnfermera();
                frmep.lbNombre.Content = "Insertar Enfermera";
                frmep.lbMensaje.Content = "Insertar Enfermera";
                frmep.ShowDialog();
                if (frmep.DialogResult == DialogResult.HasValue)
                {
                    foreach (var item in EnfermeraCD.ListarEnfermera())
                    {
                        i++;
                    }
                    Persona op = frmep.CrearPersona();
                    olnp.CreatePersona(op);
                    Enfermera oe = frmep.CrearEnfermera(i+1);
                    oln.CreateEnfermera(oe);
                    frmep.Close();
                    lbEstado.Content = " Enfermera Insertado ";
                    ListarEnfermeras();
                }
            }
            catch (Exception ex)
            {
                lbEstado.Content = " Error Insertar Enfermera " + ex.Message;
            }
        }

        public void Actualizar()
        {
            try
            {
                if (dgEnfermera.SelectedItem != null)
                {
                    frmEditEnfermera frmep = new frmEditEnfermera();
                    frmep.lbNombre.Content = "Actualizar Enfermera";
                    Enfermera obp = this.dgEnfermera.SelectedItem as Enfermera;  
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
                        obp = frmep.CrearEnfermera(obp.IdEnfermera);
                        oln.UpdateEnfermerar(obp);
                        frmep.Close();
                        lbEstado.Content = " Enfermera Actualizado ";
                        ListarEnfermeras();
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
                    var res = MessageBox.Show("Desea eliminar Enfermera", "Eliminar Enfermera", MessageBoxButton.YesNo);
                    if (res.ToString().Equals("Yes"))
                    {
                        Enfermera obp = this.dgEnfermera.SelectedItem as Enfermera;
                        oln.DeleteEnfermeral(obp);
                        olnp.DeletePersona(obp.Cedula);
                        ListarEnfermeras();
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
        public void ListarEnfermeras()
        {
            dgEnfermera.DataContext = oln.ViewEnfermera();
        }
        public void ListarEnfermerasF(string val)
        {
            dgEnfermera.DataContext = oln.ViewEnfermeraFiltro(val);
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (txtBuscar.Text.Equals(""))
            {
                ListarEnfermeras();
            }
            else
            {
                string val = txtBuscar.Text;
                ListarEnfermerasF(val);
            }
        }        

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Actualizar();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Eliminar();
        }

        private void btnRegistrar(object sender, RoutedEventArgs e)
        {
            Nuevo();
        }

        private void txtBuscar_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtBuscar.Text.Equals(""))
            {
                ListarEnfermeras();
            }
            else
            {
                string val = txtBuscar.Text;
                ListarEnfermerasF(val);
            }
        }
    }
}
