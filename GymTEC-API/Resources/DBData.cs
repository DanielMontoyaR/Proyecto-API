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
                string query = string.Format("SELECT * FROM Branch WHERE branch_name= '{0}'", nombreBranch);
                SqlCommand cmd = new SqlCommand(query, connection);
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
                string query = string.Format("INSERT INTO Branch(province,district,canton,branch_name,max_capacity,openDate,branch_schedule)" +
                                                "VALUES ('{0}', '{1}', '{2}', '{3}', {4}, '{5}', '{6}')", json.Province, json.District, json.Canton, json.Name, json.max_Size, json.opening_Date, json.schedule_Attention);
                Console.WriteLine(query);
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.CommandType = System.Data.CommandType.Text;
                
                

                int i = cmd.ExecuteNonQuery();
                
                return (i > 0) ? true: false;

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

        public static bool ExecuteDeleteBranch(Branch_IDENT json)
        {
            SqlConnection connection = new SqlConnection(cadenaConexion);


            try
            {
                connection.Open();
                string query = string.Format("DELETE FROM Branch " +
                                                "WHERE branch_name = '{0}'", json.Name);

                Console.WriteLine(query);
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.CommandType = System.Data.CommandType.Text;



                int i = cmd.ExecuteNonQuery();

                return (i > 0) ? true : false;

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

        public static bool ExecuteModBranch(Branch json)
        {
            SqlConnection connection = new SqlConnection(cadenaConexion);


            try
            {
                connection.Open();
                //llamada al stored procedure 
                string query = string.Format("UPDATE Branch " +
                    "SET province = '{0}', district = '{1}', canton = '{2}', branch_name = '{3}', max_capacity = {4}, openDate = '{5}', branch_schedule = '{6}' " +
                                              "WHERE branch_name = '{3}'", json.Province, json.District, json.Canton, json.Name, json.max_Size, json.opening_Date, json.schedule_Attention);
                Console.WriteLine(query);
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.CommandType = System.Data.CommandType.Text;



                int i = cmd.ExecuteNonQuery();

                return (i > 0) ? true : false;

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

        //******************Gear**********************
        public static DataTable GetAllGears()
        {
            SqlConnection connection = new SqlConnection(cadenaConexion);

            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT name FROM Gear_avalible", connection); 
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
        public static DataTable GetGear(int idGear)
        {
            SqlConnection connection = new SqlConnection(cadenaConexion);

            try
            {
                connection.Open();
                string query = string.Format("SELECT Gear_avalible.gear_id, Gear_avalible.description, Gear_avalible.name, Gear_type.gear_type "
                    + "FROM Gear_type "
                    + "FULL OUTER JOIN Gear_avalible "
                    + "ON Gear_avalible.gear_id = Gear_type.gear_id "
                    + "WHERE Gear_avalible.gear_id = {0}", idGear);
                SqlCommand cmd = new SqlCommand(query, connection);
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

        public static bool ExecuteAddGear(GearAvailable json)
        {
            SqlConnection connection = new SqlConnection(cadenaConexion);


            try
            {
                connection.Open();
                //llamada al stored procedure 
                string query = string.Format("INSERT INTO Gear_avalible(gear_id, description, name)" +
                                                "VALUES ({0}, '{1}', '{2}')", json.gear_ID, json.Description, json.Name);
                Console.WriteLine(query);
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.CommandType = System.Data.CommandType.Text;



                int i = cmd.ExecuteNonQuery();

                return (i > 0) ? true : false;

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

        public static bool ExecuteAddGearType(GearType json) //ver el tipo
        {
            SqlConnection connection = new SqlConnection(cadenaConexion);


            try
            {
                connection.Open();
                //llamada al stored procedure 
                string query = string.Format("INSERT INTO Gear_type(gear_id, gear_type) " +
                                                 "VALUES ({0}, '{1}') ", json.gear_ID, json.Gear_Type);
                Console.WriteLine(query);
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.CommandType = System.Data.CommandType.Text;



                int i = cmd.ExecuteNonQuery();

                return (i > 0) ? true : false;

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
        public static bool ExecuteModGear(GearAvailable json)
        {
            SqlConnection connection = new SqlConnection(cadenaConexion);


            try
            {
                connection.Open();
                //llamada al stored procedure 
                string query = string.Format("UPDATE Gear_avalible " +
                    "SET gear_id = '{0}', description = '{1}', name = '{2}' " +
                                              "WHERE gear_id = {0} ", json.gear_ID, json.Description, json.Name);
                Console.WriteLine(query);
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.CommandType = System.Data.CommandType.Text;



                int i = cmd.ExecuteNonQuery();

                return (i > 0) ? true : false;

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

        public static bool ExecuteModGearType(GearType json)
        {
            SqlConnection connection = new SqlConnection(cadenaConexion);


            try
            {
                connection.Open();
                //llamada al stored procedure 
                string query = string.Format("UPDATE Gear_type " +
                    "SET gear_id = '{0}', gear_type = '{1}' " +
                                              "WHERE gear_id = {0} ", json.gear_ID, json.Gear_Type);
                Console.WriteLine(query);
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.CommandType = System.Data.CommandType.Text;



                int i = cmd.ExecuteNonQuery();

                return (i > 0) ? true : false;

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

        public static bool ExecuteDeleteGear(GearAvailable_IDENT json)
        {
            SqlConnection connection = new SqlConnection(cadenaConexion);


            try
            {
                connection.Open();
                string query = string.Format("DELETE FROM Gear_avalible " +
                                                "WHERE gear_id = '{0}'", json.gear_ID);

                Console.WriteLine(query);
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.CommandType = System.Data.CommandType.Text;



                int i = cmd.ExecuteNonQuery();

                return (i > 0) ? true : false;

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


    }
}
