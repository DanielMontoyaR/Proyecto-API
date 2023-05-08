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
                payroll.ID_Payroll = Convert.ToInt32(row["Form_id"]);
                payroll.Description = row["description"].ToString();
                payroll.Payroll_Type = row["typepayment"].ToString();
                payroll.Employee_ID = row["id"].ToString();
                Services_L.Add(payroll);
            }

            JSON_Object json = new JSON_Object("ok", Services_L);
            return Ok(json);


        }
        /// <summary>
        /// Method that returns a list with all the information 
        /// of an employee given their ID.
        /// </summary>
        /// <param name="Employee_ID">The ID of the employee from which to retrieve all data.</param>
        /// <returns>A list of all employee information given the specified ID.</returns>
        /// <remarks>This method queries a database to retrieve employee.</remarks>

        [HttpPost("obt_payroll")]
        public async Task<ActionResult<JSON_Object>> ObtainPayroll(Employee_IDENT Employee_ID)
        { //Function for obtaining  branch info.


            DataTable allPayroll = DBData.GetPayroll(Employee_ID.Employee_ID);

            Payroll payroll = new Payroll();


            if (allPayroll != null)
            {
                foreach (DataRow row in allPayroll.Rows)
                {
                    payroll.ID_Payroll = Convert.ToInt32(row["form_id"]);
                    payroll.Payroll_Type = row["typepayment"].ToString();
                    payroll.Description = row["description"].ToString();

                }

                JSON_Object json = new JSON_Object("ok", payroll);
                return Ok(json);
            }
            else { return BadRequest(); }

        }

        /// <summary>
        /// Method that modifies a payroll given their information.
        /// </summary>
        /// <param name="payroll_data">The information of the payroll from which to modify their existing info.</param>
        /// <returns>A confirmation note or an error.</returns>
        /// <remarks>This method queries a database to delete employee.</remarks>
        [HttpPut("mod_payroll")]
        public async Task<ActionResult<JSON_Object>> ModPayroll(EmployeePAYROLL payroll_data)
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
