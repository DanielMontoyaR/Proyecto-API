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
        public static string cadenaConexion = "Data Source=DESKTOP-50TLTT3\\SQLEXPRESS;Initial Catalog=GymTec;User ID=Daniel;Password=123.";//This 
        //Metodo que llama a un stored procedure en SQL para insertar un nuevo branch


        public static DataTable GetAllBranches() { 
            SqlConnection connection = new SqlConnection(cadenaConexion);

            try { 
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT branch_name FROM Branch", connection);
                cmd.CommandType = System.Data.CommandType.Text;

                DataTable dataTable = new DataTable();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);

                sqlDataAdapter.Fill(dataTable);
                return dataTable;

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;

            }

            finally { connection.Close(); }

        }

        public static DataTable GetBranch(String nombreBranch)
        {
            SqlConnection connection = new SqlConnection(cadenaConexion);

            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Branch WHERE branch_name=" + nombreBranch, connection);
                cmd.CommandType = System.Data.CommandType.Text;

                DataTable dataTable = new DataTable();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);

                sqlDataAdapter.Fill(dataTable);
                return dataTable;

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;

            }

            finally { connection.Close(); }

        }



        public static bool ExecuteAddBranch(Branch json)
        {
            SqlConnection connection = new SqlConnection(cadenaConexion);


            try
            {
                connection.Open();
                //llamada al stored procedure 
                SqlCommand cmd = new SqlCommand("INSERT INTO Branch(province,district,canton,branch_name,max_capacity,openDate,branch_schedule)" +
                                                "VALUES (@province, @district, @canton, @branch_name, @max_capacity, @openDate, @branch_schedule)", connection);
                cmd.CommandType = System.Data.CommandType.Text;
                //Parametros que recibe el stored procedure
                cmd.Parameters.AddWithValue("@province", SqlDbType.NVarChar).Value = json.Province;
                cmd.Parameters.AddWithValue("@district", SqlDbType.NVarChar).Value = json.District;
                cmd.Parameters.AddWithValue("@canton", SqlDbType.NVarChar).Value = json.Canton;
                cmd.Parameters.AddWithValue("@branch_name", SqlDbType.NVarChar).Value = json.Name;
                cmd.Parameters.AddWithValue("@max_capacity", SqlDbType.Int).Value = json.max_Size;
                cmd.Parameters.AddWithValue("@openDate", SqlDbType.NVarChar).Value = json.opening_Date;
                cmd.Parameters.AddWithValue("@branch_schedule", SqlDbType.NVarChar).Value = json.schedule_Attention;
                

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
                connection.Close();
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
