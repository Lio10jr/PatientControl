using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlPacientes.Entidades;
using ControlPacientes.Inventario;

namespace ControlPacientes.DatosCD
{
    public class MedicamentoCD
    {
        public static List<cp_ListarMedicamentosResult> ListarMedicamento()
        {
            BDControlPacienteDataContext DB = null;
            try
            {
                using (DB = new BDControlPacienteDataContext())
                {
                    return DB.cp_ListarMedicamentos().ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error Listar Medicamentos", ex);

            }
            finally
            {
                DB = null;
            }
        }

        public static List<cp_ListarMedicamentoFiltroResult> ListarMedicamentoFiltro(string val)
        {
            BDControlPacienteDataContext DB = null;
            try
            {
                using (DB = new BDControlPacienteDataContext())
                {
                    return DB.cp_ListarMedicamentoFiltro(val).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error Listar medicamento Filtro", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static void InsertarMedicamento(Medicamentos op)
        {
            BDControlPacienteDataContext DB = null;
            try
            {
                using (DB = new BDControlPacienteDataContext())
                {
                    DB.cp_InsertarMedicamento(op.IdMedicamento, op.Nombre, op.Peso, op.Tipo);
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error Insertar Medicamento", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static void ModificarMedicamento(Medicamentos op)
        {
            BDControlPacienteDataContext DB = null;
            try
            {
                using (DB = new BDControlPacienteDataContext())
                {
                    DB.cp_ActualizarMedicamento(op.IdMedicamento, op.Nombre, op.Peso, op.Tipo);
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error Actualizar Medicamento", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static void EliminarMedicamento(Medicamentos op)
        {
            BDControlPacienteDataContext DB = null;
            try
            {
                using (DB = new BDControlPacienteDataContext())
                {
                    DB.cp_EliminarMedicamento(op.IdMedicamento);
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error Eliminar Medicamento", ex);
            }
            finally
            {
                DB = null;
            }
        }
    }
}
