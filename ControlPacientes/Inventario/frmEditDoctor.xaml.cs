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

namespace ControlPacientes.Inventario
{
    /// <summary>
    /// Lógica de interacción para frmEditDoctor.xaml
    /// </summary>
    public partial class frmEditDoctor : Window
    {
        public frmEditDoctor()
        {
            InitializeComponent();
        }
        public void setDatos(DoctorE oe, Persona op)
        {
            txtCedula.Text = oe.Ced;
            txtNombre.Text = op.Nombres;
            txtApellidos.Text = op.Apellidos;
            txtDireccion.Text = op.Direccion;
            txtCiudad.Text = op.Ciudad;
            dtFecha.SelectedDate = op.FechaNacimiento.Date;
            txtCelular.Text = op.Celular;
            txtTitulo.Text = oe.Titulo;
            txtEspecialidad.Text = oe.Especialidad;
            if (oe.Estado.Equals("Activo"))
            {
                comboEstado.SelectedIndex = 0;
            }
            else
            {
                comboEstado.SelectedIndex = 1;
            }
        }
        public DoctorE CrearDoctor(int i)
        {
            DoctorE oe;
            string ced = txtCedula.Text;
            string titulo = txtTitulo.Text;
            string espe = txtEspecialidad.Text;
            string est = "";
            if (comboEstado.SelectedIndex == 0)
            {
                est = "Activo";
            }
            else
            {
                est = "No Activo";
            }
            oe = new DoctorE(i, titulo, espe, est, ced);
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
                txtCiudad.Text.Trim().Length == 0 || txtCelular.Text.Trim().Length == 0 || txtTitulo.Text.Trim().Length == 0 ||
                txtEspecialidad.Text.Trim().Length == 0 || comboEstado.SelectedIndex < 0 && dtFecha.SelectedDate.HasValue) 
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
