using Microsoft.AspNetCore.Mvc;
using GymTEC_API.Entidades;
using System.Net;

namespace GymTEC_API.Controllers

{
    [ApiController]
    [Route("api")]
    public class LoginController : ControllerBase
    {
        [HttpGet("auth_employee")]
        public async Task<ActionResult<JSON_Object>> AuthEmployee([FromQuery] Credentials employee_credentials)
        {
            JSON_Object json = new JSON_Object("error", null); //Se inicializa con error y null para ver si hay algun error.
            Employee informacion_empleado = new Employee();
            informacion_empleado.Employee_ID = "123";
            informacion_empleado.Employee_Password = "123";

            if (employee_credentials.ID_Credentials == informacion_empleado.Employee_ID && employee_credentials.Password == informacion_empleado.Employee_Password) {
                informacion_empleado.Employee_Fname = "Max";
                informacion_empleado.Employee_LName1 = "G";
                informacion_empleado.Employee_LName2 = "M";
                json.status = "ok";
                json.result = informacion_empleado;
                return Ok(json);
            }
            return json;

        }
        [HttpGet("auth_cliente")]
        public async Task<ActionResult<JSON_Object>> AuthCliente([FromQuery] Credentials client_credentials)
        {
            JSON_Object json = new JSON_Object("error", null); //Se inicializa con error y null para ver si hay algun error.
            Client informacion_cliente = new Client();
            informacion_cliente.ID_Client = "123";
            informacion_cliente.Password = "123";

            if (client_credentials.ID_Credentials == informacion_cliente.ID_Client && client_credentials.Password == informacion_cliente.Password)
            {
                informacion_cliente.FName1 = "Daniel";
                informacion_cliente.Last_name1 = "M";
                informacion_cliente.Last_name2 = "R";
                json.status = "ok";
                json.result = informacion_cliente;
                return Ok(json);
            }
            return json;

        }
    }
}
