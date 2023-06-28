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
                datos.setearConsulta("select id, codigo, descripcion from CategoriaProveedor");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    CategoriaProveedor aux = new CategoriaProveedor();
                    aux.id = (int)datos.Lector["id"];
                    aux.codigo = (string)datos.Lector["codigo"];
                    aux.descripcion = (string)datos.Lector["descripcion"];

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
                datos.setearConsulta("insert into CategoriaProveedor (id, codigo, descripcion) values (@id, @cod, @desc)");
                datos.SetearPARAMETROS("@id", aux.id);
                datos.SetearPARAMETROS("@cod", aux.codigo);
                datos.SetearPARAMETROS("@desc", aux.descripcion);

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
                datos.setearConsulta("delete from CategoriaProveedor where id=" + id);
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
