using GymTEC_API.Entidades;
using GymTEC_API.Resources;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace GymTEC_API.Controllers
{


    [ApiController]
    [Route("api")]
    public class EmployeeController : ControllerBase
    {

        /// <summary>
        /// Method that returns a list with the First Name, Last Name and ID 
        /// of all employees found within the database.
        /// </summary>
        /// <returns>A List with the First Name, Last Name and ID.</returns>
        /// <remarks>This method queries a database to retrieve employees.</remarks>


        [HttpGet("all_employee")]
        public async Task<ActionResult<JSON_Object>> AllEmployees()
        { //Function for obtaining all branch names.


            DataTable allEmployee = DBData.GetAllEmployees();

            List<String> Employee_L = new List<String>();



            foreach (DataRow row in allEmployee.Rows)
            {
                Employee employee = new Employee();
                employee.Employee_Fname = row["Fname"].ToString();
                employee.Employee_LName1 = row["FLname"].ToString();
                employee.Employee_ID = row["id"].ToString();

                Employee_L.Add($"{employee.Employee_Fname}, {employee.Employee_LName1}, {employee.Employee_ID}");

            }



            //Employee_L.Add(employee.Employee_LName1);
            //Employee_L.Add(employee.Employee_ID);
            JSON_Object json = new JSON_Object("ok", Employee_L);
            return Ok(json);


        }

        /// <summary>
        /// Method that returns a list with all the information 
        /// of an employee given their ID.
        /// </summary>
        /// <param name="Employee_ID">The ID of the employee from which to retrieve all data.</param>
        /// <returns>A list of all employee information given the specified ID.</returns>
        /// <remarks>This method queries a database to retrieve employee.</remarks>

        [HttpPost("obt_employee")]
        public async Task<ActionResult<JSON_Object>> ObtainEmployee(Employee_IDENT Employee_ID)
        { //Function for obtaining  branch info.


            DataTable allEmployee = DBData.GetEmployee(Employee_ID.Employee_ID);

            Employee employee = new Employee();


            if (allEmployee != null)
            {
                foreach (DataRow row in allEmployee.Rows)
                {

                    employee.Employee_Fname             = row["Fname"].ToString();
                    employee.Employee_Mname             = row["Sname"].ToString();
                    employee.Employee_LName1            = row["FLname"].ToString();
                    employee.Employee_LName2            = row["SLname"].ToString();
                    employee.Employee_ID                = row["id"].ToString();
                    employee.Employee_Email             = row["email"].ToString();
                    employee.Employee_Password          = row["password"].ToString();
                    employee.Employee_Canton            = row["canton"].ToString();
                    employee.Employee_District          = row["district"].ToString();
                    employee.Employee_Province          = row["province"].ToString();
                    employee.Employee_payroll_id        = row["form_id"].ToString();
                    employee.Employee_Workstation_id    = row["Workstaion_id"].ToString();
                    employee.Branch_Name                = row["branch_name"].ToString();



                }

                JSON_Object json = new JSON_Object("ok", employee);
                return Ok(json);
            }
            else { return BadRequest(); }

        }
        /*
        [HttpPost("add_employee")] //This method is handled in SignUp.cs
        public async Task<ActionResult<JSON_Object>> AddEmployee(Employee employee_data)
        {
            JSON_Object json = new JSON_Object("error", null); //An error and null are initialized in order to verify any error.

            bool var = DBData.ExecuteAddEmployee(employee_data);
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

        }*/

        /// <summary>
        /// Method that deletes an employee given their ID.
        /// </summary>
        /// <param name="employee_data">The ID of the employee from which to delete all data.</param>
        /// <returns>A confirmation note or an error.</returns>
        /// <remarks>This method queries a database to delete employee.</remarks>
        [HttpDelete("delete_employee")]
        public async Task<ActionResult<JSON_Object>> DeleteEmployee(Employee_IDENT employee_data)
        {
            JSON_Object json = new JSON_Object("error", null); //An error and null are initialized in order to verify any error.


            bool var = DBData.ExecuteDeleteEmployee(employee_data);
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
        /// Method that modifies an employee given their information.
        /// </summary>
        /// <param name="employee_data">The information of the employee from which to modify their existing info.</param>
        /// <returns>A confirmation note or an error.</returns>
        /// <remarks>This method queries a database to delete employee.</remarks>
        [HttpPut("mod_employee")]
        public async Task<ActionResult<JSON_Object>> ModEmployee(Employee employee_data)
        {
            JSON_Object json = new JSON_Object("error", null); //An error and null are initialized in order to verify any error.

            bool var = DBData.ExecuteModEmployee(employee_data);
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
