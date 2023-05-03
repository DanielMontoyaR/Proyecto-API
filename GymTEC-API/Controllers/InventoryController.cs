using GymTEC_API.Entidades;
using GymTEC_API.Resources;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace GymTEC_API.Controllers
{
    [ApiController]
    [Route("api")]
    public class InventoryController:ControllerBase
    {
        //Get all inventories
        [HttpGet("all_inventories")]
        public async Task<ActionResult<JSON_Object>> AllInventories()
        { //Function for obtaining all inventory names.


            DataTable allInventory = DBData.GetAllInventory();

            List<Inventory> inventory_L = new List<Inventory>();

            foreach (DataRow row in allInventory.Rows)
            {
                Inventory inventory = new Inventory();
                inventory.Serial_Number = Convert.ToInt32(row["serial_num"]);
                inventory.Brand = row["brand"].ToString();
                inventory.gear_Name = row["name"].ToString();
                inventory.gear_Type = row["gear_type"].ToString();

                inventory_L.Add(inventory);
            }
            

            JSON_Object json = new JSON_Object("ok", inventory_L);
            return Ok(json);


        }
        //Get inventory
        [HttpPost("obt_inventory")]
        public async Task<ActionResult<JSON_Object>> ObtainInventory(Inventory_IDENT inventory_name)
        { //Function for obtaining  branch info.


            DataTable allInventory = DBData.GetInventory(inventory_name.Serial_Number);

            Inventory inventory = new Inventory();
            
            

            if (allInventory != null)
            {
                foreach (DataRow row in allInventory.Rows)
                {
                    
                    inventory.Branch_Name = row["branch_name"].ToString();
                    inventory.Brand = row["brand"].ToString();
                    inventory.Serial_Number = Convert.ToInt32(row["serial_num"]);
                    inventory.Price = row["price"].ToString();
                    inventory.gear_Name = row["name"].ToString();
                    inventory.gear_Type = row["gear_type"].ToString();
                    inventory.gear_ID = Convert.ToInt32(row["gear_id"]);
                    
                }

                JSON_Object json = new JSON_Object("ok", inventory);
                return Ok(json);
            }
            else { return BadRequest(); }

        }

        //Add Inventory
        [HttpPost("add_inventory")]
        public async Task<ActionResult<JSON_Object>> AddInventory(Inventory inventory)
        {
            JSON_Object json = new JSON_Object("error", null); //Se inicializa con error y null para ver si hay algun error.

            bool var = DBData.ExecuteAddInventory(inventory);
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

        //Put inventory
        [HttpPut("mod_inventory")]
        public async Task<ActionResult<JSON_Object>> ModInventory(Inventory_ALL inventory_all)
        {
            JSON_Object json = new JSON_Object("error", null); //Se inicializa con error y null para ver si hay algun error.

            bool var = DBData.ExecuteModInventory(inventory_all);
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

        //Delete inventory
        [HttpDelete("delete_inventory")]
        public async Task<ActionResult<JSON_Object>> DeleteInventory(Inventory_IDENT inventory_data)
        {
            JSON_Object json = new JSON_Object("error", null); //Se inicializa con error y null para ver si hay algun error.


            bool var = DBData.ExecuteDeleteInventory(inventory_data);
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
