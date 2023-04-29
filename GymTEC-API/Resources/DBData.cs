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



        //Start Branch Functions
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

        //End Branch Functions






        //Start Services Functions
        public static DataTable GetAllServices()
        {
            SqlConnection connection = new SqlConnection(cadenaConexion);

            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Service", connection);
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


        public static bool ExecuteAddService(Service json)
        {
            SqlConnection connection = new SqlConnection(cadenaConexion);


            try
            {
                connection.Open();
                //llamada al stored procedure 
                string query = string.Format("INSERT INTO Service(service_id,service_description)" +
                                                "VALUES ('{0}', '{1}')", json.ID_Service, json.Description);
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

        public static bool ExecuteDeleteService(Service_IDENT json)
        {
            SqlConnection connection = new SqlConnection(cadenaConexion);


            try
            {
                connection.Open();

                string query = string.Format("DELETE FROM Client_lesson\r\n" +
                                            "WHERE lesson_id = {0}\r\n\r\n " +
                                            "DELETE FROM Lesson\r\n " +
                                            "WHERE lesson_id = {0}\r\n\r\n " +
                                            "DELETE FROM Service\r\n " +
                                            "WHERE service_id = '{1}'", Convert.ToInt32(json.ID_Service),json.ID_Service);

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

        public static bool ExecuteModService(Service json)
        {
            SqlConnection connection = new SqlConnection(cadenaConexion);


            try
            {
                connection.Open();
                //llamada al stored procedure 
                string query = string.Format("UPDATE Service " +
                                             "SET service_description = '{1}'" +
                                             "WHERE service_id = '{0}';", json.ID_Service, json.Description);
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


        //End Services Functions


        //Start Payroll Functions

        public static DataTable GetAllPayrolls()
        {
            SqlConnection connection = new SqlConnection(cadenaConexion);

            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Form", connection);
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


        public static bool ExecuteAddPayroll(Payroll json)
        {
            SqlConnection connection = new SqlConnection(cadenaConexion);


            try
            {
                connection.Open();
                //llamada al stored procedure 
                string query = string.Format("INSERT INTO Form(id,typepayment,description)" +
                                                "VALUES ('{0}', '{1}', '{2}')", json.ID_Payroll, json.Payroll_Type, json.Description);
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
        public static bool ExecuteModPayroll(Payroll json)
        {
            SqlConnection connection = new SqlConnection(cadenaConexion);


            try
            {
                connection.Open();
                //llamada al stored procedure 
                string query = string.Format("UPDATE Form " +
                                             "SET typepayment = '{1}', description = '{2}' " +
                                             "WHERE id = '{0}';", json.ID_Payroll, json.Payroll_Type, json.Description);
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


        //End Payroll Functions

        //Start Employee Functions
        public static DataTable GetAllEmployees()
        {
            SqlConnection connection = new SqlConnection(cadenaConexion);

            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT Fname, FLname, id FROM Employee", connection);
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

        public static DataTable GetEmployee(String Employee_ID)
        {
            SqlConnection connection = new SqlConnection(cadenaConexion);

            try
            {
                connection.Open();
                string query = string.Format("SELECT * FROM Employee WHERE id = '{0}'", Employee_ID);
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

        public static bool ExecuteAddEmployee(Employee json)
        {
            SqlConnection connection = new SqlConnection(cadenaConexion);


            try
            {
                connection.Open();
                //llamada al stored procedure 
                string query = string.Format("INSERT INTO Employee(province,district,canton,email,password,id,Fname,Sname,FLname,SLname,Workstaion_id,form_id,branch_name)" +
                                                "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}')", 
                                                json.Employee_Province, json.Employee_District, json.Employee_Canton,json.Employee_Email,json.Employee_Password,json.Employee_ID,
                                                json.Employee_Fname,json.Employee_Mname,json.Employee_LName1,json.Employee_LName2, json.Employee_Workstation_id,json.Employee_payroll_id,json.Branch_Name);
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

        public static bool ExecuteDeleteEmployee(Employee_IDENT json)
        {
            SqlConnection connection = new SqlConnection(cadenaConexion);


            try
            {
                connection.Open();

                string query = string.Format("DELETE FROM Employee" +
                                             "WHERE id='{0}'",json.Employee_ID);

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

        public static bool ExecuteModEmployee(Employee json)
        {
            SqlConnection connection = new SqlConnection(cadenaConexion);


            try
            {
                connection.Open();
                //llamada al stored procedure 
                string query = string.Format("UPDATE Employee " +
                                             "SET province = '{0}' ,district = '{1}',canton = '{2}',email = '{3}',password='{4}' ,id = '{5}', Fname = '{6}', Sname = '{7}',FLname = '{8}',SLname='{9}' ,Workstaion_id = '{10}' ,form_id ='{11}' ,branch_name = '{12}')",
                                                json.Employee_Province, json.Employee_District, json.Employee_Canton, json.Employee_Email, json.Employee_Password, json.Employee_ID,
                                                json.Employee_Fname, json.Employee_Mname, json.Employee_LName1, json.Employee_LName2, json.Employee_Workstation_id, json.Employee_payroll_id, json.Branch_Name);
                Console.WriteLine(query);
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.CommandType = System.Data.CommandType.Text;

                /*
                 *("INSERT INTO Employee(province,district,canton,email,password,id,Fname,Sname,FLname,SLname,Workstaion_id,form_id,branch_name)" +
                                                "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}')", 
                                                json.Employee_Province, json.Employee_District, json.Employee_Canton,json.Employee_Email,json.Employee_Password,json.Employee_ID,
                                                json.Employee_Fname,json.Employee_Mname,json.Employee_LName1,json.Employee_LName2, json.Employee_Workstation_id,json.Employee_payroll_id,json.Branch_Name); 
                 */

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



        //End Employee Functions

        //Start Product Functions
        public static DataTable GetAllProducts()
        {
            SqlConnection connection = new SqlConnection(cadenaConexion);

            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Product", connection);
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

        public static DataTable GetProduct(String Barcode)
        {
            SqlConnection connection = new SqlConnection(cadenaConexion);

            try
            {
                connection.Open();
                string query = string.Format("SELECT * FROM Product WHERE barcode = '{0}'", Barcode);
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

        public static bool ExecuteAddProduct(Product json)
        {
            SqlConnection connection = new SqlConnection(cadenaConexion);


            try
            {
                connection.Open();
                //llamada al stored procedure 
                string query = string.Format("INSERT INTO Product(barcode,name,description,price,branch_name)" +
                                                "VALUES ('{0}', '{1}', '{2}', {3}, '{4}')",
                                                json.Barcode, json.Name, json.Description, json.price, json.branch_Name);
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

        public static bool ExecuteDeleteProduct(Product_IDENT json)
        {
            SqlConnection connection = new SqlConnection(cadenaConexion);


            try
            {
                connection.Open();

                string query = string.Format("DELETE FROM Product " +
                                             "WHERE barcode='{0}'", json.Barcode);

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

        public static bool ExecuteModProduct(Product json)
        {
            SqlConnection connection = new SqlConnection(cadenaConexion);


            try
            {
                connection.Open();
                //llamada al stored procedure 
                string query = string.Format("UPDATE Product " +
                                             "SET name = '{1}',description = '{2}',price = {3},branch_name='{4}'" +
                                             "WHERE barcode = '{0}'", json.Barcode, json.Name, json.Description, json.price, json.branch_Name);
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


        //End Product Functions



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
