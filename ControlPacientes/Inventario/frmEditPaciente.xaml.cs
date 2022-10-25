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
    /// Lógica de interacción para frmEditPaciente.xaml
    /// </summary>
    public partial class frmEditPaciente : Window
    {
        public frmEditPaciente()
        {
            InitializeComponent();
        }
        public void setDatos(Paciente oe, Persona op)
        {
            txtCedula.Text = oe.Cedula;
            txtNombre.Text = op.Nombres;
            txtApellidos.Text = op.Apellidos;
            txtDireccion.Text = op.Direccion;
            txtCiudad.Text = op.Ciudad;
            dtFecha.SelectedDate = op.FechaNacimiento.Date;
            txtCelular.Text = op.Celular;
            txtEstado.Text = oe.Estado;
            txtAfiliado.Text = oe.AfiliadoSS;
        }
        public Paciente CrearPaciente(int i)
        {
            Paciente oe;
            string ced = txtCedula.Text;
            string estado = txtEstado.Text;
            string afili = txtAfiliado.Text;
            oe = new Paciente(i, estado, afili, ced);
            return oe;
        }
        public Persona CrearPersona()
        {
            Persona oe;
            string ced = txtCedula.Text;
            string nom = txtNombre.Text;
            string ape = txtApellidos.Text;
            string dir = txtDireccion.Text;
            string ciu = txtCiudad.Text;
            DateTime fecha = dtFecha.SelectedDate.Value;
            string celular = txtCelular.Text;
            oe = new Persona(ced, nom, ape, dir, ciu, fecha, celular);
            return oe;
        }
        public void Guardar()
        {
            try
            {
                if (Validar())
                {
                    this.DialogResult = DialogResult.HasValue;
                }
                else
                    lbMensaje.Content = " Los campos son obligatorios (*)";
            }
            catch (Exception ex)
            {
                lbMensaje.Content = "Error " + ex.Message;
            }
        }
        public bool Validar()
        {
            bool res = true;
            if (txtCedula.Text.Trim().Length == 0 || txtNombre.Text.Trim().Length == 0 || txtApellidos.Text.Trim().Length == 0 || txtDireccion.Text.Trim().Length == 0 ||
                txtCiudad.Text.Trim().Length == 0 && dtFecha.SelectedDate.HasValue || txtCelular.Text.Trim().Length == 0 || txtEstado.Text.Trim().Length == 0 ||
                txtAfiliado.Text.Trim().Length == 0)
            {
                res = false;
            }
            return res;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Guardar();
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
