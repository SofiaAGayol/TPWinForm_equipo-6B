using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using dominio;

namespace negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.setearConsulta("Select A.Id, Codigo, Nombre, A.Descripcion, A.IdMarca, A.IdCategoria,Precio,C.Id as IdC, C.Descripcion as DescripcionC, M.Id as IdM, M.Descripcion as DescripcionM,I.Id as IdIm, I.IdArticulo, I.ImagenUrl From ARTICULOS A, CATEGORIAS C, MARCAS M, IMAGENES I Where C.Id = A.IdCategoria And M.Id = A.IdMarca And I.IdArticulo = A.Id");
                //datos.setearConsulta("select * from ARTICULOS");

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    int idArticulo = (int)datos.Lector["Id"];
               
                    Articulo articulo = lista.FirstOrDefault(a => a.Id == idArticulo);

                    if (articulo == null)
                    {
                        articulo = new Articulo();
                        articulo.Id = (int)datos.Lector["Id"];
                        articulo.Codigo = (string)datos.Lector["Codigo"];
                        articulo.Nombre = (string)datos.Lector["Nombre"];
                        articulo.Descripcion = (string)datos.Lector["Descripcion"];
                        articulo.Precio = (decimal)datos.Lector["Precio"];

                        //Marca
                        articulo.Marca = new Marca();
                        articulo.Marca.Id = (int)datos.Lector["IdM"];
                        articulo.Marca.Descripcion = (string)datos.Lector["DescripcionM"];

                        //Categoria
                        articulo.Categoria = new Categoria();
                        articulo.Categoria.Id = (int)datos.Lector["IdC"];
                        articulo.Categoria.Descripcion = (string)datos.Lector["DescripcionC"];

                        //Imagenes
                        if (!(datos.Lector["IdIm"] is DBNull))
                        {
                            articulo.Imagenes = new List<Imagen>();
                            Imagen imagen = new Imagen();

                            imagen.Id = (int)datos.Lector["IdIm"];
                            imagen.IdArticulo = (int)datos.Lector["IdArticulo"];
                            imagen.ImagenUrl = (string)datos.Lector["ImagenUrl"];

                            articulo.Imagenes.Add(imagen);
                        }


                        lista.Add(articulo);
                    }
                }

                datos.cerrarConexion();
                return lista;
       
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<Articulo> filtrar(string campo, string criterio, string filtro)
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "Select A.Id, Codigo, Nombre, A.Descripcion, A.IdMarca, A.IdCategoria,Precio,C.Id as IdC, C.Descripcion as DescripcionC, M.Id as IdM, M.Descripcion as DescripcionM,I.Id as IdIm, I.IdArticulo, I.ImagenUrl From ARTICULOS A, CATEGORIAS C, MARCAS M, IMAGENES I Where C.Id = A.IdCategoria And M.Id = A.IdMarca And I.IdArticulo = A.Id";
                if (campo == "Codigo")
                {
                    switch (criterio)
                    {
                        case "Mayor a":
                            consulta += "Numero > " + filtro;
                            break;
                        case "Menor a":
                            consulta += "Numero < " + filtro;
                            break;
                        default:
                            consulta += "Numero = " + filtro;
                            break;
                    }
                }
                else if (campo == "Nombre")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "Nombre like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += "Nombre like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "Nombre like '%" + filtro + "%'";
                            break;
                    }
                }
                else
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "A.Descripcion like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += "A.Descripcion like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "A.Descripcion like '%" + filtro + "%'";
                            break;
                    }
                }

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulo articulo = new Articulo();
                    articulo.Id = (int)datos.Lector["Id"];
                    articulo.Codigo = (string)datos.Lector["Codigo"];
                    articulo.Nombre = (string)datos.Lector["Nombre"];
                    articulo.Descripcion = (string)datos.Lector["Descripcion"];
                    articulo.Precio = (decimal)datos.Lector["Precio"];

                    //Marca
                    articulo.Marca = new Marca();
                    articulo.Marca.Id = (int)datos.Lector["IdM"];
                    articulo.Marca.Descripcion = (string)datos.Lector["DescripcionM"];

                    //Categoria
                    articulo.Categoria = new Categoria();
                    articulo.Categoria.Id = (int)datos.Lector["IdC"];
                    articulo.Categoria.Descripcion = (string)datos.Lector["DescripcionC"];

                    //Imagenes
                    if (!(datos.Lector["IdIm"] is DBNull))
                    {
                        articulo.Imagenes = new List<Imagen>();
                        Imagen imagen = new Imagen();

                        imagen.Id = (int)datos.Lector["IdIm"];
                        imagen.IdArticulo = (int)datos.Lector["IdArticulo"];
                        imagen.ImagenUrl = (string)datos.Lector["ImagenUrl"];

                        articulo.Imagenes.Add(imagen);
                    }


                    lista.Add(articulo);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Articulo buscarArticulo(int articuloID)
        {
            AccesoDatos datos = new AccesoDatos();


            datos.setearConsulta("SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.IdMarca, A.Precio Precio, M.Descripcion AS NombreMarca, M.Id AS MarcaId, I.ImagenUrl AS ImagenUrl, I.Id AS imgId, C.Descripcion AS categoriaDescripcion, C.Id AS CatID FROM ARTICULOS A, MARCAS M, IMAGENES I, CATEGORIAS C where A.Id = @ArtId and A.IdMarca = M.Id and C.Id = A.Id;");

            datos.setearParametro("@ArtId", articuloID);

            datos.ejecutarLectura();

            Articulo articulo = new Articulo();

            if (datos.Lector.Read())
            {
                articulo.Id = (int)datos.Lector["Id"];
                articulo.Codigo = (string)datos.Lector["Codigo"];
                articulo.Nombre = (string)datos.Lector["Nombre"];
                articulo.Precio = (decimal)datos.Lector["Precio"];
                articulo.Descripcion = (string)datos.Lector["Descripcion"];

                //Agrego la categoria
                articulo.Categoria = new Categoria();
                articulo.Categoria.Id = (int)datos.Lector["CatID"];
                articulo.Categoria.Descripcion = (string)datos.Lector["categoriaDescripcion"];

                //Agrego la marca
                articulo.Marca = new Marca();
                articulo.Marca.Id = (int)datos.Lector["MarcaId"];
                articulo.Marca.Descripcion = (string)datos.Lector["NombreMarca"];

                //Agrego la imagen
                articulo.Imagenes = new List<Imagen>();
                Imagen img = new Imagen();

                img.Id = (int)datos.Lector["imgId"];
                img.ImagenUrl = (string)datos.Lector["ImagenUrl"];

                articulo.Imagenes.Add(img);
            }

            return articulo;
        }

        public int agregar(Articulo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            int idGenerado = 0;

            try
            {
                datos.setearConsulta("INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion, Precio, IdMarca, IdCategoria) " +
                             "VALUES (@Codigo, @Nombre, @Descripcion, @Precio, @IdMarca, @IdCategoria); " + "SELECT SCOPE_IDENTITY();");

                // Establecimiento de parámetros
                datos.setearParametro("@Codigo", nuevo.Codigo);
                datos.setearParametro("@Nombre", nuevo.Nombre);
                datos.setearParametro("@Descripcion", nuevo.Descripcion);
                datos.setearParametro("@Precio", nuevo.Precio);
                datos.setearParametro("@IdMarca", nuevo.Marca.Id);
                datos.setearParametro("@IdCategoria", nuevo.Categoria.Id);


                idGenerado = Convert.ToInt32(datos.ejecutarAccion());

                

                //datos.setearParametro("@ImagenUrl", nuevo.Imagenes.Count > 0 ? nuevo.Imagenes[0].ImagenUrl : (object)DBNull.Value);
                return idGenerado;

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

        public void modificar(Articulo articulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update ARTICULOS  set Codigo = @Codigo, Nombre = @nombre, Descripcion = @desc, IdCategoria = @IdCategoria, IdMarca = @IdMarca Where Id = @id");
                datos.setearParametro("@Codigo", articulo.Codigo);
                datos.setearParametro("@nombre", articulo.Nombre);
                datos.setearParametro("@desc", articulo.Descripcion);
                datos.setearParametro("@IdCategoria", articulo.Categoria.Id);
                datos.setearParametro("@IdMarca", articulo.Marca.Id);
                datos.setearParametro("@id", articulo.Id);

                datos.ejecutarAccion();
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

        public void eliminar(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("delete from ARTICULOS where id = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void eliminarLogico(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("update ARTICULOS set Activo = 0 Where id = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    
        
}
