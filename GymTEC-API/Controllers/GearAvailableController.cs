using GymTEC_API.Entidades;
using GymTEC_API.Resources;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace GymTEC_API.Controllers
{
    [ApiController]
    [Route("api")]
    public class GearAvailableController : ControllerBase
    {
        //Get All equipment
        [HttpGet("all_gear")]
        public async Task<ActionResult<JSON_Object>> AllGear()
        {
            DataTable allGear = DBData.GetAllGears();

            List<String> gear_L = new List<String>();

            foreach (DataRow row in allGear.Rows)
            {
                GearAvailable gear = new GearAvailable();
                gear.Name = row["name"].ToString();

                gear_L.Add(gear.Name);

            }

            JSON_Object json = new JSON_Object("ok", gear_L);
            return Ok(json);
        }


        //Get Equipment
        [HttpPost("obt_gear")]
        public async Task<ActionResult<JSON_Object>> ObtainGear(GearAvailable_IDENT gear_name)
        { //Function for obtaining  gear info.


            DataTable allGear = DBData.GetGear(gear_name.gear_ID);

            GearAvailable allGearAvailable = new GearAvailable();
            GearType allgearType = new GearType();
            List<String> gear_List = new List<String>();


            if (allGear != null)
            {
                foreach (DataRow row in allGear.Rows)
                {

                    allGearAvailable.Name = row["name"].ToString();
                    allGearAvailable.Description = row["description"].ToString();
                    allGearAvailable.gear_ID = (int)row["gear_id"];
                    allgearType.Gear_Type = row["gear_type"].ToString();


                }
                gear_List.Add(allGearAvailable.Name);
                gear_List.Add(allGearAvailable.Description);
                gear_List.Add(allGearAvailable.gear_ID.ToString());
                gear_List.Add(allgearType.Gear_Type);


                JSON_Object json = new JSON_Object("ok", gear_List);
                return Ok(json);
            }
            else { return BadRequest(); }

        }

        //Add equipment Available
        [HttpPost("add_gear")]
        public async Task<ActionResult<JSON_Object>> AddGear(GearAvailable gear_data)
        {
            JSON_Object json = new JSON_Object("error", null); //Se inicializa con error y null para ver si hay algun error.

            bool var = DBData.ExecuteAddGear(gear_data);
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

        //Add equipment Type
        [HttpPost("add_gear_type")]
        public async Task<ActionResult<JSON_Object>> AddGearType(GearType gear_type_data)
        {
            JSON_Object json = new JSON_Object("error", null); //Se inicializa con error y null para ver si hay algun error.

            bool var = DBData.ExecuteAddGearType(gear_type_data);
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


        //Put equipment
        [HttpPut("mod_gear")]
        public async Task<ActionResult<JSON_Object>> ModGear(GearAvailable gear_data)
        {
            JSON_Object json = new JSON_Object("error", null); //Se inicializa con error y null para ver si hay algun error.

            bool var = DBData.ExecuteModGear(gear_data);
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


        //Delete equipment
        [HttpDelete("delete_gear")]
        public async Task<ActionResult<JSON_Object>> DeleteGear(GearAvailable_IDENT gear_avalaible_data)
        {
            JSON_Object json = new JSON_Object("error", null); //Se inicializa con error y null para ver si hay algun error.


            bool var = DBData.ExecuteDeleteGear(gear_avalaible_data);
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
