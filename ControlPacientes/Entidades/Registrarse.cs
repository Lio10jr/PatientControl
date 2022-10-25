using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlPacientes.Entidades
{
    public class Registrarse
    {
        private string cedula;
        private string nombre;
        private string contraseña;
        private string tipo;

        public Registrarse() { }

        public Registrarse(string cedula, string nombre, string contraseña, string tipo)
        {
            this.cedula = cedula;
            this.nombre = nombre;
            this.contraseña = contraseña;
            this.tipo = tipo;
        }

        public string Cedula { get => cedula; set => cedula = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Contraseña { get => contraseña; set => contraseña = value; }
        public string Tipo { get => tipo; set => tipo = value; }
    }
}
