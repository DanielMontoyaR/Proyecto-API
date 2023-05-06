using GymTEC_API.Entidades;
using GymTEC_API.Resources;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace GymTEC_API.Controllers
{


    [ApiController]
    [Route("api")]
    public class ShopController : ControllerBase
    {

        /// <summary>
        /// Method that returns a list with all the information
        /// of all shops found within the database.
        /// </summary>
        /// <returns>A List with the Branch name and status of all shops.</returns>
        /// <remarks>This method queries a database to retrieve shops.</remarks>


        [HttpGet("all_shop")]
        public async Task<ActionResult<JSON_Object>> AllShops()
        { //Function for obtaining all branch names.


            DataTable allShop = DBData.GetAllShop();

            List<Shop> shop_L = new List<Shop>();



            foreach (DataRow row in allShop.Rows)
            {
                Shop shop = new Shop();
                shop.Branch_Name = row["branch_name"].ToString();
                shop.Status = row["status"].ToString();


                shop_L.Add(shop);

            }



            //Employee_L.Add(employee.Employee_LName1);
            //Employee_L.Add(employee.Employee_ID);
            JSON_Object json = new JSON_Object("ok", shop_L);
            return Ok(json);


        }


        /// <summary>
        /// Method that modifies a shop given their information.
        /// </summary>
        /// <param name="shop_data">The information of the shop from which to modify their existing info.</param>
        /// <returns>A confirmation note or an error.</returns>
        /// <remarks>This method queries a database to modify shop.</remarks>
        [HttpPut("mod_shop")]
        public async Task<ActionResult<JSON_Object>> ModShop(Shop shop_data)
        {
            JSON_Object json = new JSON_Object("error", null); //Se inicializa con error y null para ver si hay algun error.

            bool var = DBData.ExecuteModShop(shop_data);
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
