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
                datos.setearConsulta("select CC.id as id, CC.puntoVenta as puntoVenta, CC.numero as numero, CC.idCliente as idCliente, CC.fechaComp as fechaComp, CC.idUsuario as idUsuario, CC.subtotal as subtotal, CC.totalDescuento as totalDesc, CC.descuentoCompra as descuentoComp, CC.totalComprobante as totalComprobante, CC.estado as estado from CompVenta as CC");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    CompVenta aux = new CompVenta();
                    aux.id = (int)datos.Lector["id"];
                    aux.puntoVenta = (string)datos.Lector["puntoVenta"];
                    aux.numero = (string)datos.Lector["numero"];
                    aux.cliente.id = (int)datos.Lector["idCliente"];
                    aux.fechaComp = (DateTime)datos.Lector["fechaComp"];
                    aux.vendedor.id = (int)datos.Lector["idUsuario"];
                    aux.subtotal = (int)datos.Lector["subtotal"];
                    aux.totalDescuento = (int)datos.Lector["totalDesc"];
                    aux.descuentoComp = (int)datos.Lector["descuentoComp"];
                    aux.totalComprobante = (int)datos.Lector["totalComprobante"];
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


    }
}
