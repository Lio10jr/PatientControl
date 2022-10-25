using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlPacientes.Entidades
{
    public class FichaMedica
    {
        private int idFichaM;
        private int idPaciente;
        private string madre;
        private string padre;
        private string estudios;
        private string grupoSanguineo;
        private int edad;
        private string peso;
        private string estatura;

        public FichaMedica() { }

        public FichaMedica(int idFichaM, int idPaciente, string madre, string padre, string estudios, string grupoSanguineo, int edad, string peso, string estatura)
        {
            this.idFichaM = idFichaM;
            this.idPaciente = idPaciente;
            this.madre = madre;
            this.padre = padre;
            this.estudios = estudios;
            this.grupoSanguineo = grupoSanguineo;
            this.edad = edad;
            this.peso = peso;
            this.estatura = estatura;
        }

        public int IdFichaM { get => idFichaM; set => idFichaM = value; }
        public int IdPaciente { get => idPaciente; set => idPaciente = value; }
        public string Madre { get => madre; set => madre = value; }
        public string Padre { get => padre; set => padre = value; }
        public string Estudios { get => estudios; set => estudios = value; }
        public string GrupoSanguineo { get => grupoSanguineo; set => grupoSanguineo = value; }
        public int Edad { get => edad; set => edad = value; }
        public string Peso { get => peso; set => peso = value; }
        public string Estatura { get => estatura; set => estatura = value; }
    }
}
