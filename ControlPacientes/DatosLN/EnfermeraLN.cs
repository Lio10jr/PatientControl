using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlPacientes.DatosCD;
using ControlPacientes.Entidades;

namespace ControlPacientes.DatosLN
{
    public class EnfermeraLN
    {
        public List<Enfermera> ViewEnfermera()
        {
            List<Enfermera> Lista = new List<Enfermera>();
            Enfermera obp = null;
            try
            {
                List<cp_ListarEnfermeraResult> auxLista = EnfermeraCD.ListarEnfermera();
                foreach (cp_ListarEnfermeraResult op in auxLista)
                {
                    obp = new Enfermera(op.idEnfermera, op.Titulo, op.Especialidad, op.Cedula);
                    Lista.Add(obp);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error Mostrar en la logica a Enfermera");
            }
        }

        public List<Enfermera> ViewEnfermeraFiltro(string valor)
        {
            List<Enfermera> Lista = new List<Enfermera>();
            Enfermera obp = null;
            try
            {
                List<cp_ListarEnfermeraFiltroResult> auxLista = EnfermeraCD.ListarEnfermeraFiltro(valor);
                foreach (cp_ListarEnfermeraFiltroResult op in auxLista)
                {
                    obp = new Enfermera(op.idEnfermera, op.Titulo, op.Especialidad, op.Cedula);
                    Lista.Add(obp);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error Mostrar en la logica a Enfermera filtro");
            }
        }
        public bool CreateEnfermera(Enfermera op)
        {
            try
            {
                EnfermeraCD.InsertarEnfermera(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error Create  Enfermera");
            }
        }
        public bool UpdateEnfermerar(Enfermera op)
        {
            try
            {
                EnfermeraCD.ModificarEnfermera(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error Update  Enfermera");
            }
        }
        public bool DeleteEnfermeral(Enfermera op)
        {
            try
            {
                EnfermeraCD.EliminarEnfermera(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error Delete Enfermera");
            }
        }
    }
}




