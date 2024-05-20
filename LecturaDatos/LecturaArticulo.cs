using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Dominio;


namespace LecturaDatos
{
    public class LecturaArticulo
    {
        //Carga los datos a la lista 
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("SELECT A.Codigo, A.Nombre, A.Descripcion AS DescripcionArticulo, M.Descripcion AS Marca, C.Descripcion AS Categoria, I.ImagenUrl, A.Precio, A.Id AS IdArticulo, M.Id AS IdMarca, C.Id AS IdCategoria FROM ARTICULOS A INNER JOIN MARCAS M ON M.Id = A.IdMarca INNER JOIN CATEGORIAS C ON C.Id = A.IdCategoria LEFT JOIN IMAGENES I ON I.IdArticulo = A.Id WHERE NOT EXISTS (SELECT 1 FROM ARTICULOS A2 INNER JOIN IMAGENES I2 ON I2.IdArticulo = A2.Id WHERE A2.Codigo = A.Codigo AND I2.Id > I.Id) ");
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["IdArticulo"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["DescripcionArticulo"];
                    aux.Precio = (decimal)datos.Lector["Precio"];

                    aux.Marca = new Marca();
                    if (!Convert.IsDBNull(datos.Lector["IdMarca"]))
                        aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    if (!Convert.IsDBNull(datos.Lector["Marca"]))
                        aux.Marca.Descripcion = (string)datos.Lector["Marca"];

                    aux.Categoria = new Categoria();
                    if (!Convert.IsDBNull(datos.Lector["IdCategoria"]))
                        aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    if (!Convert.IsDBNull(datos.Lector["Categoria"]))
                        aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];

