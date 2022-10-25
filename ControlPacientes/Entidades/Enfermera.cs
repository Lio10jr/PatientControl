using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlPacientes.Entidades
{
    public class Enfermera
    {
        private int idEnfermera;
        private string titulo;
        private string especialidad;
        private string cedula;

        public Enfermera() { }

        public Enfermera(int idEnfermera, string titulo, string especialidad, string cedula)
        {
            this.idEnfermera = idEnfermera;
            this.titulo = titulo;
            this.especialidad = especialidad;
            this.cedula = cedula;
        }

        public int IdEnfermera { get => idEnfermera; set => idEnfermera = value; }
        public string Titulo { get => titulo; set => titulo = value; }
        public string Especialidad { get => especialidad; set => especialidad = value; }
        public string Cedula { get => cedula; set => cedula = value; }
    }
}
