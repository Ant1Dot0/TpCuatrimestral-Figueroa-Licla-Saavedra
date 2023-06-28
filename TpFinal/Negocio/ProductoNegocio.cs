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
                datos.setearConsulta("SELECT P.id as ART, P.CODIGO as COD, P.DESCRIPCION as DESCR, M.ID as MAR, M.CODIGO as MARCOD, M.DESCRIPCION as MARDE, C.id as CATE, C.CODIGO as CATECOD, C.DESCRIPCION AS CATEDE, PRECIOCOMPRA, GANANCIA, STOCK, STOCKMIN FROM PRODUCTO P, MARCAARTICULO M, CATEGORIAARTICULO C WHERE P.IDMARCAARTICULO = M.ID and P.IDCATEGORIAARTICULO = C.ID");
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
    }


}


