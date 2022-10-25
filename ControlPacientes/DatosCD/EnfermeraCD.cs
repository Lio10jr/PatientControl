using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlPacientes.Entidades;
using ControlPacientes.Inventario;

namespace ControlPacientes.DatosCD
{
    public class EnfermeraCD
    {
        public static List<cp_ListarEnfermeraResult> ListarEnfermera()
        {
            BDControlPacienteDataContext DB = null;
            try
            {
                using (DB = new BDControlPacienteDataContext())
                {
                    return DB.cp_ListarEnfermera().ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error Listar Enfermera", ex);

            }
            finally
            {
                DB = null;
            }
        }

        public static List<cp_ListarEnfermeraFiltroResult> ListarEnfermeraFiltro(string val)
        {
            BDControlPacienteDataContext DB = null;
            try
            {
                using (DB = new BDControlPacienteDataContext())
                {
                    return DB.cp_ListarEnfermeraFiltro(val).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error Listar enfermera Filtro", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static void InsertarEnfermera(Enfermera op)
        {
            BDControlPacienteDataContext DB = null;
            try
            {
                using (DB = new BDControlPacienteDataContext())
                {
                    DB.cp_InsertarEnfermera(op.IdEnfermera, op.Titulo, op.Especialidad, op.Cedula);
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error Insertar Enfermera", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static void ModificarEnfermera(Enfermera op)
        {
            BDControlPacienteDataContext DB = null;
            try
            {
                using (DB = new BDControlPacienteDataContext())
                {
                    DB.cp_ActualizarEnfermera(op.IdEnfermera, op.Titulo, op.Especialidad, op.Cedula);
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error Actualizar Enfermera", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static void EliminarEnfermera(Enfermera op)
        {
            BDControlPacienteDataContext DB = null;
            try
            {
                using (DB = new BDControlPacienteDataContext())
                {
                    DB.cp_EliminarEnfermera(op.IdEnfermera);
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error Eliminar Enfermera", ex);
            }
            finally
            {
                DB = null;
            }
        }
    }
}



