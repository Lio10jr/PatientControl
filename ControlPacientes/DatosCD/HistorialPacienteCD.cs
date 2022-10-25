using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlPacientes.Entidades;
using ControlPacientes.Inventario;

namespace ControlPacientes.DatosCD
{
    public class HistorialPacienteCD
    {
        public static List<cp_ListarHistorialPacienteResult> ListarHistorialPaciente()
        {
            BDControlPacienteDataContext DB = null;
            try
            {
                using (DB = new BDControlPacienteDataContext())
                {
                    return DB.cp_ListarHistorialPaciente().ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error Listar HistorialPaciente", ex);

            }
            finally
            {
                DB = null;
            }
        }

        public static List<cp_ListarHistorialPacienteFiltroResult> ListarHistorialpacienteFiltro(string val)
        {
            BDControlPacienteDataContext DB = null;
            try
            {
                using (DB = new BDControlPacienteDataContext())
                {
                    return DB.cp_ListarHistorialPacienteFiltro(val).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error Listar Historial Paciente Filtro", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static void InsertarHistorialPaciente(HistorialPaciente op)
        {
            BDControlPacienteDataContext DB = null;
            try
            {
                using (DB = new BDControlPacienteDataContext())
                {
                    DB.cp_InsertarHistorialPaciente(op.IdRegPaciente, op.NumConsultas, op.UltimaFechaC, op.IdPaciente, op.Medico);
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error Insertar HistorialPaciente", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static void ModificarHistorialPaciente(HistorialPaciente op)
        {
            BDControlPacienteDataContext DB = null;
            try
            {
                using (DB = new BDControlPacienteDataContext())
                {
                    DB.cp_ActualizarHistorialPaciente(op.IdRegPaciente, op.NumConsultas, op.UltimaFechaC, op.IdPaciente, op.Medico);
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error Actualizar HistorialPaciente", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static void EliminarHistorialPaciente(HistorialPaciente op)
        {
            BDControlPacienteDataContext DB = null;
            try
            {
                using (DB = new BDControlPacienteDataContext())
                {
                    DB.cp_EliminarHistorialPaciente(op.IdRegPaciente);
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error Eliminar HistorialPaciente", ex);
            }
            finally
            {
                DB = null;
            }
        }
    }
}
