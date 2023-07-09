using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Negocio;


namespace Negocio
{
    public class DetalleProductoNegocio
    {

        AccesoDatos datos = new AccesoDatos();


        List<DetalleProducto> Listar()
        {
            List<DetalleProducto> detalleProductos = new List<DetalleProducto>();

            try
            {
                datos.setearConsulta("select D.id as id, D.cantidad as cantidad, D.codProducto as codProducto, D.descripcion as descripcion, D.monto as monto, D.montoDescuento as montoDesc, D.precioVenta as precioVenta, D.estado as estado from DetalleProducto as D");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    DetalleProducto aux = new DetalleProducto();
                    aux.id = (int)datos.Lector["id"];
                    aux.cantidad = (int)datos.Lector["cantidad"];
                    aux.codProducto = (string)datos.Lector["codProducto"];
                    aux.descripcion = (string)datos.Lector["descripcion"];
                    aux.monto = (int)datos.Lector["monto"];
                    aux.montoDescuento = (int)datos.Lector["montoDesc"];
                    aux.precioVenta = (int)datos.Lector["precioVenta"];
                    aux.estado = (bool)datos.Lector["estado"];

                    detalleProductos.Add(aux);

                }

                return detalleProductos;

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
                datos.setearConsulta("update DetalleProducto set estado = false where id=" + id);
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