                    if (!Convert.IsDBNull(datos.Lector["ImagenUrl"]))
                        aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];

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
                datos.CerrarConexion();
            }
        }
        public List<Articulo> listar(int id)
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("SELECT A.Codigo, A.Nombre, A.Descripcion AS DescripcionArticulo, M.Descripcion AS Marca, C.Descripcion AS Categoria, I.ImagenUrl, A.Precio, M.Id AS IdMarca, C.Id AS IdCategoria FROM ARTICULOS A INNER JOIN MARCAS M ON M.Id = A.IdMarca INNER JOIN CATEGORIAS C ON C.Id = A.IdCategoria LEFT JOIN IMAGENES I ON I.IdArticulo = A.Id WHERE NOT EXISTS (SELECT 1 FROM ARTICULOS A2 INNER JOIN IMAGENES I2 ON I2.IdArticulo = A2.Id WHERE A2.Codigo = A.Codigo AND I2.Id > I.Id) ");
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["DescripcionArticulo"];
                    aux.Precio = (decimal)datos.Lector["Precio"];

                    aux.Marca = new Marca();
                    if (!Convert.IsDBNull(datos.Lector["IdMarca"]))
                        aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    if (!Convert.IsDBNull(datos.Lector["Marca"]))
                        aux.Marca.Descripcion = (string)datos.Lector["Marca"];

                    aux.Categoria = new Categoria();
                    if (!Convert.IsDBNull(datos.Lector["IdCategoria"]))
                        aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    if (!Convert.IsDBNull(datos.Lector["Categoria"]))
                        aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];

                    if (!Convert.IsDBNull(datos.Lector["ImagenUrl"]))
                        aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];

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
                datos.CerrarConexion();
            }
        }

        //Agrega datos a la dgv
        public void agregar(Articulo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio) VALUES (@Codigo, @Nombre, @Descripcion, @IdMarca, @IdCategoria, @Precio)");

                datos.SetearParametro("@Codigo", nuevo.Codigo);
                datos.SetearParametro("@Nombre", nuevo.Nombre);
                datos.SetearParametro("@Descripcion", nuevo.Descripcion);
                datos.SetearParametro("@IdMarca", nuevo.Marca.Id);
                datos.SetearParametro("@IdCategoria", nuevo.Categoria.Id);
                datos.SetearParametro("@Precio", nuevo.Precio);

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

        //Agrega img a la BBDD
        public void agregarImagen(Articulo nuevo)
        {
            nuevo.Id = buscarId();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("INSERT INTO IMAGENES (IdArticulo, ImagenUrl) VALUES (@IdArticulo, @ImagenUrl)");
                datos.SetearParametro("@IdArticulo", nuevo.Id);
                datos.SetearParametro("@ImagenUrl", nuevo.ImagenUrl);
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
        public void agregarImagen(int Id,string URL)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("INSERT INTO IMAGENES (IdArticulo, ImagenUrl) VALUES (@IdArticulo, @ImagenUrl)");
                datos.SetearParametro("@IdArticulo", Id);
                datos.SetearParametro("@ImagenUrl",URL);
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

        //Busca por ID en BBDD
        private int buscarId()
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("SELECT MAX(Id) AS Id FROM ARTICULOS");
                datos.EjecutarLectura();
                datos.Lector.Read();
                return (int)datos.Lector["Id"];
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

        //Edita articulo en BBDD
        public void editarArticulo(Articulo editado)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("UPDATE ARTICULOS SET Codigo = @Codigo, Nombre = @Nombre, Descripcion = @Descripcion, IdMarca = @IdMarca, IdCategoria = @IdCategoria, Precio = @Precio WHERE Id = @Id");

                datos.SetearParametro("@Codigo", editado.Codigo);
                datos.SetearParametro("@Nombre", editado.Nombre);
                datos.SetearParametro("@Descripcion", editado.Descripcion);
                datos.SetearParametro("@IdMarca", editado.Marca.Id);
                datos.SetearParametro("@IdCategoria", editado.Categoria.Id);
                datos.SetearParametro("@Precio", editado.Precio);
                datos.SetearParametro("@Id", editado.Id);

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

        //Edita Img 
        public void editarImagen(Articulo editado)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("UPDATE IMAGENES SET ImagenUrl = @ImagenUrl WHERE IdArticulo = @IdArticulo");
                datos.SetearParametro("@ImagenUrl", editado.ImagenUrl);
                datos.SetearParametro("@IdArticulo", editado.Id);

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

        //Elimina articulo en BBDD
        public void eliminarArticulo(int Id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("DELETE FROM ARTICULOS WHERE Id = @Id");
                datos.SetearParametro("@Id", Id);

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

        //Elimina Imagen BBDD
        public void eliminarImagen(Articulo eliminado)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("DELETE FROM IMAGENES WHERE IdArticulo = @IdArticulo");
                datos.SetearParametro("@IdArticulo", eliminado.Id);

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

        //Filtra Articulo y devuelve ordenado
        public List<Articulo> filtrarArticulo(string campo, string criterio, string avanzado)
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = ("SELECT A.Codigo, A.Nombre, A.Descripcion AS DescripcionArticulo, M.Descripcion AS Marca, C.Descripcion AS Categoria, I.ImagenUrl, A.Precio, A.Id AS IdArticulo, M.Id AS IdMarca, C.Id AS IdCategoria FROM ARTICULOS A INNER JOIN MARCAS M ON M.Id = A.IdMarca INNER JOIN CATEGORIAS C ON C.Id = A.IdCategoria LEFT JOIN IMAGENES I ON I.IdArticulo = A.Id WHERE NOT EXISTS (SELECT 1 FROM ARTICULOS A2 INNER JOIN IMAGENES I2 ON I2.IdArticulo = A2.Id WHERE A2.Codigo = A.Codigo AND I2.Id > I.Id) ");
                switch (campo)
                {
                    case "Código":
                        switch(criterio)
                        {
                            case "Mayor que":
                                consulta += "AND A.Codigo > @avanzado";
                                break;
                            case "Menor que":
                                consulta += "AND A.Codigo < @avanzado";
                                break;
                            case "Igual a":
                                consulta += "AND A.Codigo = @avanzado";
                                break;
                        }
                        break;
                    case "Nombre":
                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "AND A.Nombre LIKE @avanzado + '%'";
                                break;
                            case "Termina con":
                                consulta += "AND A.Nombre LIKE '%' + @avanzado";
                                break;
                            case "Contiene":
                                consulta += "AND A.Nombre LIKE '%' + @avanzado + '%'";
                                break;
                        }
                        break;
                    case "Marca":
                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "AND M.Descripcion LIKE @avanzado + '%'";
                                break;
                            case "Termina con":
                                consulta += "AND M.Descripcion LIKE '%' + @avanzado";
                                break;
                            case "Contiene":
                                consulta += "AND M.Descripcion LIKE '%' + @avanzado + '%'";
                                break;
                        }
                        break;
                    case "Categoría":
                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "AND C.Descripcion LIKE @avanzado + '%'";
                                break;
                            case "Termina con":
                                consulta += "AND C.Descripcion LIKE '%' + @avanzado";
                                break;
                            case "Contiene":
                                consulta += "AND C.Descripcion LIKE '%' + @avanzado + '%'";
                                break;
                        }
                        break;
                }
                datos.SetearConsulta(consulta);
                datos.SetearParametro("@avanzado", avanzado);
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["IdArticulo"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["DescripcionArticulo"];
                    aux.Precio = (decimal)datos.Lector["Precio"];

                    aux.Marca = new Marca();
                    if (!Convert.IsDBNull(datos.Lector["IdMarca"]))
                        aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    if (!Convert.IsDBNull(datos.Lector["Marca"]))
                        aux.Marca.Descripcion = (string)datos.Lector["Marca"];

                    aux.Categoria = new Categoria();
                    if (!Convert.IsDBNull(datos.Lector["IdCategoria"]))
                        aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    if (!Convert.IsDBNull(datos.Lector["Categoria"]))
                        aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];

                    if (!Convert.IsDBNull(datos.Lector["ImagenUrl"]))
                        aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


    }
}
