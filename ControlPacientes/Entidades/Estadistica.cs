using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlPacientes.Entidades
{
    public class Estadistica
    {
        private int codigo;
        private int idEnfermera;
        private int numCarpetas;
        private int idFichaM;

        public Estadistica() { }

        public Estadistica(int codigo, int idEnfermera, int numCarpetas, int idFichaM)
        {
            this.codigo = codigo;
            this.idEnfermera = idEnfermera;
            this.numCarpetas = numCarpetas;
            this.idFichaM = idFichaM;
        }

        public int Codigo { get => codigo; set => codigo = value; }
        public int IdEnfermera { get => idEnfermera; set => idEnfermera = value; }
        public int NumCarpetas { get => numCarpetas; set => numCarpetas = value; }
        public int IdFichaM { get => idFichaM; set => idFichaM = value; }
    }
}
