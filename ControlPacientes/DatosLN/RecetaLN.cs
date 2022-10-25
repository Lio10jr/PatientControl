using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlPacientes.DatosCD;
using ControlPacientes.Entidades;

namespace ControlPacientes.DatosLN
{
    public class RecetaLN
    {
        public List<Receta> ViewReceta()
        {
            List<Receta> Lista = new List<Receta>();
            Receta obp = null;
            try
            {
                List<cp_ListarRecetasResult> auxLista = RecetaCD.ListarReceta();
                foreach (cp_ListarRecetasResult op in auxLista)
                {
                    obp = new Receta( op.NumeroReceta, op.Dosis, (DateTime)op.FechaActual, op.idMedicamento, op.idMedico, op.idPaciente);
                    Lista.Add(obp);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error Mostrar en la logica a Receta");
            }
        }

        public List<Receta> ViewRecetaFiltro(string valor)
        {
            List<Receta> Lista = new List<Receta>();
            Receta obp = null;
            try
            {
                List<cp_ListarRecetasFiltroResult> auxLista = RecetaCD.ListarRecetasFiltro(valor);
                foreach (cp_ListarRecetasFiltroResult op in auxLista)
                {
                    obp = new Receta(op.NumeroReceta, op.Dosis, (DateTime)op.FechaActual, op.idMedicamento, op.idMedico, op.idPaciente);
                    Lista.Add(obp);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error Mostrar en la logica a Receta filtro");
            }
        }
        public bool CreateReceta(Receta op)
        {
            try
            {
                RecetaCD.InsertarReceta(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error Create  Receta");
            }
        }
        public bool UpdateRecetaReceta (Receta op)
        {
            try
            {
                RecetaCD.ModificarReceta(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error Update  Receta");
            }
        }
        public bool DeleteReceta(Receta op)
        {
            try
            {
                RecetaCD.EliminarReceta(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error Delete Receta");
            }
        }
    }
}
