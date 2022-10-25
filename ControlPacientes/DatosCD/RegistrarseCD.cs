using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlPacientes.Entidades;

namespace ControlPacientes.DatosCD
{
    public class RegistrarseCD
    {
        public static List<cp_ListarRegistroResult> ListarRegistro()
        {
            BDControlPacienteDataContext DB = null;
            try
            {
                using (DB = new BDControlPacienteDataContext())
                {
                    return DB.cp_ListarRegistro().ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error Listar Registro", ex);

            }
            finally
            {
                DB = null;
            }
        }

        public static List<cp_ListarRegistroFiltroResult> ListarRegistrosFiltro(string val)
        {
            BDControlPacienteDataContext DB = null;
            try
            {
                using (DB = new BDControlPacienteDataContext())
                {
                    return DB.cp_ListarRegistroFiltro(val).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error Listar registro Filtro", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static void InsertarRegistro(Registrarse op)
        {
            BDControlPacienteDataContext DB = null;
            try
            {
                using (DB = new BDControlPacienteDataContext())
                {
                    DB.cp_InsertarRegistarse(op.Cedula, op.Nombre, op.Contraseña, op.Tipo);
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
        public static void ModificarRegistro(Registrarse op)
        {
            BDControlPacienteDataContext DB = null;
            try
            {
                using (DB = new BDControlPacienteDataContext())
                {
                    DB.cp_ActualizarRegistarse(op.Cedula, op.Nombre, op.Contraseña, op.Tipo);
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error Actualizar Registro", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static void EliminarRegistro(Registrarse op)
        {
            BDControlPacienteDataContext DB = null;
            try
            {
                using (DB = new BDControlPacienteDataContext())
                {
                    DB.cp_EliminarRegistarse(op.Cedula);
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error Eliminar Registro", ex);
            }
            finally
            {
                DB = null;
            }
        }
    }
}
