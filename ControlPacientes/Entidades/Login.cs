using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlPacientes.Entidades
{
    public class Login
    {
        private string usuario;
        private string contraseña;
        private string cedula;

        public Login() { }

        public Login(string usuario, string contraseña, string cedula)
        {
            this.usuario = usuario;
            this.contraseña = contraseña;
            this.cedula = cedula;
        }

        public string Usuario { get => usuario; set => usuario = value; }
        public string Contraseña { get => contraseña; set => contraseña = value; }
        public string Cedula { get => cedula; set => cedula = value; }
    }
}
