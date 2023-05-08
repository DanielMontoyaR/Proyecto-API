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

        /// <summary>
        /// Method that queries the database to retrieve the id and password of the employee entity.
        /// </summary>
        /// <param name="Employee_ID">The if of the employee from which to retrieve their specified info.</param>
        /// <returns>A DataTable containing all specified information.</returns>
        public static DataTable EmployeeLogin(Credentials Employee_ID)
        {
            SqlConnection connection = new SqlConnection(cadenaConexion);

            try
            {
                connection.Open();
                string query = string.Format("SELECT id, password FROM Employee WHERE id = '{0}' AND password = '{1}'", Employee_ID.ID_Credentials, Employee_ID.Password);
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



        /// <summary>
        /// Method that queries the database to retrieve the id and password of the client entity.
        /// </summary>
        /// <param name="client_credentials">The if of the employee from which to retrieve their specified info.</param>
        /// <returns>A DataTable containing all specified information.</returns>
        public static DataTable ClientLogin(Credentials client_credentials)
        {
            SqlConnection connection = new SqlConnection(cadenaConexion);

            try
            {
                connection.Open();
                string query = string.Format("SELECT client_id, password FROM Client WHERE client_id = '{0}' AND password = '{1}'", client_credentials.ID_Credentials, client_credentials.Password);
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

        //Start Branch Functions

        /// <summary>
        /// Method that queries a database to get all branch names.
        /// </summary>
        /// <returns>A DataTable containing all specified information.</returns>
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

        /// <summary>
        /// Method that queries a database to get all the information of a specific branch.
        /// </summary>
        /// <param name="nombreBranch">The branch name that refers to the query.</param>
        /// <returns>A database with all specified branch information.</returns>
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


        /// <summary>
        /// Method that queries a database to insert the information of a new branch.
        /// </summary>
        /// <param name="json">The branch information to insert.</param>
        /// <returns>A boolean value indicating whether the insert was successful.</returns>
        public static bool ExecuteAddBranch(Branch json)
        {
            SqlConnection connection = new SqlConnection(cadenaConexion);


            try
            {
                connection.Open();
                //llamada al stored procedure 
                string query = string.Format("INSERT INTO Branch(province,district,canton,branch_name,max_capacity,openDate,branch_schedule)" +
                                             "VALUES ('{0}', '{1}', '{2}', '{3}', {4}, '{5}', '{6}') " +
                                             "INSERT INTO Spa(branch_name, status) " +
                                             "VALUES ('{3}', '0')" +
                                             "INSERT INTO Shop(branch_name, status) " +
                                             "VALUES ('{3}', '0')", json.Province, json.District, json.Canton, json.Name, json.max_Size, json.opening_Date, json.schedule_Attention);
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

        /// <summary>
        /// Method that queries a database to delete a branch given their specified identifier.
        /// </summary>
        /// <param name="json">The identifier of the branch to delete.</param>
        /// <returns>A boolean value indicating whether the delete was successful.</returns>
        public static bool ExecuteDeleteBranch(Branch_IDENT json)
        {
            SqlConnection connection = new SqlConnection(cadenaConexion);


            try
            {
                connection.Open();
                string query = string.Format("DELETE FROM Spa " +
                                             "WHERE branch_name = '{0}' " +
                                             "DELETE FROM Shop " +
                                             "WHERE branch_name = '{0}' " +
                                             "DELETE FROM Branch " +
                                             "WHERE branch_name = '{0}' ", json.Name);

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

        /// <summary>
        /// Method that that queries a database to modify a branch given their information.
        /// </summary>
        /// <param name="json">The information of the branch to modify.</param>
        /// <returns>A boolean value indicating whether the modfication was successful.</returns>
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

        /// <summary>
        /// Method that queries a database to get all information from Services.
        /// </summary>
        /// <returns>A DataTable containing all specified information.</returns>
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

        /// <summary>
        /// Method that queries a database to insert the information of a new service.
        /// </summary>
        /// <param name="json">The service information to insert.</param>
        /// <returns>A boolean value indicating whether the insert was successful </returns>
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

        /// <summary>
        /// Method that queries a database to delete a service given their specified identifier.
        /// </summary>
        /// <param name="json">The identifier of the service to delete.</param>
        /// <returns>A boolean value indicating whether the delete was successful.</returns>
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

        /// <summary>
        /// Method that that queries a database to modify a service given their information.
        /// </summary>
        /// <param name="json">The information of the service to modify.</param>
        /// <returns>A boolean value indicating whether the modfication was successful.</returns>
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

        /// <summary>
        /// Method that queries a database to get all payroll information.
        /// </summary>
        /// <returns>A DataTable containing all specified information.</returns>
        public static DataTable GetAllPayrolls()
        {
            SqlConnection connection = new SqlConnection(cadenaConexion);

            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT Form.form_id , Form.typepayment, Form.description, Employee.id  " +
                                                "FROM Form " +
                                                "INNER JOIN Employee ON Employee.form_id = Form.form_id ", connection);
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

        /// <summary>
        /// Method that queries a database to get all the information of a specific employee.
        /// </summary>
        /// <param name="Employee_ID">The employee identifier that refers to the query.</param>
        /// <returns>A database with all specified information.</returns>
        public static DataTable GetPayroll(String Employee_ID)
        {
            SqlConnection connection = new SqlConnection(cadenaConexion);

            try
            {
                connection.Open();
                string query = string.Format("SELECT Form.form_id , Form.typepayment, Form.description\r\n " +
                    "FROM Form\r\n " +
                    "INNER JOIN Employee ON Employee.form_id = Form.form_id \r\n " +
                    "WHERE Employee.id = {0}", Employee_ID);
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




        /// <summary>
        /// Method that that queries a database to modify a payroll given their information.
        /// </summary>
        /// <param name="json">The information of the payroll to modify.</param>
        /// <returns>A boolean value indicating whether the modfication was successful.</returns>
        public static bool ExecuteModPayroll(EmployeePAYROLL json)
        {
            SqlConnection connection = new SqlConnection(cadenaConexion);


            try
            {
                connection.Open();
                //llamada al stored procedure 
                string query = string.Format("UPDATE Employee " +
                                             "SET form_id = '{1}' " +
                                             "WHERE id = '{0}';", json.Employee_ID, json.Employee_Payroll_id);

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

        /// <summary>
        /// Method that queries a database to get all Employee's first name, first last name and id.
        /// </summary>
        /// <returns>A DataTable containing all specified information.</returns>
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

        /// <summary>
        /// Method that queries a database to get all the information of a specific employee.
        /// </summary>
        /// <param name="Employee_ID">The employee identifier that refers to the query.</param>
        /// <returns>A database with all specified information.</returns>
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

        /// <summary>
        /// Method that queries a database to insert the information of a new employee.
        /// </summary>
        /// <param name="json">The employee information to insert.</param>
        /// <returns>A boolean value indicating whether the insert was successful.</returns>
        public static bool ExecuteAddEmployee(Employee json)
        {
            SqlConnection connection = new SqlConnection(cadenaConexion);


            try
            {
                connection.Open();
                //llamada al stored procedure 
                string query = string.Format("INSERT INTO Employee(province,district,canton,email,password,id,Fname,Sname,FLname,SLname,Workstaion_id,form_id,branch_name)" +
                                                " VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}')", 
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

        /// <summary>
        /// Method that queries a database to delete an employee given their specified identifier.
        /// </summary>
        /// <param name="json">The identifier of the employee to delete.</param>
        /// <returns>A boolean value indicating whether the delete was successful.</returns>
        public static bool ExecuteDeleteEmployee(Employee_IDENT json)
        {
            SqlConnection connection = new SqlConnection(cadenaConexion);


            try
            {
                connection.Open();

                string query = string.Format("DELETE FROM Employee " +
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

        /// <summary>
        /// Method that that queries a database to modify an employee given their information.
        /// </summary>
        /// <param name="json">The information of the employee to modify.</param>
        /// <returns>A boolean value indicating whether the modfication was successful.</returns>
        public static bool ExecuteModEmployee(Employee json)
        {
            SqlConnection connection = new SqlConnection(cadenaConexion);


            try
            {
                connection.Open();
                //llamada al stored procedure 
                string query = string.Format("UPDATE Employee " +
                                             "SET province = '{0}' ,district = '{1}',canton = '{2}',email = '{3}',password='{4}', Fname = '{6}', Sname = '{7}',FLname = '{8}',SLname='{9}' ,Workstaion_id = '{10}' ,form_id ='{11}' ,branch_name = '{12}' " +
                                             "WHERE id = '{5}' ",
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

        /// <summary>
        /// Method that queries a database to get all product's information.
        /// </summary>
        /// <returns>A DataTable containing all specified information.</returns>
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

        /// <summary>
        /// Method that queries a database to get all the information of a specific product.
        /// </summary>
        /// <param name="Barcode">The product identifier that refers to the query.</param>
        /// <returns>A database with all specified information.</returns>
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

        /// <summary>
        /// Method that queries a database to insert the information of a new product.
        /// </summary>
        /// <param name="json">The product information to insert.</param>
        /// <returns>A boolean value indicating whether the insert was successful.</returns>
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
        /// <summary>
        /// Method that queries a database to delete a product given their specified identifier.
        /// </summary>
        /// <param name="json">The identifier of the product to delete.</param>
        /// <returns>A boolean value indicating whether the delete was successful.</returns>
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

        /// <summary>
        /// Method that that queries a database to modify a product given their information.
        /// </summary>
        /// <param name="json">The information of the product to modify.</param>
        /// <returns>A boolean value indicating whether the modfication was successful.</returns>
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


        //Start Client Functions

        /// <summary>
        /// Method that queries a database to insert the information of a new client.
        /// </summary>
        /// <param name="json">The client information to insert.</param>
        /// <returns>A boolean value indicating whether the insert was successful.</returns>
        public static bool ExecuteAddClient(Client json) {

            SqlConnection connection = new SqlConnection(cadenaConexion);

            try
            {
                connection.Open();
                //llamada al stored procedure 
                string query = string.Format("INSERT INTO Client(client_id,address,weight,IMC,Fname,Sname,FLname,SLname,password,bdate,email)" +
                                                "VALUES ('{0}', '{1}', {2}, {3}, '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}')",
                                                json.ID_Client, json.Address, json.Weight, json.BMI, json.FName1,json.FName2, json.Last_name1,json.Last_name2,json.Password,json.Birth_Date,json.Email);
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

        /// <summary>
        /// Method that queries a database to get Client's First name, first last name and id.
        /// </summary>
        /// <returns>A DataTable containing all specified information.</returns>
        public static DataTable GetAllClients()
        {
            SqlConnection connection = new SqlConnection(cadenaConexion);

            try
            {//Nombre apellido id email
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT Fname,FLname,client_id FROM Client", connection);
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

        /// <summary>
        /// Method that queries a database to get all the information of a specific client.
        /// </summary>
        /// <param name="id_client">The client identifier that refers to the query.</param>
        /// <returns>A database with all specified information.</returns>
        public static DataTable GetClient(String id_client)
        {
            SqlConnection connection = new SqlConnection(cadenaConexion);

            try
            {
                connection.Open();
                string query = string.Format("SELECT * FROM Client WHERE client_id= '{0}'", id_client);
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

        /// <summary>
        /// Method that queries a database to delete a client given their specified identifier.
        /// </summary>
        /// <param name="json">The identifier of the client to delete.</param>
        /// <returns>A boolean value indicating whether the delete was successful.</returns>
        public static bool ExecuteDeleteClient(Client_IDENT json)
        {
            SqlConnection connection = new SqlConnection(cadenaConexion);


            try
            {
                connection.Open();

                string query = string.Format("DELETE FROM Client " +
                                             "WHERE client_id='{0}'", json.ID_Client);

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

        /// <summary>
        /// Method that that queries a database to modify a client given their information.
        /// </summary>
        /// <param name="json">The information of the client to modify.</param>
        /// <returns>A boolean value indicating whether the modfication was successful.</returns>
        public static bool ExecuteModClient(Client json)
        {
            SqlConnection connection = new SqlConnection(cadenaConexion);


            try
            {
                connection.Open();
                //llamada al stored procedure 
                string query = string.Format("UPDATE Client " +
                                             "SET address = '{1}',weight = {2},IMC = {3},Fname='{4}',Sname='{5}',FLname = '{6}',SLname='{7}',password='{8}',bdate='{9}' " +
                                             "WHERE client_id = '{0}'", json.ID_Client, json.Address, json.Weight, json.BMI, json.FName1,json.FName2,json.Last_name1,json.Last_name2,json.Password,json.Birth_Date);
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

        //End Client Functions



        //******************Gear**********************

        /// <summary>
        /// Method that queries a database to get all Gear's name and type.
        /// </summary>
        /// <returns>A DataTable containing all specified information.</returns>
        public static DataTable GetAllGears()
        {
            SqlConnection connection = new SqlConnection(cadenaConexion);

            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT Gear_avalible.name, Gear_type.gear_type, Gear_avalible.gear_id \r\n" +
                    "FROM Gear_avalible\r\n" +
                    "INNER JOIN Gear_type ON Gear_type.gear_id = Gear_avalible.gear_id ", connection);
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

        /// <summary>
        /// Method that queries a database to get all the information of a specific gear.
        /// </summary>
        /// <param name="idGear">The gear identifier that refers to the query.</param>
        /// <returns>A database with all specified information.</returns>
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

        /// <summary>
        /// Method that queries a database to insert the information of a new gear.
        /// </summary>
        /// <param name="json">The gear information to insert.</param>
        /// <returns>A boolean value indicating whether the insert was successful.</returns>
        public static bool ExecuteAddGear(GearOBT json)
        {
            SqlConnection connection = new SqlConnection(cadenaConexion);


            try
            {
                connection.Open();
                //llamada al stored procedure 
                string query = string.Format("INSERT INTO Gear_avalible(gear_id, description, name)" +
                                                "VALUES ({0}, '{1}', '{2}') " +
                                                "INSERT INTO Gear_type(gear_id,gear_type) " +
                                                "VALUES ({3}, '{4}') ", json.gear_ID, json.Description, json.Name, json.gear_ID, json.Gear_Type);
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

        /// <summary>
        /// Method that that queries a database to modify a gear given their information.
        /// </summary>
        /// <param name="json">The information of the gear to modify.</param>
        /// <returns>A boolean value indicating whether the modfication was successful.</returns>
        public static bool ExecuteModGear(GearOBT json)
        {
            SqlConnection connection = new SqlConnection(cadenaConexion);


            try
            {
                connection.Open();
                //llamada al stored procedure 
                string query = string.Format("UPDATE Gear_avalible " +
                    "SET gear_id = '{0}', description = '{1}', name = '{2}' " +
                                              "WHERE gear_id = {0} " +
                                              "UPDATE Gear_type " +
                    "SET gear_id = {3}, gear_type = '{4}' " +
                                              "WHERE gear_id = {0} ", json.gear_ID, json.Description, json.Name, json.gear_ID, json.Gear_Type);
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


        /// <summary>
        /// Method that queries a database to delete a gear given their specified identifier.
        /// </summary>
        /// <param name="json">The identifier of the gear to delete.</param>
        /// <returns>A boolean value indicating whether the delete was successful.</returns>
        public static bool ExecuteDeleteGear(GearAvailable_IDENT json)
        {
            SqlConnection connection = new SqlConnection(cadenaConexion);


            try
            {
                connection.Open();
                string query = string.Format("DELETE FROM Gear_avalible " +
                                                "WHERE gear_id = '{0}' " +
                                                "DELETE FROM Gear_type " +
                                                "WHERE gear_id = '{0}' ", json.gear_ID);

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

        //********Inventory***************

        //Get all inventories

        /// <summary>
        /// Method that queries a database to get all Inventory's brand, serial number, name and Gear's name and type.
        /// </summary>
        /// <returns>A DataTable containing all specified information.</returns>
        public static DataTable GetAllInventory()
        {
            SqlConnection connection = new SqlConnection(cadenaConexion);

            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT Inventory.brand, Inventory.serial_num, Gear_avalible.name, Gear_type.gear_type \r\n" +
                    "FROM Inventory\r\n" +
                    "INNER JOIN Gear_avalible ON Gear_avalible.gear_id = Inventory.gear_id \r\n" +
                    "INNER JOIN Gear_type ON gear_type.gear_id = Inventory.gear_id", connection);
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

        //Get inventory

        /// <summary>
        /// Method that queries a database to get all the information of a specific inventory.
        /// </summary>
        /// <param name="idInventory">The inventory identifier that refers to the query.</param>
        /// <returns>A database with all specified information.</returns>
        public static DataTable GetInventory(int idInventory) //continuar este
        {
            SqlConnection connection = new SqlConnection(cadenaConexion);

            try
            {
                connection.Open();
                string query = string.Format("SELECT Inventory.brand, Inventory.serial_num, Inventory.branch_name, Inventory.price, Inventory.gear_id, Gear_avalible.name, Gear_type.gear_type " +
                    "FROM Inventory " +
                    "INNER JOIN Gear_avalible ON Gear_avalible.gear_id = Inventory.gear_id " +
                    "INNER JOIN Gear_type ON gear_type.gear_id = Inventory.gear_id "
                    + "WHERE Inventory.serial_num = {0}", idInventory);
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


        //Add inventory

        /// <summary>
        /// Method that queries a database to insert the information of a new inventory.
        /// </summary>
        /// <param name="json">The inventory information to insert.</param>
        /// <returns>A boolean value indicating whether the insert was successful.</returns>
        public static bool ExecuteAddInventory(Inventory json)
        {
            SqlConnection connection = new SqlConnection(cadenaConexion);


            try
            {
                connection.Open();
                //llamada al stored procedure 
                string query = string.Format("INSERT INTO Inventory(brand,serial_num,price,gear_id, branch_name)  " +
                                                "VALUES ('{0}', {1}, '{2}', {3}, '{4}')", json.Brand, json.Serial_Number, json.Price, json.gear_ID, json.Branch_Name);
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

        /// <summary>
        /// Method that that queries a database to modify an inventory given their information.
        /// </summary>
        /// <param name="json">The information of the inventory to modify.</param>
        /// <returns>A boolean value indicating whether the modfication was successful.</returns>
        public static bool ExecuteModInventory(Inventory_ALL json)
        {
            SqlConnection connection = new SqlConnection(cadenaConexion);


            try
            {
                connection.Open();
                //llamada al stored procedure 
                string query = string.Format("UPDATE Inventory " +
                    "SET brand = '{0}', price = {1}, branch_name = '{2}' " +
                                              "WHERE serial_num = {3}", json.Brand, json.Price, json.Branch_Name, json.Serial_Number);
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

        /// <summary>
        /// Method that queries a database to delete an inventory given their specified identifier.
        /// </summary>
        /// <param name="json">The identifier of the inventory to delete.</param>
        /// <returns>A boolean value indicating whether the delete was successful.</returns>
        public static bool ExecuteDeleteInventory(Inventory_IDENT json)
        {
            SqlConnection connection = new SqlConnection(cadenaConexion);


            try
            {
                connection.Open();
                string query = string.Format("DELETE FROM Inventory " +
                                                "WHERE serial_num = '{0}' ", json.Serial_Number);

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
        //********************Clases***********************8
        //Add lesson

        /// <summary>
        /// Method that queries a database to insert the information of a new lesson.
        /// </summary>
        /// <param name="json">The lesson information to insert.</param>
        /// <returns>A boolean value indicating whether the insert was successful.</returns>
        public static bool ExecuteAddLesson(Lesson json)
        {
            SqlConnection connection = new SqlConnection(cadenaConexion);


            try
            {
                connection.Open();
                //llamada al stored procedure 
                string query = string.Format("INSERT INTO Lesson(lesson_id,quotas,search_begin,search_end, start_date,end_date,branch_name,instructor_id,service_id)   " +
                                                "VALUES ({0}, {1}, '{2}', '{3}', '{4}', '{5}', '{6}', {7}, {8})", json.ID_Lessons, json.Quotas, json.search_Date, json.search_End, json.Start_Date, json.search_End, json.Branch_Name, json.instructor_id, json.service_id);
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

        /// <summary>
        /// Method that queries a database to get all Lesson's id, name, instructor id, service id and quotas.
        /// </summary>
        /// <returns>A DataTable containing all specified information.</returns>
        public static DataTable GetAllClasses()
        {
            SqlConnection connection = new SqlConnection(cadenaConexion);

            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT lesson_id, branch_name, instructor_id, service_id, quotas FROM Lesson", connection);
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
        //Get class for admin

        /// <summary>
        /// Method that queries a database to get the id, quotas, start date, end date, branch name, instructor identifier, service identifier, service description and client id of a specific class.
        /// </summary>
        /// <param name="idLesson">The class identifier that refers to the query.</param>
        /// <returns>A database with all specified information.</returns>
        public static DataTable GetClass(int idLesson)
        {
            SqlConnection connection = new SqlConnection(cadenaConexion);

            try
            {
                connection.Open();
                string query = string.Format("SELECT Lesson.lesson_id, Lesson.quotas, Lesson.start_date, Lesson.end_date, Lesson.branch_name, Lesson.instructor_id, Lesson.service_id, Service.service_description, Client_lesson.client_id " +
                    "FROM Lesson " +
                    "INNER JOIN Service ON Service.service_id = Lesson.service_id " +
                    "INNER JOIN Client_lesson ON Client_lesson.lesson_id = Lesson.lesson_id "
                    + "WHERE Lesson.lesson_id = {0}", idLesson);
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
        //Enroll lesson

        /// <summary>
        /// Method that enrolls the client to the lesson and substracts the quotas by 1.
        /// </summary>
        /// <param name="json">The information of the client from which to enroll to the lesson.</param>
        /// <returns>A confirmation note or an error.</returns>
        public static bool ExecuteEnrollLesson(Client_Lessons json)
        {
            SqlConnection connection = new SqlConnection(cadenaConexion);


            try
            {
                connection.Open();
                //llamada al stored procedure 
                string query = string.Format("INSERT INTO Client_lesson (client_id,lesson_id) VALUES ({0}, {1}) " +
                    "UPDATE Lesson SET quotas = quotas - 1 WHERE lesson_id = {1} ", json.client_id, json.lesson_id);
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


        /****************************/


        //Start Shop Functions
        /// <summary>
        /// Method that queries a database to get all shops.
        /// </summary>
        /// <returns>A DataTable containing all shop information.</returns>
        public static DataTable GetAllShop()
        {
            SqlConnection connection = new SqlConnection(cadenaConexion);

            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Shop", connection);
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

        /// <summary>
        /// Method that that queries a database to modify a shop given their information.
        /// </summary>
        /// <param name="json">The information of the shop to modify.</param>
        /// <returns>A boolean value indicating whether the modfication was successful.</returns>
        public static bool ExecuteModShop(Shop json)
        {
            SqlConnection connection = new SqlConnection(cadenaConexion);


            try
            {
                connection.Open();
                //llamada al stored procedure 
                string query = string.Format("UPDATE Shop " +
                    "SET status = '{0}' WHERE branch_name = '{1}'", json.Status, json.Branch_Name);
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

        /// <summary>
        /// Method that queries a database to get shop's products.
        /// </summary>
        /// <param name="name">The branch name of the shop to obtain its products.</param>
        /// <returns>A DataTable containing all shop's products information (Branch name, barcode, product's name, description and price).</returns>
        public static DataTable GetShopProduct(string name)
        {
            SqlConnection connection = new SqlConnection(cadenaConexion);

            try
            {
                connection.Open();
                String query = string.Format("SELECT Shop.branch_name, Product.barcode, Product.name, Product.description, Product.price " +
                                             "FROM Shop " +
                                             "INNER JOIN Product ON Product.branch_name = Shop.branch_name " +
                                             "WHERE Shop.branch_name = '{0}'", name);

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



        //End Shop Functions


        //Start of Spa Functions
        /// <summary>
        /// Method that queries a database to get all spas.
        /// </summary>
        /// <returns>A DataTable containing all spas information.</returns>
        public static DataTable GetAllSpas()
        {
            SqlConnection connection = new SqlConnection(cadenaConexion);

            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Spa", connection);
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

        /// <summary>
        /// Method that that queries a database to modify a spa given their information.
        /// </summary>
        /// <param name="json">The information of the spa to modify.</param>
        /// <returns>A boolean value indicating whether the modfication was successful.</returns>
        public static bool ExecuteModSpa(Spa json)
        {
            SqlConnection connection = new SqlConnection(cadenaConexion);


            try
            {
                connection.Open();
                //llamada al stored procedure 
                string query = string.Format("UPDATE Spa " +
                    "SET status = '{0}' WHERE branch_name = '{1}'", json.Status, json.Branch_Name);
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

        /// <summary>
        /// Method that queries a database to get spa's treatments.
        /// </summary>
        /// <param branch_name="branch_name">The branch name of the spa to obtain its treatments.</param>
        /// <returns>A DataTable containing all spa's treatments information (branch_name, treatment_description).</returns>
        public static DataTable GetSpaTreatment(string branch_name) //TERMINAR ESTO
        {
            SqlConnection connection = new SqlConnection(cadenaConexion);

            try
            {
                connection.Open();
                String query = string.Format("SELECT Spa.branch_name , Treatment.treatment_description \r\n " +
                    "FROM Spa_Treatment  \r\n " +
                    "INNER JOIN Spa ON Spa.branch_name = Spa_Treatment.branch_name \r\n " +
                    "INNER JOIN Treatment ON Treatment.treatment_id = Spa_Treatment.treat_id " +
                    "WHERE Spa_Treatment.branch_name = '{0}' ", branch_name);

                //Console.WriteLine(query);
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
        //End of spa functions


        //Start of Workstation
        /// <summary>
        /// Method that queries a database to get all Employee's first name, first last name and id.
        /// </summary>
        /// <returns>A DataTable containing all specified information.</returns>
        public static DataTable GetAllJobs()
        {
            SqlConnection connection = new SqlConnection(cadenaConexion);

            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT Workstation.wks_id , Workstation.role, Workstation.description, Employee.id  " +
                    "FROM Workstation " +
                    "INNER JOIN Employee ON Employee.Workstaion_id = Workstation.wks_id ", connection);
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

        /// <summary>
        /// Method that queries a database to get all the information of a specific employee.
        /// </summary>
        /// <param name="Employee_ID">The employee identifier that refers to the query.</param>
        /// <returns>A database with all specified information.</returns>
        public static DataTable GetJob(String Employee_ID)
        {
            SqlConnection connection = new SqlConnection(cadenaConexion);

            try
            {
                connection.Open();
                string query = string.Format("SELECT Workstation.wks_id , Workstation.role, Workstation.description\r\n " +
                    "FROM Workstation\r\n " +
                    "INNER JOIN Employee ON Employee.Workstaion_id = Workstation.wks_id \r\n " +
                    "WHERE Employee.id = {0}", Employee_ID);
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


        /// <summary>
        /// Method that that queries a database to modify an employee given their information.
        /// </summary>
        /// <param name="json">The information of the employee to modify.</param>
        /// <returns>A boolean value indicating whether the modfication was successful.</returns>
        public static bool ExecuteModJob(EmployeeJOB json)
        {
            SqlConnection connection = new SqlConnection(cadenaConexion);


            try
            {
                connection.Open();
                //llamada al stored procedure 
                string query = string.Format("UPDATE Employee " +
                                             "SET Workstaion_id = '{1}' " +
                                             "WHERE id = '{0}';", json.Employee_ID, json.Employee_Workstation_id);
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
        //End of Workstation



    }
}
