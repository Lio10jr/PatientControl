using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlPacientes.Entidades;
using ControlPacientes.Inventario;

namespace ControlPacientes.DatosCD
{
    public class ConsultorioCD
    {
        public static List<cp_ListarConsultorioResult> ListarConsultorio()
        {
            BDControlPacienteDataContext DB = null;
            try
            {
                using (DB = new BDControlPacienteDataContext())
                {
                    return DB.cp_ListarConsultorio().ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error Listar Consultorio", ex);

            }
            finally
            {
                DB = null;
            }
        }

        public static List<cp_ListarConsultorioFiltroResult> ListarConsultorioFiltro(string val)
        {
            BDControlPacienteDataContext DB = null;
            try
            {
                using (DB = new BDControlPacienteDataContext())
                {
                    return DB.cp_ListarConsultorioFiltro(val).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error Listar Consultorio Filtro", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static void InsertarConsultorio(Consultorio op)
        {
            BDControlPacienteDataContext DB = null;
            try
            {
                using (DB = new BDControlPacienteDataContext())
                {
                    DB.cp_InsertarConsultorio(op.IdConsultorio, op.Nombre, op.IdMedico);
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error Insertar Consultorio", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static void ModificarConsultorio(Consultorio op)
        {
            BDControlPacienteDataContext DB = null;
            try
            {
                using (DB = new BDControlPacienteDataContext())
                {
                    DB.cp_ActualizarConsultorio(op.IdConsultorio, op.Nombre, op.IdMedico);
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error Actualizar Consultorio", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static void EliminarConsultorio(Consultorio op)
        {
            BDControlPacienteDataContext DB = null;
            try
            {
                using (DB = new BDControlPacienteDataContext())
                {
                    DB.cp_EliminarConsultorio(op.IdConsultorio);
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error Eliminar Consultorio", ex);
            }
            finally
            {
                DB = null;
            }
        }
    }
}
