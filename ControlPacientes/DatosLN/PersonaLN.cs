using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlPacientes.DatosCD;
using ControlPacientes.Entidades;

namespace ControlPacientes.DatosLN
{
    public class PersonaLN
    {
        public List<Persona> ViewPersona()
        {
            List<Persona> Lista = new List<Persona>();
            Persona obp = null;
            try
            {
                List<cp_ListarPersonaResult> auxLista = PersonaCD.ListarPersona();
                foreach (cp_ListarPersonaResult op in auxLista)
                {
                    obp = new Persona(op.Cedula, op.Nombres, op.Apellidos, op.Direccion, op.Ciudad, (DateTime)op.FechaNacimiento, op.Celular);
                    Lista.Add(obp);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error Mostrar en la logica a Persona");
            }
        }

        public bool CreatePersona(Persona op)
        {
            try
            {
                PersonaCD.InsertarPersona(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error Create  Persona");
            }
        }
        public bool UpdatePersona(Persona op)
        {
            try
            {
                PersonaCD.ModificarPersona(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error Update  Persona");
            }
        }
        public bool DeletePersona(Persona op)
        {
            try
            {
                PersonaCD.EliminarPersona(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error Delete Persona");
            }
        }
        public bool DeletePersona(string ced)
        {
            try
            {
                PersonaCD.EliminarPersona(ced);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error Delete Persona");
            }
        }
    }
}
