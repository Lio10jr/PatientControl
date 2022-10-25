using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlPacientes.Entidades;
using ControlPacientes.Inventario;

namespace ControlPacientes.DatosCD
{
    public class EstadisticaCD
    {
        public static List<cp_ListarEstadisticaResult> ListarEstadistica()
        {
            BDControlPacienteDataContext DB = null;
            try
            {
                using (DB = new BDControlPacienteDataContext())
                {
                    return DB.cp_ListarEstadistica().ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error Listar Estadistica", ex);

            }
            finally
            {
                DB = null;
            }
        }
        public static List<cp_ListarEstadisticaFiltroResult> ListarEstadisticaFiltro(int val)
        {
            BDControlPacienteDataContext DB = null;
            try
            {
                using (DB = new BDControlPacienteDataContext())
                {
                    return DB.cp_ListarEstadisticaFiltro(val).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error Listar estadistica Filtro", ex);
            }
            finally
            {
                DB = null;
            }
        }


        public static void InsertarEstadistica(Estadistica op)
        {
            BDControlPacienteDataContext DB = null;
            try
            {
                using (DB = new BDControlPacienteDataContext())
                {
                    DB.cp_InsertarEstadistica(op.Codigo, op.IdEnfermera, op.NumCarpetas, op.IdFichaM);
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error Insertar Estadistica", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static void ModificarEstadistica(Estadistica op)
        {
            BDControlPacienteDataContext DB = null;
            try
            {
                using (DB = new BDControlPacienteDataContext())
                {
                    DB.cp_ActualizarEstadistica(op.Codigo, op.IdEnfermera, op.NumCarpetas, op.IdFichaM);
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error Actualizar Estadistica", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static void EliminarEstadistica(Estadistica op)
        {
            BDControlPacienteDataContext DB = null;
            try
            {
                using (DB = new BDControlPacienteDataContext())
                {
                    DB.cp_EliminarEstadistica(op.Codigo);
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error Eliminar Estadistica", ex);
            }
            finally
            {
                DB = null;
            }
        }
    }
}
