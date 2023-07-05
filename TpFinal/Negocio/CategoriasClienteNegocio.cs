using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class CategoriasClienteNegocio
    {
        AccesoDatos datos = new AccesoDatos();

        public List<CategoriaCliente> Listar() {
            
            List<CategoriaCliente> CategoriaxCliente = new List<CategoriaCliente>();

            try
            {
                datos.setearConsulta("select id, codigo, descripcion, estado from CategoriaCliente");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    CategoriaCliente aux = new CategoriaCliente();
                    aux.id = (int)datos.Lector["id"];
                    aux.codigo = (string)datos.Lector["codigo"];
                    aux.descripcion = (string)datos.Lector["descripcion"];
                    aux.estado = (bool)datos.Lector["estado"];

                    CategoriaxCliente.Add(aux);

                }

                return CategoriaxCliente;

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

        public void Agregar(CategoriaCliente aux)
        {
            try
            {
                datos.setearConsulta("insert into CategoriaCliente (id, codigo, descripcion, estado) values (@id, @cod, @desc, @est)");
                datos.SetearPARAMETROS("@id", aux.id);
                datos.SetearPARAMETROS("@cod", aux.codigo);
                datos.SetearPARAMETROS("@desc", aux.descripcion);
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
                datos.setearConsulta("update CategoriaCliente set estado = false where id=" + id);
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
