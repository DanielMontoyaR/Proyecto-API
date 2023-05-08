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

            List<GearINNER> gear_L = new List<GearINNER>();

            foreach (DataRow row in allGear.Rows)
            {
                GearINNER gearINNER = new GearINNER();  
                
                gearINNER.Name = row["name"].ToString();
                gearINNER.Gear_Type = row["gear_type"].ToString();
                gearINNER.Gear_ID = Convert.ToInt32(row["gear_id"]);

                gear_L.Add(gearINNER);

            }

            JSON_Object json = new JSON_Object("ok", gear_L);
            return Ok(json);
        }


        //Get Equipment
        [HttpPost("obt_gear")]
        public async Task<ActionResult<JSON_Object>> ObtainGear(GearAvailable_IDENT gear_name)
        { //Function for obtaining  gear info.


            DataTable allGear = DBData.GetGear(gear_name.gear_ID);

            GearOBT gearOBT = new GearOBT();
            List<GearOBT> gear_List = new List<GearOBT>();


            if (allGear != null)
            {
                foreach (DataRow row in allGear.Rows)
                {

                    gearOBT.Name = row["name"].ToString();
                    gearOBT.Description = row["description"].ToString();
                    gearOBT.gear_ID = Convert.ToInt32(row["gear_id"]);
                    gearOBT.Gear_Type = row["gear_type"].ToString();


                }
                gear_List.Add(gearOBT);
                

                JSON_Object json = new JSON_Object("ok", gear_List);
                return Ok(json);
            }
            else { return BadRequest(); }

        }

        //Add equipment Available
        [HttpPost("add_gear")]
        public async Task<ActionResult<JSON_Object>> AddGear(GearOBT gear_data)
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


        //Put equipment
        [HttpPut("mod_gear")]
        public async Task<ActionResult<JSON_Object>> ModGear(GearOBT gear_data)
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
