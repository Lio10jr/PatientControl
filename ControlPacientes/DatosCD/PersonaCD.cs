using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlPacientes.Entidades;

namespace ControlPacientes.DatosCD
{
    public class PersonaCD
    {
        public static List<cp_ListarPersonaResult> ListarPersona()
        {
            BDControlPacienteDataContext DB = null;
            try
            {
                using (DB = new BDControlPacienteDataContext())
                {
                    return DB.cp_ListarPersona().ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error Listar Persona " + ex.Message);

            }
            finally
            {
                DB = null;
            }
        }
        public static void InsertarPersona(Persona op)
        {
            BDControlPacienteDataContext DB = null;
            try
            {
                using (DB = new BDControlPacienteDataContext())
                {
                    DB.cp_InsertarPersona(op.Cedula, op.Nombres, op.Apellidos, op.Direccion, op.Ciudad, op.FechaNacimiento, op.Celular);
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error Insertar Persona", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static void ModificarPersona(Persona op)
        {
            BDControlPacienteDataContext DB = null;
            try
            {
                using (DB = new BDControlPacienteDataContext())
                {
                    DB.cp_ActualizarPersona(op.Cedula, op.Nombres, op.Apellidos, op.Direccion, op.Ciudad,(DateTime) op.FechaNacimiento, op.Celular);
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error Actualizar Persona", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static void EliminarPersona(Persona op)
        {
            BDControlPacienteDataContext DB = null;
            try
            {
                using (DB = new BDControlPacienteDataContext())
                {
                    DB.cp_EliminarPersona(op.Cedula);
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error Eliminar Persona", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static void EliminarPersona(string ced)
        {
            BDControlPacienteDataContext DB = null;
            try
            {
                using (DB = new BDControlPacienteDataContext())
                {
                    DB.cp_EliminarPersona(ced);
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error Eliminar Persona", ex);
            }
            finally
            {
                DB = null;
            }
        }
    }
}
