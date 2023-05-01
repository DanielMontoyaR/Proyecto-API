using GymTEC_API.Entidades;
using GymTEC_API.Resources;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace GymTEC_API.Controllers
{
    [ApiController]
    [Route("api")]
    public class PaymentController:ControllerBase
    {

        /// <summary>
        /// Method that gets all employee payrolls.
        /// </summary>
        /// <returns>A list containing all the information from the employees' payrolls.</returns>
        /// <remarks>This method queries a database to delete employee.</remarks>
        [HttpGet("all_payrolls")]
        public async Task<ActionResult<JSON_Object>> AllPayrolls()
        { //Function for obtaining all branch names.


            DataTable allPayroll = DBData.GetAllPayrolls();

            List<Payroll> Services_L = new List<Payroll>();



            foreach (DataRow row in allPayroll.Rows)
            {
                Payroll payroll = new Payroll();
                payroll.ID_Payroll = Convert.ToInt32(row["id"]);
                payroll.Description = row["description"].ToString();
                payroll.Payroll_Type = row["typepayment"].ToString();

                Services_L.Add(payroll);
            }

            JSON_Object json = new JSON_Object("ok", Services_L);
            return Ok(json);


        }

        /// <summary>
        /// Method that adds a payroll.
        /// </summary>
        /// <param name="payroll_data">All payroll information to add to the database.</param>
        /// <returns>A confimation note or an error.</returns>
        /// <remarks>This method queries a database to delete employee.</remarks>
        [HttpPost("add_payroll")]
        public async Task<ActionResult<JSON_Object>> AddPayroll(Payroll payroll_data)
        {
            JSON_Object json = new JSON_Object("error", null); //An error and null are initialized in order to verify any error.

            bool var = DBData.ExecuteAddPayroll(payroll_data);
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
        /// Method that modifies a payroll given their information.
        /// </summary>
        /// <param name="payroll_data">The information of the payroll from which to modify their existing info.</param>
        /// <returns>A confirmation note or an error.</returns>
        /// <remarks>This method queries a database to delete employee.</remarks>
        [HttpPut("mod_payroll")]
        public async Task<ActionResult<JSON_Object>> ModPayroll(Payroll payroll_data)
        {
            JSON_Object json = new JSON_Object("error", null); //An error and null are initialized in order to verify any error.

            bool var = DBData.ExecuteModPayroll(payroll_data);
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
