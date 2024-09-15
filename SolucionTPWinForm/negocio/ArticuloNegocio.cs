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

                datos.setearConsulta("SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.IdMarca, A.Precio Precio, M.Descripcion AS NombreMarca, M.Id AS MarcaId, I.ImagenUrl AS imgURL, I.Id AS imgId, C.Descripcion AS CatNombre, C.Id AS CatID FROM ARTICULOS A, MARCAS M, IMAGENES I, CATEGORIAS C where A.IdMarca = M.Id and I.IdArticulo = A.Id and C.Id = A.Id;");


                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo articulo = new Articulo();
                    articulo.Id = (int)datos.Lector["Id"];
                    articulo.Codigo = (string)datos.Lector["Codigo"];
                    articulo.Nombre = (string)datos.Lector["Nombre"];
                    articulo.Precio = (decimal)datos.Lector["Precio"];
                    articulo.Descripcion = (string)datos.Lector["Descripcion"];

                    //Agrego la categoria
                    articulo.Categoria = new Categoria();
                    articulo.Categoria.Id = (int)datos.Lector["CatID"];
                    articulo.Categoria.Nombre = (string)datos.Lector["CatNombre"];

                    //Agrego la marca
                    articulo.Marca = new Marca();
                    articulo.Marca.Id = (int)datos.Lector["MarcaId"];
                    articulo.Marca.Nombre = (string)datos.Lector["NombreMarca"];

                    //Agrego la imagen
                    articulo.Imagenes = new List<Imagen>();
                    Imagen img = new Imagen();

                    img.Id = (int)datos.Lector["imgId"];
                    img.ImgURL = (string)datos.Lector["imgURL"];

                    articulo.Imagenes.Add(img);



                    lista.Add(articulo); 
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
