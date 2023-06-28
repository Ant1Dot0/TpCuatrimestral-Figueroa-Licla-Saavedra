using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class CategoriasClienteNegocio
    {
        AccesoDatos datos = new AccesoDatos();

        public List<CategoriaCliente> Listar() {
            
            List<CategoriaCliente> CategoriaxCliente = new List<CategoriaCliente>();

            try
            {
                datos.setearConsulta("select id, codigo, descripcion from CategoriaCliente");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    CategoriaCliente aux = new CategoriaCliente();
                    aux.id = (int)datos.Lector["id"];
                    aux.codigo = (string)datos.Lector["codigo"];
                    aux.descripcion = (string)datos.Lector["descripcion"];

                    CategoriaxCliente.Add(aux);

                }

                return CategoriaxCliente;

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

        public void Agregar(CategoriaCliente aux)
        {
            try
            {
                datos.setearConsulta("insert into CategoriaCliente (id, codigo, descripcion) values (@id, @cod, @desc)");
                datos.SetearPARAMETROS("@id", aux.id);
                datos.SetearPARAMETROS("@cod", aux.codigo);
                datos.SetearPARAMETROS("@desc", aux.descripcion);

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
                datos.setearConsulta("delete from CategoriaCliente where id=" + id);
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
