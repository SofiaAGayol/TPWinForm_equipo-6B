using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
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
    }
        
}
