﻿using System.Data;
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
