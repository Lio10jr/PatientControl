using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlPacientes.DatosCD;
using ControlPacientes.Entidades;

namespace ControlPacientes.DatosLN
{
    public class PacienteLN
    {
        public List<Paciente> ViewPaciente()
        {
            List<Paciente> ListaPaciente = new List<Paciente>();
            Paciente obp = null;
            try
            {
                List<cp_ListarPacienteResult> auxLista = PacienteCD.ListarPaciente();
                foreach (cp_ListarPacienteResult op in auxLista)
                {
                    obp = new Paciente(op.idPaciente, op.Estado, op.AfiliadoSS, op.Cedula);
                    ListaPaciente.Add(obp);
                }
                return ListaPaciente;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error Mostrar en la logica a Paciente");
            }
        }

        public List<Paciente> ViewPacienteFiltro(string valor)
        {
            List<Paciente> Lista = new List<Paciente>();
            Paciente obp = null;
            try
            {
                List<cp_ListarPacienteFiltroResult> auxLista = PacienteCD.ListarPacienteFiltro(valor);
                foreach (cp_ListarPacienteFiltroResult op in auxLista)
                {
                    obp = new Paciente(op.idPaciente, op.Estado, op.AfiliadoSS, op.Cedula);
                    Lista.Add(obp);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error Mostrar en la logica a Paciente filtro");
            }
        }
        public bool CreatePaciente(Paciente op)
        {
            try
            {
                PacienteCD.InsertarPaciente(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error Create  Paciente");
            }
        }
        public bool UpdatePaciente(Paciente op)
        {
            try
            {
                PacienteCD.ModificarPaciente(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error Update  Paciente");
            }
        }
        public bool DeletePaciente(Paciente op)
        {
            try
            {
                PacienteCD.EliminarPaciente(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error Delete Paciente");
            }
        }
    }
}
