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
        AccesoDatos datos = new AccesoDatos();

        public bool Logueo(Usuario usuarios)
        {
            Usuario DatoDelUsuario = new Usuario();

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

        public List<Usuario> Listar()
        {
            List<Usuario> lista = new List<Usuario>();

            try
            {
                datos.setearConsulta("select U.id as id, U.idLogin as idLogin, U.passwordd as passwordd , U.email as email, U.nombre as nombre, U.apellido as apellido, U.telefono as telefono, U.movil as movil, U.direccion as direccion, R.id as idRol, R.descripcion as descRol, R.codigo as codRol, U.estado as estUsuario from Usuario as U, Rol as R where U.estado = 1 And R.id = U.id");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Usuario aux = new Usuario();
                    aux.id = (int)datos.Lector["id"];
                    aux.idLogin = (string)datos.Lector["idLogin"];
                    aux.password = (string)datos.Lector["passwordd"];
                    aux.email = (string)datos.Lector["email"];
                    aux.nombre = (string)datos.Lector["nombre"];
                    aux.apellido = (string)datos.Lector["apellido"];
                    aux.telefono = (string)datos.Lector["telefono"];
                    aux.movil = (string)datos.Lector["movil"];
                    aux.direccion = (string)datos.Lector["direccion"];
                    aux.rol.id = (int)datos.Lector["idRol"];
                    aux.rol.descripcion = (string)datos.Lector["descRol"];
                    aux.rol.codigo = (string)datos.Lector["codRol"];
                    aux.estado = (bool)datos.Lector["estUsuario"];

                    lista.Add(aux);
                }

                return lista;
            }   
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
            
        }


        public void Agregar(Usuario usuario)
        {
            try
            {
                datos.setearConsulta("insert into Usuario ( idLogin, password, email, nombre, apellido, telefono, movil, direccion, idRol, estado) values ( @idLogin, @password, @email, @nombre, @apellido, @telefono, @movil, @direccion, @idRol, @est)");
                datos.SetearPARAMETROS("@idLogin", usuario.idLogin);
                datos.SetearPARAMETROS("@password", usuario.password);
                datos.SetearPARAMETROS("@email", usuario.email);
                datos.SetearPARAMETROS("@nombre", usuario.nombre);
                datos.SetearPARAMETROS("@apellido", usuario.apellido);
                datos.SetearPARAMETROS("@telefono", usuario.telefono);
                datos.SetearPARAMETROS("@movil", usuario.movil);
                datos.SetearPARAMETROS("@direccion", usuario.direccion);
                datos.SetearPARAMETROS("@idRol", usuario.rol);
                datos.SetearPARAMETROS("@est", true);

                datos.ejecutarEscritura();



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


        public void Eliminar(int id)
        {
            try
            {
                datos.setearConsulta("update Usuario set estado = 'true' where id =" + id);
                datos.ejecutarEscritura();
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
