using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Reflection.Metadata;
using GymTEC_API.Resources;
using GymTEC_API.Entidades;

namespace GymTEC_API.Resources
{
    public class DBData
    {
        public static string cadenaConexion = "Data Source=LAPTOP-85GS8ERK;Initial Catalog=GymTec;Persist Security Info=True;User ID=maxgm;Password=123";//This 
        //Metodo que llama a un stored procedure en SQL para insertar un nuevo branch
        public static bool ExecuteAddBranch(Branch json)
        {
            SqlConnection conn = new SqlConnection(cadenaConexion);


            try
            {
                conn.Open();
                //llamada al stored procedure 
                SqlCommand cmd = new SqlCommand("ADD ", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                //Parametros que recibe el stored procedure
                cmd.Parameters.AddWithValue("@Province", SqlDbType.NVarChar).Value = json.Province;
                cmd.Parameters.AddWithValue("@District", SqlDbType.NVarChar).Value = json.District;
                cmd.Parameters.AddWithValue("@Canton", SqlDbType.NVarChar).Value = json.Canton;
                cmd.Parameters.AddWithValue("@max_Size", SqlDbType.NVarChar).Value = json.max_Size;
                cmd.Parameters.AddWithValue("@opening_Date", SqlDbType.NVarChar).Value = json.opening_Date;
                cmd.Parameters.AddWithValue("@schedule_Attention", SqlDbType.NVarChar).Value = json.schedule_Attention;
                cmd.Parameters.AddWithValue("@Name", SqlDbType.NVarChar).Value = json.Name;
                int i = cmd.ExecuteNonQuery();
                //ExecuteAddPatientPhone(json);

                /**
                foreach (string phone in json.telefono)
                {
                    ExecuteAddPatientPhone(cedula, phone);
                }
                **/
                /**
                foreach(Direccion direccion in json.direccion)
                {
                    ExecuteAddPatientAddress(cedula,direccion.provincia, direccion.canton, direccion.distrito);
                }
                **/
                return (i > 0) ? false : true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

            public static DataSet ListarTablas(string nombreProcedimiento, List<Parameter> parameters = null)
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);

            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SELECT Name FROM Branch", conexion);
                cmd.CommandType = System.Data.CommandType.Text;

                if (parameters != null)
                {
                    foreach (var parameter in parameters)
                    {
                        cmd.Parameters.AddWithValue(parameter.Name, parameter.Value);
                    }
                }
                DataSet tabla = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(tabla);


                return tabla;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                conexion.Close();
            }
        }

        public static DataTable Listar(string nombreProcedimiento, List<Parameter> parameters = null)
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);

            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand(nombreProcedimiento, conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                if (parameters != null)
                {
                    foreach (var parameter in parameters)
                    {
                        cmd.Parameters.AddWithValue(parameter.Name, parameter.Value);
                    }
                }
                DataTable tabla = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(tabla);


                return tabla;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                conexion.Close();
            }
        }

        public static bool Ejecutar(string nombreProcedimiento, List<Parameter> parameters = null)
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);

            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand(nombreProcedimiento, conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                if (parameters != null)
                {
                    foreach (var parameter in parameters)
                    {
                        cmd.Parameters.AddWithValue(parameter.Name, parameter.Value);
                    }
                }

                int i = cmd.ExecuteNonQuery();

                return (i > 0) ? true : false;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                conexion.Close();
            }
        }
    }
}
