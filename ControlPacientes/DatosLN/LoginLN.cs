using ControlPacientes.DatosCD;
using ControlPacientes.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlPacientes.DatosLN
{
    public class LoginLN
    {
        public List<Login> ViewLogin()
        {
            List<Login> Lista = new List<Login>();
            Login obp = null;
            try
            {
                List<cp_ListarLoginResult> auxLista = LoginCD.ListarLogin();
                foreach (cp_ListarLoginResult op in auxLista)
                {
                    obp = new Login(op.Nombre, op.Contraseña, op.Cedula);
                    Lista.Add(obp);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error Mostrar en la logica a Login");
            }
        }
        public bool CreateLogin(Login op)
        {
            try
            {
                LoginCD.InsertarLogin(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error Create  Login");
            }
        }
        public bool UpdateRecetaLogin(Login op)
        {
            try
            {
                LoginCD.ModificarLogin(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error Update  Login");
            }
        }
        public bool DeleteRegistrarse(Login op)
        {
            try
            {
                LoginCD.EliminarLogin(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error Delete Login");
            }
        }
    }
}
