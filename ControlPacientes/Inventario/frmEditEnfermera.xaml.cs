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
    /// Lógica de interacción para frmEditEnfermera.xaml
    /// </summary>
    public partial class frmEditEnfermera : Window
    {
        public frmEditEnfermera()
        {
            InitializeComponent();
        }

        public void setDatos(Enfermera oe, Persona op)
        {
            txtCedula.Text = oe.Cedula;
            txtNombre.Text = op.Nombres;
            txtApellidos.Text = op.Apellidos;
            txtDireccion.Text = op.Direccion;
            txtCiudad.Text = op.Ciudad;
            dtFecha.SelectedDate = op.FechaNacimiento.Date;
            txtCelular.Text = op.Celular;
            txtTitulo.Text = oe.Titulo;
            txtEspecialidad.Text = oe.Especialidad;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Guardar();
        }
        public Enfermera CrearEnfermera(int i)
        {
            Enfermera oe;
            string ced = txtCedula.Text;
            string titulo = txtTitulo.Text;
            string espe = txtEspecialidad.Text;
            oe = new Enfermera(i, titulo, espe, ced);
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
            oe = new Persona(ced, nom, ape, dir, ciu, fecha,celular);
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
                txtCiudad.Text.Trim().Length == 0 && dtFecha.SelectedDate.HasValue || txtCelular.Text.Trim().Length == 0 || txtTitulo.Text.Trim().Length == 0 ||
                txtEspecialidad.Text.Trim().Length == 0 )
            {
                res = false;
            }
            return res;
        }

        public void Limpiar()
        {
            txtCedula.Text = "";
            txtNombre.Text = "";
            txtApellidos.Text = "";
            txtDireccion.Text = "";
            txtCiudad.Text = "";
            dtFecha.SelectedDate = null;
            txtCelular.Text = "";
            txtTitulo.Text = "";
            txtEspecialidad.Text = "";
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
