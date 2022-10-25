using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlPacientes.DatosCD;
using ControlPacientes.Entidades;

namespace ControlPacientes.DatosLN
{
    public class MedicamentoLN
    {
        public List<Medicamentos> ViewMedicamentos()
        {
            List<Medicamentos> Lista = new List<Medicamentos>();
            Medicamentos obp = null;
            try
            {
                List<cp_ListarMedicamentosResult> auxLista = MedicamentoCD.ListarMedicamento();
                foreach (cp_ListarMedicamentosResult op in auxLista)
                {
                    obp = new Medicamentos(op.idMedicamento, op.Nombre, op.Peso, op.Tipo);
                    Lista.Add(obp);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error Mostrar en la logica a Medicamentos");
            }
        }

        public List<Medicamentos> ViewMedicamentosFiltro(string valor)
        {
            List<Medicamentos> Lista = new List<Medicamentos>();
            Medicamentos obp = null;
            try
            {
                List<cp_ListarMedicamentoFiltroResult> auxLista = MedicamentoCD.ListarMedicamentoFiltro(valor);
                foreach (cp_ListarMedicamentoFiltroResult op in auxLista)
                {
                    obp = new Medicamentos(op.idMedicamento, op.Nombre, op.Peso, op.Tipo);
                    Lista.Add(obp);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error Mostrar en la logica a Medicamentos filtro");
            }
        }
        public bool CreateMedicamentos(Medicamentos op)
        {
            try
            {
                MedicamentoCD.InsertarMedicamento(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error Create  Medicamentos");
            }
        }
        public bool UpdateMedicamentos(Medicamentos op)
        {
            try
            {
                MedicamentoCD.ModificarMedicamento(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error Update  Medicamentos");
            }
        }
        public bool DeleteMedicamentos(Medicamentos op)
        {
            try
            {
                MedicamentoCD.EliminarMedicamento(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error Delete Medicamentos");
            }
        }
    }
}
