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


        public List<DetalleProducto> Listar()
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
                    aux.monto = (decimal)datos.Lector["monto"];
                    aux.montoDescuento = (decimal)datos.Lector["montoDesc"];
                    aux.precioVenta = (decimal)datos.Lector["precioVenta"];
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

        public void Agregar(DetalleProducto aux)
        {
            try
            {
                datos.setearConsulta("insert into DetalleProducto (codProducto, codComprobante, descripcion, cantidad, precioVenta, montoDescuento, monto, estado) values (@cod, @codComprobante, @desc, @cantidad, @precioVenta, @montoDescuento, @monto, @est)");
                datos.SetearPARAMETROS("@cod", aux.codProducto);
                datos.SetearPARAMETROS("@codComprobante", aux.codComprobante);
                datos.SetearPARAMETROS("@desc", aux.descripcion);
                datos.SetearPARAMETROS("@cantidad", aux.cantidad);
                datos.SetearPARAMETROS("@precioVenta", aux.precioVenta);
                datos.SetearPARAMETROS("@montoDescuento", aux.montoDescuento);
                datos.SetearPARAMETROS("@monto", aux.monto);
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
