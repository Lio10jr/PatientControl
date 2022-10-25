using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlPacientes.Entidades;
using ControlPacientes.Inventario;

namespace ControlPacientes.DatosCD
{
    public class FichaMedicaCD
    {
        public static List<cp_ListarFichaMedicaResult> ListarFichaMedica()
        {
            BDControlPacienteDataContext DB = null;
            try
            {
                using (DB = new BDControlPacienteDataContext())
                {
                    return DB.cp_ListarFichaMedica().ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error Listar FichaMedica", ex);

            }
            finally
            {
                DB = null;
            }
        }

        public static List<cp_ListarFichaMedicaFiltroResult> ListarFichaMedicaFiltro(string val)
        {
            BDControlPacienteDataContext DB = null;
            try
            {
                using (DB = new BDControlPacienteDataContext())
                {
                    return DB.cp_ListarFichaMedicaFiltro(val).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error Listar FichaMedica Filtro", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static void InsertarFichaMedica(FichaMedica op)
        {
            BDControlPacienteDataContext DB = null;
            try
            {
                using (DB = new BDControlPacienteDataContext())
                {
                    DB.cp_InsertarFichaMedica(op.IdFichaM, op.IdPaciente, op.Madre, op.Padre, op.Estudios, op.GrupoSanguineo, op.Edad, op.Peso, op.Estatura);
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error Insertar FichaMedica", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static void ModificarFichaMedica(FichaMedica op)
        {
            BDControlPacienteDataContext DB = null;
            try
            {
                using (DB = new BDControlPacienteDataContext())
                {
                    DB.cp_ActualizarFichaMedica(op.IdFichaM, op.IdPaciente, op.Madre, op.Padre, op.Estudios, op.GrupoSanguineo, op.Edad, op.Peso, op.Estatura);
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error Actualizar FichaMedica", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static void EliminarFichaMedica(FichaMedica op)
        {
            BDControlPacienteDataContext DB = null;
            try
            {
                using (DB = new BDControlPacienteDataContext())
                {
                    DB.cp_EliminarFichaMedica(op.IdFichaM);
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error Eliminar FichaMedica", ex);
            }
            finally
            {
                DB = null;
            }
        }

    }
}
