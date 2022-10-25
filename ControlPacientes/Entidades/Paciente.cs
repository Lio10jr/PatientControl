using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlPacientes.Entidades
{
    public class Paciente
    {
        private int idPaciente;
        private string estado;
        private string afiliadoSS;
        private string cedula;

        public Paciente() { }

        public Paciente(int idPaciente, string estado, string afiliadoSS, string cedula)
        {
            this.idPaciente = idPaciente;
            this.estado = estado;
            this.afiliadoSS = afiliadoSS;
            this.cedula = cedula;
        }

        public int IdPaciente { get => idPaciente; set => idPaciente = value; }
        public string Estado { get => estado; set => estado = value; }
        public string AfiliadoSS { get => afiliadoSS; set => afiliadoSS = value; }
        public string Cedula { get => cedula; set => cedula = value; }
    }
}
