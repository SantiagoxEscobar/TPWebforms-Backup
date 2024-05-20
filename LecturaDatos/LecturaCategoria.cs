using Dominio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LecturaDatos
{
    public class LecturaCategoria
    {

        //Carga los datos a la lista Categorias
        public List<Categoria> listar()
        {
            List<Categoria> lista = new List<Categoria>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("SELECt Id,Descripcion from CATEGORIAS");
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Categoria aux = new Categoria();
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

        //Agrega datos a la tabla Categorias
        public void agregar(Categoria categoria)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("insert into CATEGORIAS (Descripcion) values (@descripcion)");
                datos.SetearParametro("@descripcion", categoria.Descripcion);
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

        //Modifica datos a la tabla Categorias
        public void modificar(Categoria nueva)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("UPDATE CATEGORIAS SET  Descripcion = @Descripcion WHERE Id = @Id");
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

        //Elimina datos de la tabla Categorias
        public void eliminar(int id)
        {
                AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("delete from CATEGORIAS WHERE Id = @Id");
                datos.SetearParametro("@Id", id);
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
