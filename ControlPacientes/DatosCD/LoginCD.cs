using ControlPacientes.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlPacientes.DatosCD
{
    public class LoginCD
    {
        public static List<cp_ListarLoginResult> ListarLogin()
        {
            BDControlPacienteDataContext DB = null;
            try
            {
                using (DB = new BDControlPacienteDataContext())
                {
                    return DB.cp_ListarLogin().ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error Listar Login " + ex.Message);

            }
            finally
            {
                DB = null;
            }
        }
        public static void InsertarLogin(Login op)
        {
            BDControlPacienteDataContext DB = null;
            try
            {
                using (DB = new BDControlPacienteDataContext())
                {
                    DB.cp_InsertarLogin(op.Usuario, op.Contraseña, op.Cedula);
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error Insertar Login", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static void ModificarLogin(Login op)
        {
            BDControlPacienteDataContext DB = null;
            try
            {
                using (DB = new BDControlPacienteDataContext())
                {
                    DB.cp_ActualizarLogin(op.Usuario, op.Contraseña, op.Cedula);
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error Actualizar Login", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static void EliminarLogin(Login op)
        {
            BDControlPacienteDataContext DB = null;
            try
            {
                using (DB = new BDControlPacienteDataContext())
                {
                    DB.cp_EliminarLogin(op.Cedula);
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error Eliminar Login", ex);
            }
            finally
            {
                DB = null;
            }
        }
    }
}
