using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class UsuarioNegocio
    {


        public bool Logueo(Usuario usuarios)
        {
            Usuario DatoDelUsuario = new Usuario();
            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.setearConsulta("Select U.id as id, R.codigo as Rcodigo, R.descripcion as Rdescripcion From Usuario as U, Rol as R where U.email = @email AND U.passwordd = @pass");
                datos.SetearPARAMETROS("@email", usuarios.email);
                datos.SetearPARAMETROS("@pass", usuarios.password);

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {

                    usuarios.id = (int)datos.Lector["id"];
                    
                    usuarios.rol.codigo = (string)datos.Lector["Rcodigo"];
                    usuarios.rol.descripcion = (string)datos.Lector["Rdescripcion"];
                                   

                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

    }
}
