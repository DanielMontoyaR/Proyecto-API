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

                DataTable allEmployee = DBData.EmployeeLogin(Employee_Credentials);

                Credentials employee = new Credentials();

                foreach (DataRow row in allEmployee.Rows)
                {
                    employee.ID_Credentials = row["id"].ToString();
                    employee.Password = row["password"].ToString();
                }
                if (Employee_Credentials.Password == employee.Password && Employee_Credentials.ID_Credentials == employee.ID_Credentials)
                {
                    json.status = "ok";
                    json.result = employee;
                    return Ok(json);
                }
                else
                {
                    return BadRequest(json);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return BadRequest();
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
                DataTable allClient = DBData.ClientLogin(client_credentials);
                Credentials client = new Credentials();

                foreach (DataRow row in allClient.Rows)
                {
                    client.ID_Credentials = row["client_id"].ToString();
                    client.Password = row["password"].ToString();
                }
                if (client_credentials.Password == client.Password && client_credentials.ID_Credentials == client.ID_Credentials)
                {
                    json.status = "ok";
                    json.result = client;
                    return Ok(json);
                }
                else {
                    return BadRequest(json);
                }
                

            }
            catch(Exception e){ 
                Console.WriteLine(e.ToString());
                return BadRequest();
            }


            



        }
    }
}
