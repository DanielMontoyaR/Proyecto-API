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
        public async Task<ActionResult<JSON_Object>> AuthEmployee([FromQuery] Credenciales employee_credentials)
        {
            JSON_Object json = new JSON_Object("error", null); //Se inicializa con error y null para ver si hay algun error.
            Empleado informacion_empleado = new Empleado();
            informacion_empleado.Cedula_Empleado = employee_credentials.Cedula;
            informacion_empleado.Contraseña = employee_credentials.Password;
            informacion_empleado.P_Nombre = "Max";
            informacion_empleado.Apellido1 = "G";
            informacion_empleado.Apellido2 = "M";
            json.status = "ok";
            json.result = informacion_empleado;
            return Ok(json);
        }
    }
}
