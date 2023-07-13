using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Negocio;


namespace Negocio
{
    public class VentaNegocio
    {
        AccesoDatos datos = new AccesoDatos();



        public List<CompVenta> Listar()
        {

            List<CompVenta> Ventas = new List<CompVenta>();

            try
            {
                datos.setearConsulta("select CC.id as id, CC.codigo as codigo, CC.puntoVenta as puntoVenta, CC.numero as numero, CC.idCliente as idCliente, CC.fechaComp as fechaComp, CC.idUsuario as idUsuario, CC.subtotal as subtotal, CC.totalDescuento as totalDesc, CC.descuentoComp as descuentoComp, CC.totalComprobante as totalComprobante, CC.estado as estado, Ct.id as Clienteid, Ct.nombre, ct.apellido, Ct.codigo, Ct.direccion, Ct.email, Ct.estado as estadoCliente, ct.idCategoriaCliente, Ct.movil, Ct.nDocumento, Ct.telefono  from CompVenta as CC, Cliente as Ct where CC.id = Ct.id");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    CompVenta aux = new CompVenta();
                    aux.id = (int)datos.Lector["id"];
                    aux.puntoVenta = (int)datos.Lector["puntoVenta"];
                    aux.codigo = (string)datos.Lector["codigo"];
                    aux.numero = (int)datos.Lector["numero"];
                    aux.cliente.id = (int)datos.Lector["idCliente"];
                    aux.cliente.nombre = (string)datos.Lector["nombre"];
                    aux.cliente.apellido = (string)datos.Lector["apellido"];
                    aux.fechaComp = (DateTime)datos.Lector["fechaComp"];
                    aux.vendedor.id = (int)datos.Lector["idUsuario"];
                    aux.subtotal = (decimal)datos.Lector["subtotal"];
                    aux.totalDescuento = (decimal)datos.Lector["totalDesc"];
                    aux.descuentoComp = (decimal)datos.Lector["descuentoComp"];
                    aux.totalComprobante = (decimal)datos.Lector["totalComprobante"];
                    aux.estado = (bool)datos.Lector["estado"];


                    Ventas.Add(aux);

                }

                return Ventas;

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
                datos.setearConsulta("update CompVenta set estado = false where id=" + id);
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

        public void Agregar(CompVenta venta )
        {
            try
            {
                datos.setearConsulta("  insert into CompVenta (codigo, puntoVenta, numero, idCliente, fechaComp, idUsuario, subtotal, totalDescuento, descuentoComp, totalComprobante, estado) values (@codigo, @puntoVenta, @numero, @idCliente, @fechaComp, @idUsuario, @subtotal, @totalDescuento,@descuentoComp, @totalComprobante, @estado)");

                datos.SetearPARAMETROS("@codigo", venta.codigo);
                datos.SetearPARAMETROS("@puntoVenta", venta.puntoVenta);
                datos.SetearPARAMETROS("@numero", venta.numero);
                datos.SetearPARAMETROS("@idCliente", venta.cliente.id);
                datos.SetearPARAMETROS("@fechaComp", venta.fechaComp);
                datos.SetearPARAMETROS("@idUsuario", venta.vendedor.id);
                datos.SetearPARAMETROS("@subtotal", venta.subtotal);
                datos.SetearPARAMETROS("@totalDescuento", venta.totalDescuento);
                datos.SetearPARAMETROS("@totalComprobante", venta.totalComprobante);
                datos.SetearPARAMETROS("@descuentoComp", venta.descuentoComp);
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
