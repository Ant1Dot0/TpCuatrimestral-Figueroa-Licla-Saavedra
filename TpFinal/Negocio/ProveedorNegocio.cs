using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    /*AGREGAR PROVEEDOR / MODIFICAR PROVEEDOR / ELIMINAR PROVEEDOR*/

    public class ProveedorNegocio
    {
        AccesoDatos datos = new AccesoDatos();


        public List<Proveedor> ListarProveedor()
        {
            List<Proveedor> proveedores = new List<Proveedor>();

            try
            {
                /*Corregir consulta*/
                datos.setearConsulta("select B.id as id, B.codigo as codigo, B.razonSocial as razonSocial, B.cuit as cuit, B.idCategoriaProveedor as idCategoriaProveedor, B.telefono as telefono, B.email as email, B.direccion as direccion, B.estado as estado from Proveedor as B where B.estado = 'true'");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Proveedor aux = new Proveedor();
                    aux.id = (int)datos.Lector["id"];
                    aux.codigo = (string)datos.Lector["codigo"];
                    aux.razonSocial = (string)datos.Lector["razonSocial"];
                    aux.cuit = (string)datos.Lector["cuit"];
                    aux.categoria.id = (int)datos.Lector["idCategoriaProveedor"];
                    aux.telefono = (string)datos.Lector["telefono"];
                    aux.email = (string)datos.Lector["email"];
                    aux.direccion = (string)datos.Lector["direccion"];
                    aux.estado = (bool)datos.Lector["estado"];

                    proveedores.Add(aux);
                }

                return proveedores;

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

        public void Agregar(Proveedor Proveedors)
        {
            try
            {
                datos.setearConsulta("insert into Proveedor ( codigo, razonSocial, cuit, idCategoriaProveedor, telefono, email, direccion, estado) values ( @codigo, @razonSocial, @cuit, @idCategoriaProv, @tel, @email, @direcc, @est)");
                datos.SetearPARAMETROS("@codigo", Proveedors.codigo);
                datos.SetearPARAMETROS("@razonSocial", Proveedors.razonSocial);
                datos.SetearPARAMETROS("@cuit", Proveedors.cuit);
                datos.SetearPARAMETROS("@idCategoriaProv", Proveedors.categoria.id);
                datos.SetearPARAMETROS("@tel", Proveedors.telefono);
                datos.SetearPARAMETROS("@email", Proveedors.email);
                datos.SetearPARAMETROS("@direcc", Proveedors.direccion);
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
                datos.setearConsulta("update Proveedor set estado = 'true' where id =" + id);
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
