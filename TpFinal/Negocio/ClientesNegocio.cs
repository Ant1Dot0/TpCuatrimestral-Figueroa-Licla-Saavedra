﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ClientesNegocio
    {
        AccesoDatos datos = new AccesoDatos();

        
        public List<Cliente> Listar()
        {
            List<Cliente> clientes = new List<Cliente>();

            try
            {
                datos.setearConsulta("select C.id as id, C.codigo as codigo, C.nombre as nombre, C.apellido as apellido, C.nDocumento as DNI, C.idCategoriaCliente as CategoriaCliente, CC.codigo as CodigoCat, CC.descripcion as DescripCat, C.telefono as telefono, C.email as email, C.direccion as direccion, C.estado as estado from Cliente as C, CategoriaCliente as CC where c.idCategoriaCliente = cc.id and C.estado = 'true'");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Cliente aux = new Cliente();
                    aux.id = (int)datos.Lector["id"];
                    aux.codigo = (string)datos.Lector["codigo"];
                    aux.nombre = (string)datos.Lector["nombre"];
                    aux.apellido = (string)datos.Lector["apellido"];
                    aux.nDocumento = (string)datos.Lector["DNI"];
                    aux.categoria.id = (int)datos.Lector["CategoriaCliente"];
                    aux.categoria.codigo = (string)datos.Lector["CodigoCat"];
                    aux.categoria.descripcion = (string)datos.Lector["DescripCat"];
                    aux.telefono = (string)datos.Lector["telefono"];
                    aux.email = (string)datos.Lector["email"];
                    aux.direccion = (string)datos.Lector["direccion"];
                    aux.estado = (bool)datos.Lector["estado"];
                    clientes.Add(aux);
                }

                return clientes;

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

        public void Agregar(Cliente Cliente)
        {
            try
            {
                datos.setearConsulta("insert into Cliente (codigo, nombre, apellido, nDocumento, idCategoriaCliente, telefono, email, direccion, estado) values (@codigo, @nombre, @apellido, @dni, @categoria, @tel, @email, @direcc, @est)");
                datos.SetearPARAMETROS("@codigo", Cliente.codigo);
                datos.SetearPARAMETROS("@nombre", Cliente.nombre);
                datos.SetearPARAMETROS("@apellido", Cliente.apellido);
                datos.SetearPARAMETROS("@dni", Cliente.nDocumento);
                datos.SetearPARAMETROS("@categoria", Cliente.categoria.id);
                datos.SetearPARAMETROS("@tel", Cliente.telefono);
                datos.SetearPARAMETROS("@email", Cliente.email);
                datos.SetearPARAMETROS("@direcc", Cliente.direccion);
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
                datos.setearConsulta("update Cliente set estado = 'true'  where id =" + id );
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
