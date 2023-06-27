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
                datos.setearConsulta("select B.id as id, B.codigo as codigo, B.razonSocial as razonSocial, B.cuit as cuit, B.idCategoriaProveedor as idCategoriaProveedor, B.movil as movil, B.telefono as telefono, B.email as email, B.direccion as direccion from Proveedor as B");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Proveedor aux = new Proveedor();
                    aux.id = (int)datos.Lector["id"];
                    aux.codigo = (int)datos.Lector["codigo"];
                    aux.razonSocial = (string)datos.Lector["razonSocial"];
                    aux.cuit = (string)datos.Lector["cuit"];
                    aux.categoria.id = (int)datos.Lector["CategoriaProveedor"];
                    aux.movil = (string)datos.Lector["movil"];
                    aux.telefono = (string)datos.Lector["telefono"];
                    aux.email = (string)datos.Lector["Email"];
                    aux.direccion = (string)datos.Lector["Direccion"];


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
                datos.setearConsulta("insert into Proveedor (codigo, razonSocial, cuit, idCategoriaProveedor,movil, telefono, email, direccion) values (@codigo, @razonSocial, @cuit, @idCategoriaProv,@movil, @tel, @email, @direcc)");
                datos.SetearPARAMETROS("@codigo", Proveedors.codigo);
                datos.SetearPARAMETROS("@razonSocial", Proveedors.razonSocial);
                datos.SetearPARAMETROS("@acuit", Proveedors.cuit);
                datos.SetearPARAMETROS("@idCategoriaProveedor", Proveedors.categoria);
                datos.SetearPARAMETROS("@movil", Proveedors.movil);
                datos.SetearPARAMETROS("@tel", Proveedors.telefono);
                datos.SetearPARAMETROS("@email", Proveedors.email);
                datos.SetearPARAMETROS("@direcc", Proveedors.direccion);
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
                datos.setearConsulta("delete from Proveedor  where id =" + id);
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
