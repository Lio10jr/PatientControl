using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlPacientes.Entidades
{
    public class Persona
    {
        private string cedula;
        private string nombres;
        private string apellidos;
        private string direccion;
        private string ciudad;
        private DateTime fechaNacimiento;
        private string celular;

        public Persona() { }

        public Persona(string cedula, string nombres, string apellidos, string direccion, string ciudad, DateTime fechaNacimiento, string celular)
        {
            this.cedula = cedula;
            this.nombres = nombres;
            this.apellidos = apellidos;
            this.direccion = direccion;
            this.ciudad = ciudad;
            this.fechaNacimiento = fechaNacimiento;
            this.celular = celular;
        }

        public string Cedula { get => cedula; set => cedula = value; }
        public string Nombres { get => nombres; set => nombres = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Ciudad { get => ciudad; set => ciudad = value; }
        public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public string Celular { get => celular; set => celular = value; }
    }
}
