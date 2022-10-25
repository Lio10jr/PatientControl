using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlPacientes.Entidades
{
    public class HistorialPaciente
    {
        private int idRegPaciente;
        private int numConsultas;
        private DateTime ultimaFechaC;
        private int idPaciente;
        private int medico;

        public HistorialPaciente() { }

        public HistorialPaciente(int idRegPaciente, int numConsultas, DateTime ultimaFechaC, int idPaciente, int medico)
        {
            this.idRegPaciente = idRegPaciente;
            this.numConsultas = numConsultas;
            this.ultimaFechaC = ultimaFechaC;
            this.idPaciente = idPaciente;
            this.medico = medico;
        }

        public int IdRegPaciente { get => idRegPaciente; set => idRegPaciente = value; }
        public int NumConsultas { get => numConsultas; set => numConsultas = value; }
        public DateTime UltimaFechaC { get => ultimaFechaC; set => ultimaFechaC = value; }
        public int IdPaciente { get => idPaciente; set => idPaciente = value; }
        public int Medico { get => medico; set => medico = value; }
    }
}
