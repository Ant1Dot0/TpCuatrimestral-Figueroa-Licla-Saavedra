using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class TalonarioNegocio
    {
        AccesoDatos datos = new AccesoDatos();

        public List<Talonario> Listar()
        {

            List<Talonario> talonarios = new List<Talonario>();

            try
            {
                datos.setearConsulta("select id, cod, descripcion, PDV, tipoComprobante, ultNumero, estado from TALONARIOS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Talonario aux = new Talonario();
                    aux.id = (int)datos.Lector["id"];
                    aux.codigo = (string)datos.Lector["cod"];
                    aux.descripcion = (string)datos.Lector["descripcion"];
                    aux.tipoComprobante = (int)datos.Lector["tipoComprobante"];
                    aux.pdv = (int)datos.Lector["PDV"];
                    aux.ultNumero = (int)datos.Lector["ultNumero"];
                    aux.estado = (bool)datos.Lector["estado"];

                    talonarios.Add(aux);

                }

                return talonarios;

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

        public void Agregar(Talonario aux)
        {
            try
            {
                datos.setearConsulta("INSERT INTO TALONARIOS(COD,TIPOCOMPROBANTE,DESCRIPCION, PDV, ULTNUMERO,ESTADO) values (@id, @cod, @desc, @pdv, @ultN, @tipo, @est)");
                datos.SetearPARAMETROS("@id", aux.id);
                datos.SetearPARAMETROS("@cod", aux.codigo);
                datos.SetearPARAMETROS("@desc", aux.descripcion);
                datos.SetearPARAMETROS("@tipo", aux.tipoComprobante);
                datos.SetearPARAMETROS("@pdv", aux.pdv);
                datos.SetearPARAMETROS("@ultN", aux.ultNumero);
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
                datos.setearConsulta("update talonarios set estado = false where id=" + id);
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

        public void Editar(Talonario talonario)
        {
            try
            {
                datos.setearConsulta("update TALONARIOS set descripcion = @desc, pdv = @pdv, ultNumero = @ultN, tipoComprobante = @tipo where id = @id");
                datos.SetearPARAMETROS("@desc", talonario.descripcion);
                datos.SetearPARAMETROS("@pdv", talonario.pdv);
                datos.SetearPARAMETROS("@ultN", talonario.ultNumero);
                datos.SetearPARAMETROS("@tipo", talonario.tipoComprobante);
                datos.SetearPARAMETROS("@id", talonario.id);

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
