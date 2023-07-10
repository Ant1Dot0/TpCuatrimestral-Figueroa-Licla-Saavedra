using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class CategoriasProveedorNegocio
    {
        AccesoDatos datos = new AccesoDatos();

        public List<CategoriaProveedor> Listar()
        {

            List<CategoriaProveedor> CategoriaxProveedor = new List<CategoriaProveedor>();

            try
            {
                datos.setearConsulta("select id, codigo, descripcion, estado from CategoriaProveedor");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    CategoriaProveedor aux = new CategoriaProveedor();
                    aux.id = (int)datos.Lector["id"];
                    aux.codigo = (string)datos.Lector["codigo"];
                    aux.descripcion = (string)datos.Lector["descripcion"];
                    aux.estado = (bool)datos.Lector["estado"];

                    CategoriaxProveedor.Add(aux);

                }

                return CategoriaxProveedor;

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


        public void Agregar(CategoriaProveedor aux)
        {
            try
            {
                datos.setearConsulta("insert into CategoriaProveedor (id, codigo, descripcion, estado) values (@id, @cod, @desc, @est");
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
                datos.setearConsulta("update CategoriaProveedor set estado = 'false' where id=" + id);
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


        public void Update(CategoriaProveedor aux)
        {
            {
                try
                {
                    datos.setearConsulta("update CategoriaProveedor set codigo = @cod, descripcion = @desc where Id = @ID ");
                    datos.SetearPARAMETROS("@ID", aux.id);
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
        }



    }
}
