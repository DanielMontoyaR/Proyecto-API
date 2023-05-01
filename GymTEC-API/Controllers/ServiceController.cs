using GymTEC_API.Entidades;
using GymTEC_API.Resources;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace GymTEC_API.Controllers
{
    [ApiController]
    [Route("api")]
    public class ServiciosController:ControllerBase
    {

        /// <summary>
        /// Method that returns a list with the ID and Description
        /// of all services found within the database.
        /// </summary>
        /// <returns>A List with the ID and Description of all services.</returns>
        /// <remarks>This method queries a database to retrieve employees.</remarks>
        [HttpGet("all_services")]
        public async Task<ActionResult<JSON_Object>> AllServices()
        { //Function for obtaining all branch names.


            DataTable allServices = DBData.GetAllServices();

            List<Service> Services_L = new List<Service>();

            

            foreach (DataRow row in allServices.Rows)
            {
                Service service = new Service();
                service.ID_Service = row["service_id"].ToString();
                service.Description = row["service_description"].ToString();

                Services_L.Add(service);
            }

            JSON_Object json = new JSON_Object("ok", Services_L);
            return Ok(json);


        }

        /// <summary>
        /// Method that adds a service.
        /// </summary>
        /// <param name="service_data">All service information to add to the database.</param>
        /// <returns>A confimation note or an error.</returns>
        /// <remarks>This method queries a database to delete employee.</remarks>
        [HttpPost("add_service")]
        public async Task<ActionResult<JSON_Object>> AddService(Service service_data)
        {
            JSON_Object json = new JSON_Object("error", null); //Se inicializa con error y null para ver si hay algun error.

            bool var = DBData.ExecuteAddService(service_data);
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
        /// Method that deletes a service given their ID.
        /// </summary>
        /// <param name="service_id">The ID of the service from which to delete all data.</param>
        /// <returns>A confirmation note or an error.</returns>
        /// <remarks>This method queries a database to delete employee.</remarks>
        [HttpDelete("delete_service")]
        public async Task<ActionResult<JSON_Object>> DeleteService(Service_IDENT service_id)
        {
            JSON_Object json = new JSON_Object("error", null); //Se inicializa con error y null para ver si hay algun error.


            bool var = DBData.ExecuteDeleteService(service_id);
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
        /// Method that modifies a service given their information.
        /// </summary>
        /// <param name="service_data">The information of the service from which to modify their existing info.</param>
        /// <returns>A confirmation note or an error.</returns>
        /// <remarks>This method queries a database to delete employee.</remarks>
        [HttpPut("mod_service")]
        public async Task<ActionResult<JSON_Object>> ModService(Service service_data)
        {
            JSON_Object json = new JSON_Object("error", null); //Se inicializa con error y null para ver si hay algun error.

            bool var = DBData.ExecuteModService(service_data);
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

