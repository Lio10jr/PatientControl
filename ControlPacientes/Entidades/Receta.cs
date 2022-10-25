using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlPacientes.Entidades
{
    public class Receta
    {
        private int numReceta;
        private string dosis;
        private DateTime fecheActual;
        private int idMedicamento;
        private int idMedico;
        private int idPaciente;

        public Receta() { }

        public Receta(int numReceta, string dosis, DateTime fecheActual, int idMedicamento, int idMedico, int idPaciente)
        {
            this.numReceta = numReceta;
            this.dosis = dosis;
            this.fecheActual = fecheActual;
            this.idMedicamento = idMedicamento;
            this.idMedico = idMedico;
            this.idPaciente = idPaciente;
        }

        public int NumReceta { get => numReceta; set => numReceta = value; }
        public string Dosis { get => dosis; set => dosis = value; }
        public DateTime FecheActual { get => fecheActual; set => fecheActual = value; }
        public int IdMedicamento { get => idMedicamento; set => idMedicamento = value; }
        public int IdMedico { get => idMedico; set => idMedico = value; }
        public int IdPaciente { get => idPaciente; set => idPaciente = value; }
    }
}
