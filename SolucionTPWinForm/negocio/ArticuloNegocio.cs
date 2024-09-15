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
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {

                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=CATALOGO_P3_DB; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "Select A.Id, Codigo, Nombre, A.Descripcion, A.IdMarca, A.IdCategoria,Precio,C.Id as IdC, C.Descripcion as DescripcionC, M.Id as IdM, M.Descripcion as DescripcionM,I.Id as IdIm, I.IdArticulo, I.ImagenUrl From ARTICULOS A, CATEGORIAS C, MARCAS M, IMAGENES I Where C.Id = A.IdCategoria And M.Id = A.IdMarca And I.IdArticulo = A.Id";
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Articulo articulo = new Articulo();
                    articulo.Id = (int)lector["Id"];
                    articulo.Codigo = (string)lector["Codigo"];
                    articulo.Nombre = (string)lector["Nombre"];
                    articulo.Descripcion = (string)lector["Descripcion"];
                    articulo.Precio = (decimal)lector["Precio"];

                    articulo.Marca = new Marca();
                    articulo.Marca.Id = (int)lector["IdM"];
                    articulo.Marca.Descripcion = (string)lector["DescripcionM"];
                    
                    articulo.Categoria = new Categoria();
                    articulo.Categoria.Id = (int)lector["IdC"];
                    articulo.Categoria.Descripcion = (string)lector["DescripcionC"];

                    if (!(lector["IdIm"] is DBNull))
                    {
                        Imagenes imagen = new Imagenes();
                        imagen.Id = (int)lector["IdIm"];
                        imagen.IdArticulo = (int)lector["IdArticulo"];
                        imagen.ImagenUrl = (string)lector["ImagenUrl"];
                        
                        articulo.Imagenes.Add(imagen);
                    }
                       

                    lista.Add(articulo); 
                }

                conexion.Close();
                return lista;
       
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
        
}
