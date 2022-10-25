using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlPacientes.Entidades
{
    public class DoctorE
    {
        private int id;
        private string titulo;
        private string especialidad;
        private string estado;
        private string ced;
        public DoctorE() { }

        public DoctorE(int id, string titulo, string especialidad, string estado, string ced)
        {
            this.id = id;
            this.titulo = titulo;
            this.especialidad = especialidad;
            this.estado = estado;
            this.ced = ced;
        }

        public int Id { get => id; set => id = value; }
        public string Titulo { get => titulo; set => titulo = value; }
        public string Especialidad { get => especialidad; set => especialidad = value; }
        public string Estado { get => estado; set => estado = value; }
        public string Ced { get => ced; set => ced = value; }
    }
}
