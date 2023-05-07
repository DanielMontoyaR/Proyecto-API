using Microsoft.AspNetCore.Mvc;
using GymTEC_API.Entidades;
using System.Net;
using GymTEC_API.Resources;
using System.Data;

namespace GymTEC_API.Controllers

{
    [ApiController]
    [Route("api")]
    public class LoginController : ControllerBase
    {

        /// <summary>
        /// Method that validates the credentials from the employee.
        /// </summary>
        /// <param name="Employee_Credentials">The credentials of the employee.</param>
        /// <returns>A confirmation note or an error.</returns>
        /// <remarks>This method queries a database to modify branch.</remarks>
        [HttpPost("auth_employee")]
        public async Task<ActionResult<JSON_Object>> AuthEmployee(Credentials Employee_Credentials)
        { //Function for obtaining  branch info.

            JSON_Object json = new JSON_Object("error", null); //Se inicializa con error y null para ver si hay algun error.
            try
            {

                Employee_Credentials.Password = MD5Encrypt.EncryptPassword(Employee_Credentials.Password);

                DataTable allEmployee = DBData.EmployeeLogin(Employee_Credentials);

                Credentials employee = new Credentials();


                foreach (DataRow row in allEmployee.Rows)
                {
                    if (row["id"].ToString() != "")
                    {
                        employee.ID_Credentials = row["id"].ToString();
                        employee.Password = row["password"].ToString();

                        json.status = "ok";
                        json.result = employee;
                        
                    }
                    else {
                        json.status = "error";
                        return BadRequest(json);
                    }
                    
                }
                return json;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return BadRequest(json);
            }

        }

        /// <summary>
        /// Method that validates the credentials from the client.
        /// </summary>
        /// <param name="client_credentials">The credentials of the client.</param>
        /// <returns>A confirmation note or an error.</returns>
        /// <remarks>This method queries a database to modify branch.</remarks>
        [HttpPost("auth_cliente")]
        public async Task<ActionResult<JSON_Object>> AuthCliente(Credentials client_credentials)
        {
            JSON_Object json = new JSON_Object("error", null); //Se inicializa con error y null para ver si hay algun error.
            try {

                client_credentials.Password = MD5Encrypt.EncryptPassword(client_credentials.Password);

                DataTable allClient = DBData.ClientLogin(client_credentials);

                Credentials client = new Credentials();

                foreach (DataRow row in allClient.Rows)
                {
                    if (row["client_id"].ToString() != "")
                    {
                        client.ID_Credentials = row["client_id"].ToString();
                        client.Password = row["password"].ToString();

                        json.status = "ok";
                        json.result = client;

                    }
                    else
                    {
                        json.status = "error";
                        return BadRequest(json);
                    }

                }
                return json;


            }
            catch(Exception e){ 
                Console.WriteLine(e.ToString());
                return BadRequest();
            }


            



        }
    }
}
