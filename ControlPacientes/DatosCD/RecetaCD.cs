using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlPacientes.Entidades;
using ControlPacientes.Inventario;

namespace ControlPacientes.DatosCD
{
    public class RecetaCD
    {
        public static List<cp_ListarRecetasResult> ListarReceta()
        {
            BDControlPacienteDataContext DB = null;
            try
            {
                using (DB = new BDControlPacienteDataContext())
                {
                    return DB.cp_ListarRecetas().ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error Listar Receta " + ex.Message);

            }
            finally
            {
                DB = null;
            }
        }

        public static List<cp_ListarRecetasFiltroResult> ListarRecetasFiltro(string val)
        {
            BDControlPacienteDataContext DB = null;
            try
            {
                using (DB = new BDControlPacienteDataContext())
                {
                    return DB.cp_ListarRecetasFiltro(val).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error Listar recetas Filtro", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static void InsertarReceta(Receta op)
        {
            BDControlPacienteDataContext DB = null;
            try
            {
                using (DB = new BDControlPacienteDataContext())
                {
                    DB.cp_InsertarRecetas(op.NumReceta, op.Dosis, op.FecheActual, op.IdMedicamento, op.IdMedico, op.IdPaciente);
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error Insertar Receta " + ex.Message);
            }
            finally
            {
                DB = null;
            }
        }
        public static void ModificarReceta(Receta op)
        {
            BDControlPacienteDataContext DB = null;
            try
            {
                using (DB = new BDControlPacienteDataContext())
                {
                    DB.cp_ActualizarRecetas(op.NumReceta, op.Dosis, op.FecheActual, op.IdMedicamento, op.IdMedico,op.IdPaciente);
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error Actualizar Receta", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static void EliminarReceta(Receta op)
        {
            BDControlPacienteDataContext DB = null;
            try
            {
                using (DB = new BDControlPacienteDataContext())
                {
                    DB.cp_EliminarRecetas(op.NumReceta);
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error Eliminar Receta", ex);
            }
            finally
            {
                DB = null;
            }
        }
    }
}
