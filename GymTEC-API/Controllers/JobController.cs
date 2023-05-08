using GymTEC_API.Entidades;
using GymTEC_API.Resources;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace GymTEC_API.Controllers
{
    [ApiController]
    [Route("api")]
    public class JobController : ControllerBase
    {
        /// <summary>
        /// Method that returns a list with the First Name, Last Name and ID 
        /// of all employees found within the database.
        /// </summary>
        /// <returns>A List with the First Name, Last Name and ID.</returns>
        /// <remarks>This method queries a database to retrieve employees.</remarks>


        [HttpGet("all_jobs")]
        public async Task<ActionResult<JSON_Object>> AllJobs()
        { //Function for obtaining all branch names.


            DataTable allJobs = DBData.GetAllJobs();

            List<String> Jobs_L = new List<String>();



            foreach (DataRow row in allJobs.Rows)
            {
                JobType job = new JobType();
                job.ID_JobType = Convert.ToInt32(row["wks_id"]);
                job.Role = row["role"].ToString();
                job.Description = row["description"].ToString();
                job.Employee_ID = row["id"].ToString();

                Jobs_L.Add($"{job.ID_JobType}, {job.Role}, {job.Description}, {job.Employee_ID}");

            }


            JSON_Object json = new JSON_Object("ok", Jobs_L);
            return Ok(json);


        }

        /// <summary>
        /// Method that returns a list with all the information 
        /// of an employee given their ID.
        /// </summary>
        /// <param name="Employee_ID">The ID of the employee from which to retrieve all data.</param>
        /// <returns>A list of all employee information given the specified ID.</returns>
        /// <remarks>This method queries a database to retrieve employee.</remarks>

        [HttpPost("obt_jobs")]
        public async Task<ActionResult<JSON_Object>> ObtainJobs(Employee_IDENT Employee_ID)
        { //Function for obtaining  branch info.


            DataTable allJob = DBData.GetJob(Employee_ID.Employee_ID);

            JobType job = new JobType();


            if (allJob != null)
            {
                foreach (DataRow row in allJob.Rows)
                {
                    job.ID_JobType = Convert.ToInt32(row["wks_id"]);
                    job.Role= row["role"].ToString();
                    job.Description = row["description"].ToString();
                    
                }

                JSON_Object json = new JSON_Object("ok", job);
                return Ok(json);
            }
            else { return BadRequest(); }

        }

        /// <summary>
        /// Method that modifies an employee given their information.
        /// </summary>
        /// <param name="employee_data">The information of the employee from which to modify their existing info.</param>
        /// <returns>A confirmation note or an error.</returns>
        /// <remarks>This method queries a database to delete employee.</remarks>
        [HttpPut("mod_job")]
        public async Task<ActionResult<JSON_Object>> ModJob(EmployeeJOB jobType_data)
        {
            JSON_Object json = new JSON_Object("error", null); //An error and null are initialized in order to verify any error.

            bool var = DBData.ExecuteModJob(jobType_data);
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
