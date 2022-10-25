using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlPacientes.Entidades
{
    public class Consultorio
    {
        private int idConsultorio;
        private string nombre;
        private int idMedico;

        public Consultorio() { }

        public Consultorio(int idConsultorio, string nombre, int idMedico)
        {
            this.idConsultorio = idConsultorio;
            this.nombre = nombre;
            this.idMedico = idMedico;
        }

        public int IdConsultorio { get => idConsultorio; set => idConsultorio = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public int IdMedico { get => idMedico; set => idMedico = value; }
    }
}
