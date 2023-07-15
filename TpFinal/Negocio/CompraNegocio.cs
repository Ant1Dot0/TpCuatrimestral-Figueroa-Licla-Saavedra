using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Negocio;


namespace Negocio
{
    public class CompraNegocio
    {
        AccesoDatos datos = new AccesoDatos();


        public List<CompCompra> Listar()
        {

            List<CompCompra> compras = new List<CompCompra>();

            try
            {
                datos.setearConsulta("select CC.id as id, CC.puntoVenta as puntoVenta, CC.codigo as codigo, CC.numero as numero, CC.idProveedor as idProveedor, CC.fechaComp as fechaComp, CC.idUsuario as idUsuario, CC.subtotal as subtotal, CC.totalDescuento as totalDesc, CC.descuentoCompra as descuentoComp, CC.totalComprobante as totalComprobante, CC.estado as estado from CompCompra as CC");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    CompCompra aux = new CompCompra();
                    aux.id = (int)datos.Lector["id"];
                    aux.puntoVenta = (string)datos.Lector["puntoVenta"];
                    aux.codigo = (string)datos.Lector["codigo"];
                    aux.numero = (string)datos.Lector["numero"];
                    aux.proveedor.id = (int)datos.Lector["idProveedor"];
                    aux.fechaComp = (DateTime)datos.Lector["fechaComp"];
                    aux.vendedor.id = (int)datos.Lector["idUsuario"];
                    aux.subtotal = (decimal)datos.Lector["subtotal"];
                    aux.totalDescuento = (decimal)datos.Lector["totalDesc"];
                    aux.descuentoComp = (decimal)datos.Lector["descuentoComp"];
                    aux.totalComprobante = (decimal)datos.Lector["totalComprobante"];
                    aux.estado = (bool)datos.Lector["estado"];

                    compras.Add(aux);

                }

                return compras;

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
                datos.setearConsulta("update CompCompra set estado = false where id=" + id);
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

        public void Agregar(CompCompra compra)
        {
            try
            {
                datos.setearConsulta("  insert into CompCompra (codigo, puntoVenta, numero, idProveedor, fechaComp, idUsuario, subtotal, totalDescuento, descuentoCompra, totalComprobante, estado) values (@codigo, @puntoVenta, @numero, @idProveedor, @fechaComp, @idUsuario, @subtotal, @totalDescuento, @descuentoComp, @totalComprobante, @estado)");

                datos.SetearPARAMETROS("@codigo", compra.codigo);
                datos.SetearPARAMETROS("@puntoVenta", compra.puntoVenta);
                datos.SetearPARAMETROS("@numero", compra.numero);
                datos.SetearPARAMETROS("@idProveedor", compra.proveedor.id);
                datos.SetearPARAMETROS("@fechaComp", compra.fechaComp);
                datos.SetearPARAMETROS("@idUsuario", compra.vendedor.id);
                datos.SetearPARAMETROS("@subtotal", compra.subtotal);
                datos.SetearPARAMETROS("@totalDescuento", compra.totalDescuento);
                datos.SetearPARAMETROS("@totalComprobante", compra.totalComprobante);
                datos.SetearPARAMETROS("@descuentoComp", compra.descuentoComp);
                datos.SetearPARAMETROS("@estado", true);
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
