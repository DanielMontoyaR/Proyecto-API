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
        [HttpGet("all_employee")]
        public async Task<ActionResult<JSON_Object>> AllEmployees()
        { //Function for obtaining all branch names.


            DataTable allEmployee = DBData.GetAllPayrolls();

            List<Employee> Employee_L = new List<Employee>();



            foreach (DataRow row in allEmployee.Rows)
            {
                Employee employee = new Employee();
                employee.Employee_Fname = row["Fname"].ToString();
                employee.Employee_LName1 = row["FLname"].ToString();
                employee.Employee_ID = row["id"].ToString();

                Employee_L.Add(employee);
            }

            JSON_Object json = new JSON_Object("ok", Employee_L);
            return Ok(json);


        }

        [HttpPost("obt_employee")]
        public async Task<ActionResult<JSON_Object>> ObtainEmployee(Employee_IDENT Employee_ID)
        { //Function for obtaining  branch info.


            DataTable allEmployee = DBData.GetBranch(Employee_ID.Employee_ID);

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
        [HttpPost("add_employee")]
        public async Task<ActionResult<JSON_Object>> AddEmployee(Employee employee_data)
        {
            JSON_Object json = new JSON_Object("error", null); //Se inicializa con error y null para ver si hay algun error.

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


        [HttpDelete("delete_employee")]
        public async Task<ActionResult<JSON_Object>> DeleteEmployee(Employee_IDENT employee_data)
        {
            JSON_Object json = new JSON_Object("error", null); //Se inicializa con error y null para ver si hay algun error.


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


        [HttpPut("mod_employee")]
        public async Task<ActionResult<JSON_Object>> ModEmployee(Employee employee_data)
        {
            JSON_Object json = new JSON_Object("error", null); //Se inicializa con error y null para ver si hay algun error.

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
