using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlPacientes.DatosCD;
using ControlPacientes.Entidades;

namespace ControlPacientes.DatosLN
{
    public class EstadisticaLN
    {
        public List<Estadistica> ViewEstadistica()
        {
            List<Estadistica> Lista = new List<Estadistica>();
            Estadistica obp = null;
            try
            {
                List<cp_ListarEstadisticaResult> auxLista = EstadisticaCD.ListarEstadistica();
                foreach (cp_ListarEstadisticaResult op in auxLista)
                {
                    obp = new Estadistica(op.Codigo, op.idEnfermera, op.NumeroCarpeta, op.idFichaMedica);
                    Lista.Add(obp);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error Mostrar en la logica a Estadistica");
            }
        }

        public List<Estadistica> ViewEstadisticaFiltro(int valor)
        {
            List<Estadistica> Lista = new List<Estadistica>();
            Estadistica obp = null;
            try
            {
                List<cp_ListarEstadisticaFiltroResult> auxLista = EstadisticaCD.ListarEstadisticaFiltro(valor);
                foreach (cp_ListarEstadisticaFiltroResult op in auxLista)
                {
                    obp = new Estadistica(op.Codigo, op.idEnfermera, op.NumeroCarpeta, op.idFichaMedica);
                    Lista.Add(obp);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error Mostrar en la logica a Estadistica filtro");
            }
        }

        public bool CreateEstadistica(Estadistica op)
        {
            try
            {
                EstadisticaCD.InsertarEstadistica(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error Create  Estadistica");
            }
        }
        public bool UpdateEstadistica(Estadistica op)
        {
            try
            {
                EstadisticaCD.ModificarEstadistica(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error Update  Estadistica");
            }
        }
        public bool DeleteEstadistica(Estadistica op)
        {
            try
            {
                EstadisticaCD.EliminarEstadistica(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error Delete Estadistica");
            }
        }
    }
}
