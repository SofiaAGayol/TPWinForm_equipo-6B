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
                comando.CommandText = "select Id, Codigo, Nombre from ARTICULOS";
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Articulo articulo = new Articulo();
                    articulo.Id = (int)lector["Id"];
                    articulo.Codigo = (string)lector["Codigo"];
                    articulo.Nombre = (string)lector["Nombre"];

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
