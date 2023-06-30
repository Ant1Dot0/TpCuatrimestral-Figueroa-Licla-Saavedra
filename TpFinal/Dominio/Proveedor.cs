using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dominio
{
    public class Proveedor
    {
        public int id { get; set; }
        public string codigo { get; set; }

        public string razonSocial { get; set; }

        public string cuit { get; set; }

        public CategoriaProveedor categoria { get; set; }

        public string telefono { get; set; }

        public string email { get; set; }

        

        public string direccion { get; set; }
        public Proveedor()
        {
            this.categoria = new CategoriaProveedor();
        }
    }



    /*    ---------------------------------------------------------- */

    /* ------------------- FUNCION LISTAR PROVEDOR---------------   */
    /*
    public class Proveedor
    {
        AccesoDatos data = new AccesoDatos();
        public List<Proveedor> listarproveedor()
        {
            List<Proveedor> lista = new List<Proveedor>();
            try
            {
                data.setearConsulta("select Proveedor.id, codigo, razonSocial, Proveedor.cuit, Proveedor.idCategoriaProveedor, Proveedor.movil, Proveedor.telefono, Proveedor.email, Proveedor.direccion from Proveedor");
                data.ejecutarLectura();

                while (data.Lector.Read())
                {
                    Proveedor ax = new Proveedor();
                    ax.id = (int)data.Lector["ART"];
                    aux.codigo = (string)data.Lector["COD"];
                    aux.razonSocial = (string)data.Lector["DESCR"];
                    aux.marca.id = (int)datos.Lector["MAR"];
                    aux.marca.codigo = (string)datos.Lector["MARCOD"];
                    aux.marca.descripcion = (string)datos.Lector["MARDE"];
                    aux.categoria.id = (int)datos.Lector["CATE"];
                    aux.categoria.codigo = (string)datos.Lector["CATECOD"];
                    aux.categoria.descripcion = (string)datos.Lector["CATEDE"];

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


    */

}
