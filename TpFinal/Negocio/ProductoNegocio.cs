using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ProductoNegocio
    {
        AccesoDatos datos = new AccesoDatos();
        public List<Producto> listar()
        {
            List<Producto> lista = new List<Producto>();
            try
            {
                datos.setearConsulta("SELECT P.id as ART, P.CODIGO as COD, P.DESCRIPCION as DESCR, M.ID as MAR, M.CODIGO as MARCOD, M.DESCRIPCION as MARDE, C.id as CATE, C.CODIGO as CATECOD, C.DESCRIPCION AS CATEDE, PRECIOCOMPRA, GANANCIA, STOCK, STOCKMIN, P.estado as estado FROM PRODUCTO P, MARCAARTICULO M, CATEGORIAARTICULO C WHERE P.IDMARCAARTICULO = M.ID and P.IDCATEGORIAARTICULO = C.ID and p.estado = 'true'");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Producto aux = new Producto();
                    aux.id = (int)datos.Lector["ART"];
                    aux.codigo = (string)datos.Lector["COD"];
                    aux.descripcion = (string)datos.Lector["DESCR"];
                    aux.marca.id = (int)datos.Lector["MAR"];
                    aux.marca.codigo = (string)datos.Lector["MARCOD"];
                    aux.marca.descripcion = (string)datos.Lector["MARDE"];
                    aux.categoria.id = (int)datos.Lector["CATE"];
                    aux.categoria.codigo = (string)datos.Lector["CATECOD"];
                    aux.categoria.descripcion = (string)datos.Lector["CATEDE"];
                    aux.precioCompra = (decimal)datos.Lector["PRECIOCOMPRA"];
                    aux.ganacia = (decimal)datos.Lector["GANANCIA"];
                    aux.stockActual = (decimal)datos.Lector["STOCK"];
                    aux.stockMinimo = (decimal)datos.Lector["STOCKMIN"];
                    aux.estado = (bool)datos.Lector["estado"];
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

        public void Agregar(Producto producto)
        {
            try
            {
                datos.setearConsulta("  insert into Producto (codigo, descripcion, idMarcaArticulo, idCategoriaArticulo, precioCompra, ganancia, stock, stockMin, estado) values (@codigo, @desc, @marca, @categoria, @precio, @ganancia, @stock, @stockmin, @estado)");

                datos.SetearPARAMETROS("@codigo", producto.codigo);
                datos.SetearPARAMETROS("@desc", producto.descripcion);
                datos.SetearPARAMETROS("@marca", producto.marca.id);
                datos.SetearPARAMETROS("@categoria", producto.categoria.id);
                datos.SetearPARAMETROS("@precio", producto.precioCompra);
                datos.SetearPARAMETROS("@ganancia", producto.ganacia);
                datos.SetearPARAMETROS("@stock", producto.stockActual);
                datos.SetearPARAMETROS("@stockmin", producto.stockMinimo);
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

        public void Eliminar(int id)
        {
            try
            {
                datos.setearConsulta("update Producto set estado = 'true'  where id =" + id);
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

        public void Editar(Producto producto)
        {
            try
            {
                datos.setearConsulta("update Producto set descripcion = @desc, idMarcaArticulo = @marca, idCategoriaArticulo = @categoria, precioCompra = @precio, ganancia = @ganancia, stock = @stock, stockMin = @stockmin where id = @id");
                datos.SetearPARAMETROS("@desc",producto.descripcion);
                datos.SetearPARAMETROS("@marca",producto.marca.id);
                datos.SetearPARAMETROS("@categoria",producto.categoria.id);
                datos.SetearPARAMETROS("@precio",producto.precioCompra);
                datos.SetearPARAMETROS("@ganancia",producto.ganacia);
                datos.SetearPARAMETROS("@stock",producto.stockActual);
                datos.SetearPARAMETROS("@stockmin", producto.stockMinimo);
                datos.SetearPARAMETROS("@id", producto.id);

                datos.ejecutarEscritura();
            }
            catch(Exception ex)
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


