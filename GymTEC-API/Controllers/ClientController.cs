using Microsoft.AspNetCore.Mvc;
using GymTEC_API.Entidades;
using System.Net;

using Microsoft.OpenApi.Models;
using GymTEC_API.Resources;
using System.Data;

namespace GymTEC_API.Controllers

{
    public class ClientController : ControllerBase
    {
        /// <summary>
        /// Method that returns a list with the First Name, Last Name and ID
        /// of all clients found within the database.
        /// </summary>
        /// <returns>A List with the First Name, Last Name and ID of clients.</returns>
        /// <remarks>This method queries a database to retrieve employees.</remarks>


        [HttpGet("all_client")]
        public async Task<ActionResult<JSON_Object>> AllClients()
        { //Function for obtaining all branch names.


            DataTable allClient = DBData.GetAllClients();

            List<String> Client_L = new List<String>();



            foreach (DataRow row in allClient.Rows)
            {
                Client client = new Client();
                client.FName1 = row["Fname"].ToString();
                client.Last_name1 = row["FLname"].ToString();
                client.ID_Client = row["client_id"].ToString();

                Client_L.Add($"{client.FName1}, {client.Last_name1}, {client.ID_Client}");

            }

            JSON_Object json = new JSON_Object("ok", Client_L);
            return Ok(json);


        }

        /// <summary>
        /// Method that returns a list with all the information 
        /// of an client given their ID.
        /// </summary>
        /// <param name="client_id">The ID of the client from which to retrieve all data.</param>
        /// <returns>A list of all client information given the specified ID.</returns>
        /// <remarks>This method queries a database to retrieve employee.</remarks>

        [HttpPost("obt_client")]
        public async Task<ActionResult<JSON_Object>> ObtainClient(Client_IDENT client_id)
        { //Function for obtaining  branch info.


            DataTable allBranch = DBData.GetClient(client_id.ID_Client);

            Client client = new Client();


            if (allBranch != null)
            {
                foreach (DataRow row in allBranch.Rows)
                {

                    client.ID_Client    = row["client_id"].ToString();
                    client.Address      = row["address"].ToString();
                    client.Weight       = Convert.ToInt32(row["weight"]);
                    client.BMI          = Convert.ToInt32(row["IMC"]);
                    client.FName1       = row["Fname"].ToString();
                    client.FName2       = row["Sname"].ToString();
                    client.Last_name1   = row["FLname"].ToString();
                    client.Last_name2   = row["SLname"].ToString();
                    client.Password     = row["password"].ToString();
                    client.Birth_Date   = row["bdate"].ToString();


                }

                JSON_Object json = new JSON_Object("ok", client);
                return Ok(json);
            }
            else { return BadRequest(); }

        }

        /// <summary>
        /// Method that deletes an client given their ID.
        /// </summary>
        /// <param name="client_data">The ID of the client from which to delete all data.</param>
        /// <returns>A confirmation note or an error.</returns>
        /// <remarks>This method queries a database to delete employee.</remarks>
        [HttpDelete("delete_client")]
        public async Task<ActionResult<JSON_Object>> DeleteClient(Client_IDENT client_data)
        {
            JSON_Object json = new JSON_Object("error", null); //An error and null are initialized in order to verify any error.


            bool var = DBData.ExecuteDeleteClient(client_data);
            Console.WriteLine(var);
            if (var)
            {
                json.status = "ok";
                return Ok(json);
            }
            else
            {
                return BadRequest(json);
            }

        }

        /// <summary>
        /// Method that modifies a client given their information.
        /// </summary>
        /// <param name="client_data">The information of the client from which to modify their existing info.</param>
        /// <returns>A confirmation note or an error.</returns>
        /// <remarks>This method queries a database to delete employee.</remarks>
        [HttpPut("mod_client")]
        public async Task<ActionResult<JSON_Object>> ModClient(Client client_data)
        {
            JSON_Object json = new JSON_Object("error", null); //An error and null are initialized in order to verify any error.

            bool var = DBData.ExecuteModClient(client_data);
            Console.WriteLine(var);
            if (var)
            {
                json.status = "ok";
                return Ok(json);
            }
            else
            {

                return BadRequest(json);
            }


        }
    }
}