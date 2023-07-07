using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;


namespace Negocio
{
    public class MarcaArticuloNegocio
    {
        AccesoDatos datos = new AccesoDatos();


        public List<MarcaArticulo> Listar()
        {

            List<MarcaArticulo> MarcaxArticulo = new List<MarcaArticulo>();

            try
            {
                datos.setearConsulta("select id, codigo, descripcion, estado from MarcaArticulo");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    MarcaArticulo aux = new MarcaArticulo();
                    aux.id = (int)datos.Lector["id"];
                    aux.codigo = (string)datos.Lector["codigo"];
                    aux.descripcion = (string)datos.Lector["descripcion"];
                    aux.estado = (bool)datos.Lector["estado"];

                    MarcaxArticulo.Add(aux);

                }

                return MarcaxArticulo;

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



        public void Agregar(MarcaArticulo aux)
        {
            try
            {
                datos.setearConsulta("insert into MarcaArticulo (codigo, descripcion, estado) values (@cod, @desc, @est)");
                datos.SetearPARAMETROS("@cod", aux.codigo);
                datos.SetearPARAMETROS("@desc", aux.descripcion);
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
                datos.setearConsulta("update MarcaArticulo set estado = false where id=" + id);
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
