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

