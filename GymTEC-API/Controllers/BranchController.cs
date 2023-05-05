using GymTEC_API.Entidades;
using GymTEC_API.Resources;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Text.Json.Serialization;

namespace GymTEC_API.Controllers
{

    [ApiController]
    [Route("api")]
    public class BranchController:ControllerBase
    {


        /// <summary>
        /// Method that returns a list with the name
        /// of all branches found within the database.
        /// </summary>
        /// <returns>A List with the name of all branches.</returns>
        /// <remarks>This method queries a database to retrieve branches.</remarks>
        [HttpGet("all_branches")]
        public async Task<ActionResult<JSON_Object>> AllBranches() { //Function for obtaining all branch names.


            DataTable allBranch = DBData.GetAllBranches();

            List<String> branch_L = new List<String>();
            
            foreach (DataRow row in allBranch.Rows)
            {
                Branch branch = new Branch();
                branch.Name = row["branch_name"].ToString();

                branch_L.Add(branch.Name);

            }

            JSON_Object json = new JSON_Object("ok", branch_L);
            return Ok(json);


        }

        /// <summary>
        /// Method that returns a list with all the information 
        /// of a branch given their Name.
        /// </summary>
        /// <param name="branch_name">The Name of the branch from which to retrieve all data.</param>
        /// <returns>A list of all branch information given the specified Name.</returns>
        /// <remarks>This method queries a database to retrieve branch.</remarks>
        [HttpPost("obt_branch")]
        public async Task<ActionResult<JSON_Object>> ObtainBranch( Branch_IDENT branch_name)
        { //Function for obtaining  branch info.
          

            DataTable allBranch = DBData.GetBranch(branch_name.Name);

            Branch branch = new Branch();


            if (allBranch != null) {
                foreach (DataRow row in allBranch.Rows)
                {
                    
                    branch.Province = row["province"].ToString();
                    branch.District = row["district"].ToString();
                    branch.Canton = row["canton"].ToString();
                    branch.Name = row["branch_name"].ToString();
                    branch.max_Size = Convert.ToInt32(row["max_capacity"]);
                    branch.opening_Date = row["openDate"].ToString();
                    branch.schedule_Attention = row["branch_schedule"].ToString();

                   

                }

                JSON_Object json = new JSON_Object("ok", branch);
                return Ok(json);
            }else { return BadRequest(); }

        }
        /// <summary>
        /// Method that adds a branch.
        /// </summary>
        /// <param name="branch_data">All branch information to add to the database.</param>
        /// <returns>A confimation note or an error.</returns>
        /// <remarks>This method queries a database to add branch.</remarks>
        [HttpPost("add_branch")]
        public async Task<ActionResult<JSON_Object>> AddBranch( Branch branch_data)
        {
            JSON_Object json = new JSON_Object("error", null); //Se inicializa con error y null para ver si hay algun error.

            bool var = DBData.ExecuteAddBranch(branch_data);
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
        /// Method that deletes a branch given their Name.
        /// </summary>
        /// <param name="branch_data">The Name of the branch from which to delete all data.</param>
        /// <returns>A confirmation note or an error.</returns>
        /// <remarks>This method queries a database to delete branch.</remarks>
        [HttpDelete("delete_branch")]
        public async Task<ActionResult<JSON_Object>> DeleteBranch(Branch_IDENT branch_data)
        {
            JSON_Object json = new JSON_Object("error", null); //Se inicializa con error y null para ver si hay algun error.

 
            bool var = DBData.ExecuteDeleteBranch(branch_data);
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
        /// Method that modifies a branch given their information.
        /// </summary>
        /// <param name="branch_data">The information of the branch from which to modify their existing info.</param>
        /// <returns>A confirmation note or an error.</returns>
        /// <remarks>This method queries a database to modify branch.</remarks>
        [HttpPut("mod_branch")]
        public async Task<ActionResult<JSON_Object>> ModBranch(Branch branch_data)
        {
            JSON_Object json = new JSON_Object("error", null); //Se inicializa con error y null para ver si hay algun error.

            bool var = DBData.ExecuteModBranch(branch_data);
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
