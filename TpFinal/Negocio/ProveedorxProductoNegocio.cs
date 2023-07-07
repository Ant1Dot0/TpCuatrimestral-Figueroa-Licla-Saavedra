using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ProveedorxProductoNegocio
    {
        AccesoDatos datos = new AccesoDatos();
        public List<ProveedorxProducto> Listar()

        {
            List<ProveedorxProducto> lista = new List<ProveedorxProducto>();

            try
            {
                datos.setearConsulta("SELECT codigo, codigoProveedor, codigoProducto FROM ProveedorxProducto");
                datos.ejecutarLectura();


                while (datos.Lector.Read())
                {
                    ProveedorxProducto aux = new ProveedorxProducto();
                    aux.codigo = (string)datos.Lector["codigo"];
                    aux.codigoProveedor = (string)datos.Lector["codigoProveedor"];
                    aux.codigoProducto = (string)datos.Lector["codigoProducto"];

                    lista.Add(aux);
                }
                return lista;

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

        public List<ProveedorxProducto> ListarxProducto(string codigo)

        {
            List<ProveedorxProducto> lista = new List<ProveedorxProducto>();

            try
            {
                datos.setearConsulta("SELECT codigo, codigoProveedor, codigoProducto FROM ProveedorxProducto where codigoProducto = '"+ codigo +"'");
                datos.ejecutarLectura();


                while (datos.Lector.Read())
                {
                    ProveedorxProducto aux = new ProveedorxProducto();
                    aux.codigo = (string)datos.Lector["codigo"];
                    aux.codigoProveedor = (string)datos.Lector["codigoProveedor"];
                    aux.codigoProducto = (string)datos.Lector["codigoProducto"];

                    lista.Add(aux);
                }
                return lista;

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

        public void Eliminar(string codigo)
        {
            try
            {
                datos.setearConsulta("delete ProveedorxProducto  where codigo =" + codigo);
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

        public void Agregar(ProveedorxProducto aux)
        {
            try
            {
                datos.setearConsulta("insert into ProveedorxProducto (codigo, codigoProveedor, codigoProducto) values (@codigo, @proveedor, @producto)");
                datos.SetearPARAMETROS("@codigo", aux.codigo);
                datos.SetearPARAMETROS("@proveedor", aux.codigoProveedor);
                datos.SetearPARAMETROS("@producto", aux.codigoProducto);

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

        public void EliminarxProducto(string codProducto)
        {
            try
            {
                datos.setearConsulta("delete ProveedorxProducto where codigoProducto = '" + codProducto +"'");
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
