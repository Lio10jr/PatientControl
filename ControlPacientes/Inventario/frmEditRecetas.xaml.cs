using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ControlPacientes.DatosCD;
using ControlPacientes.DatosLN;
using ControlPacientes.Entidades;
using MessageBox = System.Windows.MessageBox;

namespace ControlPacientes.Inventario
{
    /// <summary>
    /// Lógica de interacción para frmEditRecetas.xaml
    /// </summary>
    public partial class frmEditRecetas : Window
    {
        public int numero = 0;
        public List<Medicamentos> list = new List<Medicamentos>();
        RecetaLN olnp = new RecetaLN();
        HistorialPacienteLN ohln = new HistorialPacienteLN();
        MedicamentoLN oln = new MedicamentoLN();
        public frmEditRecetas()
        {
            InitializeComponent();
        }
        
        public Receta CrearReceta1(int i, int med, string dosis)
        {
            Receta oe;
            int idPaciente = (int)comboPaciente.SelectedValue;
            DateTime fecha = dpFecha.SelectedDate.Value;
            int idMedico = (int)comboMedico.SelectedValue;
            int idMedicamento = med;
            oe = new Receta(i, dosis, fecha, idMedicamento, idMedico, idPaciente);
            return oe;
        }

        public HistorialPaciente Crearhistori(int i, int num)
        {
            HistorialPaciente oe;
            int idPaciente = (int)comboPaciente.SelectedValue;
            DateTime fecha = dpFecha.SelectedDate.Value;
            int idMedico = (int)comboMedico.SelectedValue;
            oe = new HistorialPaciente(i, num, fecha, idPaciente, idMedico);
            return oe;
        }

        public bool VerificarDoc()
        {
            bool resul = false;
            int idMedico = (int)comboMedico.SelectedValue;
            foreach (var item in DoctorCD1.ListarDoctor())
            {
                if (item.idMedico ==  idMedico)
                {
                    if (item.Estado.Equals("Activo"))
                    {
                        resul = true;
                    }                    
                }
            }
            return resul;
        }

        public void Guardar()
        {
            numero = dgEnfermera.Items.Count;
            try
            {
                if (Validar())
                {
                    Nuevo();
                }
                else
                    lbMensaje.Content = " Los campos son obligatorios (*)";
            }
            catch (Exception ex)
            {
                lbMensaje.Content = "Error " + ex.Message;
            }
        }
        
        public void Nuevo()
        {
            try
            {
                if (VerificarDoc())
                {
                    int i = 0;
                    int cont = 0;
                    int numConsulta = 0;
                    foreach (var item in RecetaCD.ListarReceta())
                    {
                        int n = item.NumeroReceta;
                        if (n > cont)
                        {
                            i = item.NumeroReceta;
                            cont = i;
                        }
                    }
                    i++;
                    int numdosis = 0;
                    foreach (var L in list)
                    {
                        if (L != null)
                        {
                            if (txtDosis != null)
                            {
                                string dosis = txtDosis.GetLineText(numdosis);
                                int idmEDI = int.Parse(L.IdMedicamento.ToString());
                                Receta or = CrearReceta1(i, idmEDI, dosis);
                                olnp.CreateReceta(or);
                                numdosis++;
                            }
                            else
                            {
                                MessageBox.Show("Ingresar las dosis");
                                return;
                            }
                        }
                    }
                    
                    HistorialPaciente oh;
                    i = 0;
                    cont = 0;
                    int idPaciente = (int)comboPaciente.SelectedValue;
                    bool siEsta = false;
                    int idHistorial = 0;
                    foreach (var item in HistorialPacienteCD.ListarHistorialPaciente())
                    {
                        i++;
                        if (idPaciente == item.idPaciente)
                        {
                            siEsta = true;
                            numConsulta = (int)item.NumeroConsultas;
                            idHistorial = (int)item.idRegistroPaciente;
                        }
                    }
                    if (!siEsta)
                    {
                        numConsulta++;
                        oh = Crearhistori(i + 1, numConsulta);
                        ohln.CreateHistorialPaciente(oh);
                    }
                    else
                    {
                        numConsulta++;
                        oh = Crearhistori(idHistorial, numConsulta);
                        ohln.UpdateHistorialPaciente(oh);
                    }
                    MessageBox.Show("Se han generado las recetas con exito");
                    this.Close();
                }
                else
                {
                    lbMensaje.Content = "El medico no se encuentra activo ";
                }
            }
            catch (Exception ex)
            {
                lbMensaje.Content = " Error Insertar Receta " + ex.Message;
            }
        }
        public bool Validar()
        {
            bool res = true;
            if (comboMedico.SelectedIndex < 0 || comboPaciente.SelectedIndex < 0 && dpFecha.SelectedDate.HasValue)
            {
                res = false;
            }
            return res;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Guardar();
        }
        public void MostrarComboPaciente()
        {
            PacienteLN oln = new PacienteLN();
            comboPaciente.ItemsSource = oln.ViewPaciente();
            comboPaciente.DisplayMemberPath = "Cedula";
            comboPaciente.SelectedValuePath = "IdPaciente";            
        }
        public void MostrarComboMedico()
        {
            DoctorLN oln = new DoctorLN();
            comboMedico.ItemsSource = oln.ViewDoctor();
            comboMedico.DisplayMemberPath = "Ced";
            comboMedico.SelectedValuePath = "Id";
        }
        public void MostrarComboMedicamento()
        {
            MedicamentoLN oln = new MedicamentoLN();
            comboMedicamentos1.ItemsSource = oln.ViewMedicamentos();
            comboMedicamentos1.DisplayMemberPath = "Nombre";
            comboMedicamentos1.SelectedValuePath = "IdMedicamento";
        }
        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            list.Clear();
            this.Close();
        }      

    private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MostrarComboMedicamento();
            MostrarComboMedico();
            MostrarComboPaciente();
        }

        private void Button_Click10(object sender, RoutedEventArgs e)
        {
            try
            {
                if (comboMedicamentos1.SelectedIndex < 0)
                {
                    MessageBox.Show("Elija un medicamento");
                }
                else
                {
                    MedicamentoLN oln = new MedicamentoLN();
                    int id = (int)comboMedicamentos1.SelectedValue;
                    bool resul = false;
                    foreach (var item in oln.ViewMedicamentos())
                    {
                        if (id == item.IdMedicamento)
                        {
                            foreach(var l in list)
                            {
                                if(l != null)
                                {
                                    if (l.Nombre == item.Nombre)
                                    {
                                        resul = true;
                                    }
                                }
                                
                            }
                            if (!resul)
                            {
                                list.Add(item);
                                dgEnfermera.Items.Refresh();
                                dgEnfermera.DataContext = list;
                            }                            
                            else
                            {
                                MessageBox.Show("El dato se encuentra repetido");

                            }                            
                        }
                    }
                }
                comboMedicamentos1.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);

            }            
        }

        private void Window_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            //dgEnfermera.DataContextChanged = list;
        }
    }
}
