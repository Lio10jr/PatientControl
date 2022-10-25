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
    /// Lógica de interacción para frmRegistrarse.xaml
    /// </summary>
    public partial class frmRegistrarse : Window
    {
        public frmRegistrarse()
        {
            InitializeComponent();
        }
        DoctorLN od = new DoctorLN();
        EnfermeraLN oe = new EnfermeraLN();
        RegistrarseLN orn = new RegistrarseLN();
        LoginLN ol = new LoginLN();
        public Registrarse CrearRegistro()
        {
            Registrarse oe;
            string tipo = null;
            string ced = txtCedula.Text;
            string nom = txtNombre.Text;
            string contra = txtContraseña.Password.ToString();
            if(comboTipo.SelectedIndex == 0)
            {
                tipo = "Admin";
            }
            else
            {
                if (comboTipo.SelectedIndex == 1)
                {
                    tipo = "Medico";
                }
                else
                {
                    tipo = "Enfermera";
                }
            }
            
            oe = new Registrarse(ced, nom, contra,tipo);
            return oe;
        }
        public Login CrearLogin()
        {
            Login oe;
            string ced = txtCedula.Text;
            string nom = txtNombre.Text;
            string contra = txtContraseña.Password.ToString();
            oe = new Login(nom, contra, ced);
            return oe;
        }

        public void Guardar()
        {
            try
            {
                if (Validar())
                {
                    string ced = txtCedula.Text;
                    bool resul = false;
                    if(comboTipo.SelectedIndex == 0)
                    {
                        Registrarse or;
                        Login olog;
                        or = CrearRegistro();
                        olog = CrearLogin();
                        orn.CreateRegistrarse(or);
                        ol.CreateLogin(olog);
                        MessageBox.Show("Registro creado con exito");
                        this.Close();
                    }
                    else
                    {
                        if (comboTipo.SelectedIndex == 1)
                        {
                            foreach (var item in od.ViewDoctor())
                            {
                                if (item.Ced == ced)
                                {
                                    resul = true;
                                }
                            }
                            if (resul)
                            {
                                Registrarse or;
                                Login olog;
                                or = CrearRegistro();
                                olog = CrearLogin();
                                orn.CreateRegistrarse(or);
                                ol.CreateLogin(olog);
                                MessageBox.Show("Registro creado con exito");
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Medico no registrado aun, por favor registrar el medico");
                            }
                        }
                        else
                        {
                            if(comboTipo.SelectedIndex == 2)
                            {
                                foreach (var item in oe.ViewEnfermera())
                                {
                                    if (item.Cedula == ced)
                                    {
                                        resul = true;
                                    }
                                }
                                if (resul)
                                {
                                    Registrarse or;
                                    Login olog;
                                    or = CrearRegistro();
                                    olog = CrearLogin();
                                    orn.CreateRegistrarse(or);
                                    ol.CreateLogin(olog);
                                    MessageBox.Show("Registro creado con exito");
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("Enfermera no registrada aun, por favor registrar la enfermera");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Elija un tipo");
                            }
                        }
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
            if (txtCedula.Text.Trim().Length == 0 || txtNombre.Text.Trim().Length == 0 || txtContraseña.Password.Trim().Length == 0 ||  comboTipo.SelectedIndex < 0)
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
