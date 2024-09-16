using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace negocio
{
    public class AccesoDatos
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;

        public SqlDataReader Lector
        {
            get { return lector; }
        }

        public AccesoDatos()
        {
            conexion = new SqlConnection("server=DESKTOP-IKVVGTT; database=CATALOGO_P3_DB; integrated security=true");
            comando = new SqlCommand();
        }

        public void setearConsulta(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }

        public void ejecutarLectura()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public object ejecutarAccion()
        {
            comando.Connection = conexion;

            try
            {
                conexion.Open();
                return comando.ExecuteScalar(); // Devuelve el valor de SCOPE_IDENTITY()
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close(); // Asegurarse de cerrar la conexión
            }
        }

        public void setearParametro(string nombre, object valor)
        {
            comando.Parameters.AddWithValue(nombre, valor);
        }

        public void cerrarConexion()
        {
            if (lector != null)
                lector.Close();
            conexion.Close();
        }

        //Devuelve el ID de Articulo
        public object devolverIDArticulo()
        {
            object resultado;
            using (SqlCommand comando = new SqlCommand("INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion, Precio, IdMarca, IdCategoria) " +
                             "VALUES (@Codigo, @Nombre, @Descripcion, @Precio, @IdMarca, @IdCategoria  )", conexion))
            {
                conexion.Open();
                resultado = comando.ExecuteScalar();
                conexion.Close();
            }

            return resultado;
        }
    }
}
