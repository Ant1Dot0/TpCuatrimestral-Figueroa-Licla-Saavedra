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
    }
}
