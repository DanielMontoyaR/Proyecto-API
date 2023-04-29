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

        [HttpPost("add_payroll")]
        public async Task<ActionResult<JSON_Object>> AddPayroll(Payroll payroll_data)
        {
            JSON_Object json = new JSON_Object("error", null); //Se inicializa con error y null para ver si hay algun error.

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

        [HttpPut("mod_payroll")]
        public async Task<ActionResult<JSON_Object>> ModPayroll(Payroll payroll_data)
        {
            JSON_Object json = new JSON_Object("error", null); //Se inicializa con error y null para ver si hay algun error.

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
