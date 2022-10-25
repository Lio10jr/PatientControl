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
    /// Lógica de interacción para frmEditMedicamento.xaml
    /// </summary>
    public partial class frmEditMedicamento : Window
    {
        private string tipo;
        public frmEditMedicamento()
        {
            InitializeComponent();
        }
        public frmEditMedicamento(string tipo)
        {
            InitializeComponent();
            this.tipo = tipo;
        }
        public Medicamentos CrearMedicamento(int i)
        {
            Medicamentos oe;
            string nombre = txtNombre.Text;
            string peso = txtPeso.Text;
            string tipo = txtTipo.Text;
            oe = new Medicamentos(i,nombre, peso, tipo);
            return oe;
        }
        public void setDatos(Medicamentos oe)
        {
            txtNombre.Text = oe.Nombre;
            txtPeso.Text = oe.Peso;
            txtTipo.Text = oe.Tipo;
        }
        MedicamentoLN oln = new MedicamentoLN();
        public void Guardar()
        {
            try
            {
                if (Validar())
                {
                    if(this.tipo != "Modificar")
                    {
                        int i = 0;
                        foreach (var item in MedicamentoCD.ListarMedicamento())
                        {
                            i++;
                        }
                        Medicamentos op = CrearMedicamento(i + 1);
                        oln.CreateMedicamentos(op);
                        this.Close();
                    }
                    else
                    {
                        this.DialogResult = DialogResult.HasValue;
                    }
                    
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
            if (txtNombre.Text.Trim().Length == 0 || txtPeso.Text.Trim().Length == 0 || txtTipo.Text.Trim().Length == 0  )
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
