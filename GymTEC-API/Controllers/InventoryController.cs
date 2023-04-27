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


            DataTable allBranch = DBData.GetAllInventory();

            List<String> inventory_L = new List<String>();

            foreach (DataRow row in allBranch.Rows)
            {
                Inventory inventory = new Inventory(); 
                inventory.Serial_Number = (int)row["serial_num"];
                inventory.Brand = row["brand"].ToString();

                inventory_L.Add(inventory.Brand);
                inventory_L.Add(inventory.Serial_Number.ToString());
                

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
                    inventory.Serial_Number = (int)row["serial_num"];
                    inventory.Price = row["price"].ToString();
                    inventory.gear_ID = (int)row["gear_id"];
                    
                }

                JSON_Object json = new JSON_Object("ok", inventory);
                return Ok(json);
            }
            else { return BadRequest(); }

        }

        //Add Inventory


        //Put inventory


        //Delete inventory
    }
}
