using ControlPacientes.DatosCD;
using ControlPacientes.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlPacientes.DatosLN
{
    public class RegistrarseLN
    {
        public List<Registrarse> ViewRregistro()
        {
            List<Registrarse> Lista = new List<Registrarse>();
            Registrarse obp = null;
            try
            {
                List<cp_ListarRegistroResult> auxLista = RegistrarseCD.ListarRegistro();
                foreach (cp_ListarRegistroResult op in auxLista)
                {
                    obp = new Registrarse(op.Cedula, op.Nombre, op.Contraseña, op.Tipo);
                    Lista.Add(obp);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error Mostrar en la logica a Registrarse");
            }
        }

        public List<Registrarse> ViewRegistrosFiltro(string valor)
        {
            List<Registrarse> Lista = new List<Registrarse>();
            Registrarse obp = null;
            try
            {
                List<cp_ListarRegistroFiltroResult> auxLista = RegistrarseCD.ListarRegistrosFiltro(valor);
                foreach (cp_ListarRegistroFiltroResult op in auxLista)
                {
                    obp = new Registrarse(op.Cedula, op.Nombre, op.Contraseña, op.Tipo);
                    Lista.Add(obp);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error Mostrar en la logica a Registrarse filtro");
            }
        }

        public bool CreateRegistrarse(Registrarse op)
        {
            try
            {
                RegistrarseCD.InsertarRegistro(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error Create  Registrarse");
            }
        }
        public bool UpdateRecetaRegistrarse(Registrarse op)
        {
            try
            {
                RegistrarseCD.ModificarRegistro(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error Update  Registrarse");
            }
        }
        public bool DeleteRegistrarse(Registrarse op)
        {
            try
            {
                RegistrarseCD.EliminarRegistro(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error Delete Registrarse");
            }
        }
    }
}
