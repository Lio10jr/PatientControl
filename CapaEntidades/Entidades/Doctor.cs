using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlPacientes.Entidades
{
    public class Doctor
    {
        private int id;
        private string titulo;
        private string especialidad;
        private string doctorado;

        public Doctor() { }
        public Doctor(int id, string titulo, string especialidad, string doctorado)
        {
            this.id = id;
            this.titulo = titulo;
            this.especialidad = especialidad;
            this.doctorado = doctorado;
        }

        public int Id { get => id; set => id = value; }
        public string Titulo { get => titulo; set => titulo = value; }
        public string Especialidad { get => especialidad; set => especialidad = value; }
        public string Doctorado { get => doctorado; set => doctorado = value; }
    }
}
