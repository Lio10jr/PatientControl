using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlPacientes.DatosCD;
using ControlPacientes.Entidades;

namespace ControlPacientes.DatosLN
{
    public class HistorialPacienteLN
    {
        public List<HistorialPaciente> ViewHistorialPaciente()
        {
            List<HistorialPaciente> Lista = new List<HistorialPaciente>();
            HistorialPaciente obp = null;
            try
            {
                List<cp_ListarHistorialPacienteResult> auxLista = HistorialPacienteCD.ListarHistorialPaciente();
                foreach (cp_ListarHistorialPacienteResult op in auxLista)
                {
                    obp = new HistorialPaciente(op.idRegistroPaciente, (int)op.NumeroConsultas, (DateTime)op.UltimaFechaConsulta, op.idPaciente, op.idMedico);
                    Lista.Add(obp);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error Mostrar en la logica a HistorialPaciente");
            }
        }

        public List<HistorialPaciente> ViewHistorialPacienteFiltro(string valor)
        {
            List<HistorialPaciente> Lista = new List<HistorialPaciente>();
            HistorialPaciente obp = null;
            try
            {
                List<cp_ListarHistorialPacienteFiltroResult> auxLista = HistorialPacienteCD.ListarHistorialpacienteFiltro(valor);
                foreach (cp_ListarHistorialPacienteFiltroResult op in auxLista)
                {
                    obp = new HistorialPaciente(op.idRegistroPaciente, (int)op.NumeroConsultas, (DateTime)op.UltimaFechaConsulta, op.idPaciente, op.idMedico);
                    Lista.Add(obp);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error Mostrar en la logica a Historial Paciente filtro");
            }
        }

        public bool CreateHistorialPaciente(HistorialPaciente op)
        {
            try
            {
                HistorialPacienteCD.InsertarHistorialPaciente(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error Create  HistorialPaciente");
            }
        }
        public bool UpdateHistorialPaciente(HistorialPaciente op)
        {
            try
            {
                HistorialPacienteCD.ModificarHistorialPaciente(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error Update  HistorialPaciente");
            }
        }
        public bool DeleteHistorialPaciente(HistorialPaciente op)
        {
            try
            {
                HistorialPacienteCD.EliminarHistorialPaciente(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error Delete HistorialPaciente");
            }
        }
    }
}
