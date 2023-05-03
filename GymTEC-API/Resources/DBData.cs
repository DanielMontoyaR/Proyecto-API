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


        //Start Client Functions
        public static bool ExecuteAddClient(Client json) {

            SqlConnection connection = new SqlConnection(cadenaConexion);

            try
            {
                connection.Open();
                //llamada al stored procedure 
                string query = string.Format("INSERT INTO Client(client_id,address,weight,IMC,Fname,Sname,FLname,SLname,password,bdate)" +
                                                "VALUES ('{0}', '{1}', {2}, {3}, '{4}', '{5}', '{6}', '{7}', '{8}', '{9}')",
                                                json.ID_Client, json.Address, json.Weight, json.BMI, json.FName1,json.FName2, json.Last_name1,json.Last_name2,json.Password,json.Birth_Date);
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
        public static DataTable GetAllGears()
        {
            SqlConnection connection = new SqlConnection(cadenaConexion);

            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT Gear_avalible.name, Gear_type.gear_type\r\n" +
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
