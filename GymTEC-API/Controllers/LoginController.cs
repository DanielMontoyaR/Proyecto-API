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
            informacion_empleado.Cedula_Empleado = "123";
            informacion_empleado.Contraseña = "123";

            if (employee_credentials.Cedula == informacion_empleado.Cedula_Empleado && employee_credentials.Password == informacion_empleado.Contraseña) {
                informacion_empleado.P_Nombre = "Max";
                informacion_empleado.Apellido1 = "G";
                informacion_empleado.Apellido2 = "M";
                json.status = "ok";
                json.result = informacion_empleado;
                return Ok(json);
            }
            return json;

        }
        [HttpGet("auth_cliente")]
        public async Task<ActionResult<JSON_Object>> AuthCliente([FromQuery] Credenciales client_credentials)
        {
            JSON_Object json = new JSON_Object("error", null); //Se inicializa con error y null para ver si hay algun error.
            Cliente informacion_cliente = new Cliente();
            informacion_cliente.Cedula_cliente = "123";
            informacion_cliente.Password = "123";

            if (client_credentials.Cedula == informacion_cliente.Cedula_cliente && client_credentials.Password == informacion_cliente.Password)
            {
                informacion_cliente.Nombre = "Daniel";
                informacion_cliente.Apellido1 = "M";
                informacion_cliente.Apellido2 = "R";
                json.status = "ok";
                json.result = informacion_cliente;
                return Ok(json);
            }
            return json;

        }
    }
}
