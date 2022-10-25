using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlPacientes.Entidades;
using ControlPacientes.Inventario;

namespace ControlPacientes.DatosCD
{
    public class PacienteCD
    {
        public static List<cp_ListarPacienteResult> ListarPaciente()
        {
            BDControlPacienteDataContext DB = null;
            try
            {
                using (DB = new BDControlPacienteDataContext())
                {
                    return DB.cp_ListarPaciente().ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error Listar Paciente " + ex.Message);

            }
            finally
            {
                DB = null;
            }
        }

        public static List<cp_ListarPacienteFiltroResult> ListarPacienteFiltro(string val)
        {
            BDControlPacienteDataContext DB = null;
            try
            {
                using (DB = new BDControlPacienteDataContext())
                {
                    return DB.cp_ListarPacienteFiltro(val).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error Listar paciente Filtro", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static void InsertarPaciente(Paciente op)
        {
            BDControlPacienteDataContext DB = null;
            try
            {
                using (DB = new BDControlPacienteDataContext())
                {
                    DB.cp_InsertarPaciente(op.IdPaciente, op.Estado, op.AfiliadoSS, op.Cedula);
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error Insertar Paciente "+ ex.Message);
            }
            finally
            {
                DB = null;
            }
        }
        public static void ModificarPaciente(Paciente op)
        {
            BDControlPacienteDataContext DB = null;
            try
            {
                using (DB = new BDControlPacienteDataContext())
                {
                    DB.cp_ActualizarPaciente(op.IdPaciente, op.Estado, op.AfiliadoSS, op.Cedula);
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error Actualizar Paciente " + ex.Message);
            }
            finally
            {
                DB = null;
            }
        }
        public static void EliminarPaciente(Paciente op)
        {
            BDControlPacienteDataContext DB = null;
            try
            {
                using (DB = new BDControlPacienteDataContext())
                {
                    DB.cp_EliminarPaciente(op.IdPaciente);
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error Eliminar Paciente " + ex.Message);
            }
            finally
            {
                DB = null;
            }
        }
    }
}
