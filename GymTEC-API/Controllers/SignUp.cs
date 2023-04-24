using GymTEC_API.Entidades;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;


namespace GymTEC_API.Controllers
{
    [ApiController]
    [Route("api")]
    public class SignUp : ControllerBase
    {
        [HttpPost("add_client")]
        public async Task<ActionResult<JSON_Object>> add_client(Client nuevo_cliente) {
            JSON_Object json = new JSON_Object("okay", nuevo_cliente);

            return Ok(json);
        }

        [HttpPost("add_employee")]
        public async Task<ActionResult<JSON_Object>> add_employee(Client nuevo_empleado)
        {
            JSON_Object json = new JSON_Object("okay", nuevo_empleado);

            return Ok(json);
        }

    }
}
