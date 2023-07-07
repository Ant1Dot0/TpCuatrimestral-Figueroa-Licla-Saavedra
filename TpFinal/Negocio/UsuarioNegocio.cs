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

                datos.setearConsulta("Select ID, Nombre, Apellido, From Usuarios where email = @email AND pass = @pass");
                datos.SetearPARAMETROS("@email", usuarios.email);
                datos.SetearPARAMETROS("@pass", usuarios.password);

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {

                    usuarios.id = (int)datos.Lector["Id"];
                   
                    usuarios.nombre = (string)datos.Lector["Nombre"];
                    usuarios.apellido = (string)datos.Lector["Apellido"];
                                   

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
