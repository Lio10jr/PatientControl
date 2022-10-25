using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlPacientes.Entidades;
using ControlPacientes.Inventario;

namespace ControlPacientes.DatosCD
{
    public class DoctorCD1
    {
        public static List<cp_ListarMedicoResult> ListarDoctor()
        {
            BDControlPacienteDataContext DB = null;
            try
            {
                using (DB = new BDControlPacienteDataContext())
                {
                    return DB.cp_ListarMedico().ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error Listar Docotor", ex);

            }
            finally
            {
                DB = null;
            }
        }

        public static List<cp_ListarMedicoFiltroResult> ListarDoctorFiltro(string val)
        {
            BDControlPacienteDataContext DB = null;
            try
            {
                using (DB = new BDControlPacienteDataContext())
                {
                    return DB.cp_ListarMedicoFiltro(val).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error Listar Docotor Filtro", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static void InsertarMedico(DoctorE op)
        {
            BDControlPacienteDataContext DB = null;
            try
            {
                using (DB = new BDControlPacienteDataContext())
                {
                    DB.cp_InsertarMedico(op.Id, op.Titulo, op.Especialidad, op.Estado, op.Ced);
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error Insertar Medico", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static void ModificarMedico(DoctorE op)
        {
            BDControlPacienteDataContext DB = null;
            try
            {
                using (DB = new BDControlPacienteDataContext())
                {
                    DB.cp_ActualizarMedico(op.Id, op.Titulo, op.Especialidad, op.Estado, op.Ced);
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error Actualizar Medico", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static void EliminarMedico(DoctorE op)
        {
            BDControlPacienteDataContext DB = null;
            try
            {
                using (DB = new BDControlPacienteDataContext())
                {
                    DB.cp_EliminarMedico(op.Id);
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error Eliminar Medico", ex);
            }
            finally
            {
                DB = null;
            }
        }
    }
}
