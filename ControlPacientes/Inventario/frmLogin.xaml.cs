using ControlPacientes.DatosLN;
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
    /// Lógica de interacción para frmLogin.xaml
    /// </summary>
    public partial class frmLogin : Window
    {
        public static string tipo;
        LoginLN ol = new LoginLN();
        RegistrarseLN or = new RegistrarseLN();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Vuelva pronto");
            this.Close();
        }
        
        public void Buscar()
        {
            
            if (ValidarUsuario())
            {
                if (ValidarContraseña())
                {
                    MessageBox.Show("Bienvenido " + Bienvenida());
                    if(tipo == "Admin")
                    {
                        MainWindow frm = new MainWindow();
                        this.Close();
                        frm.Show();
                    }
                    else
                    {
                        MainWindow frm = new MainWindow(tipo);
                        this.Close();
                        frm.Show();
                    }
                                       
                }
                else
                {
                    MessageBox.Show("Contraseña incorrecta, vuelva a intentarlo");
                }
            }
            else
            {
                MessageBox.Show("El usuario y la contraseña no coinciden");
            }
            
        }
        
        public void tipoUsuario()
        {

        }
        public string Bienvenida()
        {
            string ced = txtCedula.Text;
            string resul = "";
            foreach (var item in or.ViewRregistro())
            {
                if (ced == item.Cedula)
                {
                    resul = item.Tipo + " " + item.Nombre;
                    tipo = item.Tipo;
                }
            }
            return resul;
        }
        public bool ValidarContraseña()
        {
            bool resul = false;
            string contra = txtContraseña.Password.ToString();
            foreach (var item in ol.ViewLogin())
            {
                if(contra == item.Contraseña)
                {
                    resul = true;
                }
            }
            return resul;
        }
        public bool ValidarUsuario()
        {
            bool resul = false;
            string usuario = txtCedula.Text;
            foreach (var item in ol.ViewLogin())
            {
                if (usuario == item.Cedula)
                {
                    resul = true;                    
                }
            }
            return resul;
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Buscar();
        }
    }
}
