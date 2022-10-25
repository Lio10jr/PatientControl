using ControlPacientes.DatosCD;
using ControlPacientes.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlPacientes.DatosLN
{
    public class DoctorLN
    {
        public List<DoctorE> ViewDoctor()
        {
            List<DoctorE> ListaDoctor = new List<DoctorE>();
            DoctorE obp = null;
            try
            {
                List<cp_ListarMedicoResult> auxLista = DoctorCD1.ListarDoctor();
                foreach (cp_ListarMedicoResult op in auxLista)
                {
                    obp = new DoctorE(op.idMedico, op.Titulo, op.Especialidad, op.Estado, op.Cedula);
                    ListaDoctor.Add(obp);
                }
                return ListaDoctor;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error Mostrar en la logica a Doctor");
            }
        }

        public List<DoctorE> ViewDoctorFiltro(string valor)
        {
            List<DoctorE> Lista = new List<DoctorE>();
            DoctorE obp = null;
            try
            {
                List<cp_ListarMedicoFiltroResult> auxLista = DoctorCD1.ListarDoctorFiltro(valor);
                foreach (cp_ListarMedicoFiltroResult op in auxLista)
                {
                    obp = new DoctorE(op.idMedico, op.Titulo, op.Especialidad, op.Estado, op.Cedula);
                    Lista.Add(obp);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error Mostrar en la logica a Doctor filtro");
            }
        }

        public bool CreateDoctor(DoctorE op)
        {
            try
            {
                DoctorCD1.InsertarMedico(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error Create  Doctor");
            }
        }
        public bool UpdateDoctor(DoctorE op)
        {
            try
            {
                DoctorCD1.ModificarMedico(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error Update  Doctor");
            }
        }
        public bool DeleteDoctor(DoctorE op)
        {
            try
            {
                DoctorCD1.EliminarMedico(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error Delete Doctor");
            }
        }
    }
}
