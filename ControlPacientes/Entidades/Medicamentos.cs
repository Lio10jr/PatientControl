using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlPacientes.Entidades
{
    public class Medicamentos
    {
        private int idMedicamento;
        private string nombre;
        private string peso;
        private string tipo;

        public Medicamentos() { }

        public Medicamentos(int idMedicamento, string nombre, string peso, string tipo)
        {
            this.idMedicamento = idMedicamento;
            this.nombre = nombre;
            this.peso = peso;
            this.tipo = tipo;
        }

        public int IdMedicamento { get => idMedicamento; set => idMedicamento = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Peso { get => peso; set => peso = value; }
        public string Tipo { get => tipo; set => tipo = value; }
    }
}
