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
    /// Lógica de interacción para frmEditFichaMedica.xaml
    /// </summary>
    public partial class frmEditFichaMedica : Window
    {
        public frmEditFichaMedica()
        {
            InitializeComponent();
            MostrarComboPaciente();
        }
        public void setDatos(FichaMedica oe)
        {
            MostrarComboPaciente();
            int i = 0;
            foreach(var item in comboPaciente.Items)
            {
                int id = int.Parse(item.ToString());
                
                if(id == oe.IdPaciente)
                {
                    i = comboPaciente.SelectedIndex;
                }
            }
            comboPaciente.SelectedIndex = i;
            txtMadre.Text = oe.Madre;
            txtPadre.Text = oe.Padre;
            txtEstudios.Text = oe.Estudios;
            txtGurpoS.Text = oe.GrupoSanguineo;
            txtEdad.Text = ""+oe.Edad;
            txtPeso.Text = oe.Peso;
            txtEstatura.Text = oe.Estatura;
        }
        public void MostrarComboPaciente()
        {
            PacienteLN oln = new PacienteLN();
            comboPaciente.ItemsSource = oln.ViewPaciente();
            comboPaciente.DisplayMemberPath = "Cedula";
            comboPaciente.SelectedValuePath = "IdPaciente";            
        }

        public FichaMedica CrearFichaMedica(int i)
        {
            FichaMedica oe;
            int idPaciente = (int) comboPaciente.SelectedValue;
            string madre = txtMadre.Text;
            string padre = txtPadre.Text;
            string estudios = txtEstudios.Text;
            string grupoS = txtGurpoS.Text;
            int edad = int.Parse(txtEdad.Text);
            string peso = txtPeso.Text;
            string estatura = txtEstatura.Text;
            oe = new FichaMedica(i,idPaciente, madre, padre, estudios,grupoS, edad, peso ,estatura);
            return oe;
        }
        FichaMedicaLN oln = new FichaMedicaLN();
        public void Guardar()
        {
            try
            {
                if (Validar())
                {
                    int i = 0;
                    
                    foreach (var item in FichaMedicaCD.ListarFichaMedica())
                    {
                        i++;
                    }
                    
                    FichaMedica op = CrearFichaMedica(i+1);
                    oln.CreateFichaMedica(op);
                    this.Close();
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
            if (txtMadre.Text.Trim().Length == 0 || txtPadre.Text.Trim().Length == 0 || txtEstudios.Text.Trim().Length == 0 || txtGurpoS.Text.Trim().Length == 0 ||
                txtEdad.Text.Trim().Length == 0 || txtPeso.Text.Trim().Length == 0 || txtEstatura.Text.Trim().Length == 0 ||
                comboPaciente.SelectedIndex < 0)
            {
                res = false;
            }
            return res;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Guardar();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            MostrarComboPaciente();
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
