using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace LecturaDatos
{
    public class LecturaMarca
    {
        //Carga los datos a la lista
        public List<Marca> listar()
        {
            List<Marca> lista = new List<Marca>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("SELECt Id,Descripcion from MARCAS");
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Marca aux = new Marca();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

                    lista.Add(aux);
                }
                datos.CerrarConexion();
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //Agrega datos a la tabla Marcas
        public void agregar (Marca nueva)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {   
                datos.SetearConsulta("insert into MARCAS (Descripcion) values ('"+nueva+"')");
                datos.ejecutarAccion();


            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally 
            {
                datos.CerrarConexion();
            }
        }

        //Modifica datos a la tabla Marcas
        public void modificar(Marca nueva)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("UPDATE MARCAS SET  Descripcion = @Descripcion WHERE Id = @Id");
                datos.SetearParametro("@Id", nueva.Id);
                datos.SetearParametro("@Descripcion", nueva.Descripcion);

                datos.ejecutarAccion();


            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
        
        //Elimina datos de la tabla Marcas
        public void eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("delete from MARCAS WHERE Id = @Id");
                datos.SetearParametro("@Id", valor: id);
                datos.ejecutarAccion();


            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
    }
}
