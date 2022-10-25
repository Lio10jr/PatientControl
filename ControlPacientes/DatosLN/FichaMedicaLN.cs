using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlPacientes.DatosCD;
using ControlPacientes.Entidades;

namespace ControlPacientes.DatosLN
{
    class FichaMedicaLN
    {
        public List<FichaMedica> ViewFichaMedica()
        {
            List<FichaMedica> Lista = new List<FichaMedica>();
            FichaMedica obp = null;
            try
            {
                List<cp_ListarFichaMedicaResult> auxLista = FichaMedicaCD.ListarFichaMedica();
                foreach (cp_ListarFichaMedicaResult op in auxLista)
                {
                    obp = new FichaMedica(op.idFichaMedica, (int)op.idPaciente, op.Madre, op.Padre, op.Estudios, op.GrupoSanguineo, (int)op.Edad, op.Peso, op.Estatura);
                    Lista.Add(obp);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error Mostrar en la logica a FichaMedica");
            }
        }

        public List<FichaMedica> ViewFichaMedicaFiltro(string valor)
        {
            List<FichaMedica> Lista = new List<FichaMedica>();
            FichaMedica obp = null;
            try
            {
                List<cp_ListarFichaMedicaFiltroResult> auxLista = FichaMedicaCD.ListarFichaMedicaFiltro(valor);
                foreach (cp_ListarFichaMedicaFiltroResult op in auxLista)
                {
                    obp = new FichaMedica(op.idFichaMedica, (int)op.idPaciente, op.Madre, op.Padre, op.Estudios, op.GrupoSanguineo, (int)op.Edad, op.Peso, op.Estatura);
                    Lista.Add(obp);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error Mostrar en la logica a Ficha Medica filtro");
            }
        }
        public bool CreateFichaMedica(FichaMedica op)
        {
            try
            {
                FichaMedicaCD.InsertarFichaMedica(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error Create  FichaMedica");
            }
        }
        public bool UpdateFichaMedica(FichaMedica op)
        {
            try
            {
                FichaMedicaCD.ModificarFichaMedica(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error Update  FichaMedica");
            }
        }
        public bool DeleteFichaMedica(FichaMedica op)
        {
            try
            {
                FichaMedicaCD.EliminarFichaMedica(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error Delete FichaMedica");
            }
        }
    }
}
