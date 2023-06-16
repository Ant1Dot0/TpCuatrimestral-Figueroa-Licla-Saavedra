using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Negocio
{
    class AccesoDatos
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;

        public SqlDataReader Lector
        {
            get { return lector; }
        }

        public AccesoDatos()
        {
            // -DESCOMENTAR LINEA DE CODIGO DE BASE DE DATOS A UTILIZAR-

            // conexion = new SqlConnection("server= .\\SQLEXPRESS; database=CATALOGO_P3_DB; integrated security=true");

            //CONEXION BASE DATOS SAAVEDRA RODRIGO -
            conexion = new SqlConnection("server= .\\SQLEXPRESS; database=OrganizAR; integrated security=true");


            comando = new SqlCommand();
        }

        public void setearConsulta(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }

        public void ejecutarLectura()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ejecutarEscritura()
        {
            comando.Connection = conexion;

            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void SetearPARAMETROS(string nombre, object value)
        {
            comando.Parameters.AddWithValue(nombre, value);
        }

        public void cerrarConexion()
        {
            if (lector != null)
                lector.Close();
            conexion.Close();
        }
    }
}
