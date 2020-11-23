using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Clases_Instanciables;

namespace Bases_de_Datos
{
    public static class ConexionBD<T> where T : Periferico
    {
        #region Atributos

        static SqlConnection conexionDB;

        #endregion

        #region Constructor

        static ConexionBD()
        {
            conexionDB = new SqlConnection(Properties.Settings.Default.conexionDB);
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Permite conectarse a la base de datos, y a traves del comando SELECT, traer todos los registros de la misma
        /// acumulandolos en una lista.
        /// </summary>
        /// <returns>Retorna la lista con los datos cargados. En caso de haber algun error, retornara null</returns>
        public static List<Periferico> GetProductos()
        {
            List<Periferico> auxList = new List<Periferico>();

            try
            {
                SqlCommand comando = new SqlCommand();

                comando.Connection = conexionDB;
                comando.CommandType = CommandType.Text;
                comando.CommandText = "SELECT * FROM productos";

                if (conexionDB.State != ConnectionState.Open)
                {
                    conexionDB.Open();
                }

                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    auxList.Add(new Periferico(Periferico.MapeoTipoMarca(reader["Marca"].ToString()), float.Parse(reader["Precio"].ToString()),
                                               reader["Nombre"].ToString()));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                conexionDB.Close();
            }

            return auxList;

        }

        /// <summary>
        /// Me permite insertar un producto en la base de datos (este mismo lo recibe como parametro)
        /// </summary>
        /// <param name="auxProd">producto que se agregara en la base de datos</param>
        public static void InsertProducto(T auxProd)
        {

            try
            {
                SqlCommand comando = new SqlCommand();

                comando.Connection = conexionDB;
                comando.CommandType = CommandType.Text;
                comando.CommandText = "INSERT INTO [dbo].[productos] VALUES (@tipo, @nombre, @marca, @precio)";

                comando.Parameters.Add(new SqlParameter("@tipo", auxProd.GetType().Name));
                comando.Parameters.Add(new SqlParameter("@nombre", auxProd.Nombre));
                comando.Parameters.Add(new SqlParameter("@marca", auxProd.MarcaProducto));
                comando.Parameters.Add(new SqlParameter("@precio", auxProd.Precio));

                if (conexionDB.State != ConnectionState.Open)
                {
                    conexionDB.Open();
                }

                comando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conexionDB.Close();
            }

        }

        #endregion

    }
}
