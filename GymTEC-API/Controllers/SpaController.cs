using GymTEC_API.Entidades;
using GymTEC_API.Resources;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace GymTEC_API.Controllers
{
    [ApiController]
    [Route("api")]
    public class SpaController : ControllerBase
    {
        /// <summary>
        /// Method that returns a list with all the information
        /// of all shops found within the database.
        /// </summary>
        /// <returns>A List with the Branch name and status of all shops.</returns>
        /// <remarks>This method queries a database to retrieve shops.</remarks>


        [HttpGet("all_spa")]
        public async Task<ActionResult<JSON_Object>> AllSpas()
        { //Function for obtaining all branch names.


            DataTable allShop = DBData.GetAllSpas();

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
        [HttpPut("mod_spa")]
        public async Task<ActionResult<JSON_Object>> ModSpa(Spa spa_data)
        {
            JSON_Object json = new JSON_Object("error", null); //Se inicializa con error y null para ver si hay algun error.

            bool var = DBData.ExecuteModSpa(spa_data);
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
        /// Method that returns a list with all the products 
        /// of a shop given their branch name.
        /// </summary>
        /// <param name="Product_Branch_Name">The branch name of the shop from which to retrieve all data.</param>
        /// <returns>A list of all products given the specified branch name.</returns>
        /// <remarks>This method queries a database to retrieve shop's products.</remarks>
        [HttpPost("obt_spa_treatment")]
        public async Task<ActionResult<JSON_Object>> ObtainSpaTreatment(Branch_IDENT Treatment_Branch_Name)
        { //Function for obtaining  branch info.


            DataTable allSpaTreatment = DBData.GetSpaTreatment(Treatment_Branch_Name.Name);


            List<SpaTreatment> Treatment_L = new List<SpaTreatment>();



            foreach (DataRow row in allSpaTreatment.Rows)
            {
                SpaTreatment treatment = new SpaTreatment();
                treatment.Branch_Name = row["branch_name"].ToString();
                treatment.Description = row["treatment_description"].ToString();
                

                Treatment_L.Add(treatment);
            }

            JSON_Object json = new JSON_Object("ok", Treatment_L);
            return Ok(json);

        }
    }
}
