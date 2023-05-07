using GymTEC_API.Entidades;
using GymTEC_API.Resources;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;


namespace GymTEC_API.Controllers
{
    [ApiController]
    [Route("api")]
    public class SignUp : ControllerBase
    {
        /// <summary>
        /// Method that signs up a client.
        /// </summary>
        /// <param name="nuevo_cliente">All client information to add to the database.</param>
        /// <returns>A confimation note or an error.</returns>
        /// <remarks>This method queries a database to delete employee.</remarks>
        [HttpPost("add_client")]
        public async Task<ActionResult<JSON_Object>> add_client(Client nuevo_cliente) {

            nuevo_cliente.Password = MD5Encrypt.EncryptPassword(nuevo_cliente.Password);

            JSON_Object json = new JSON_Object("okay", nuevo_cliente);

            bool var = DBData.ExecuteAddClient(nuevo_cliente);
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

        [HttpPost("add_employee")]
        public async Task<ActionResult<JSON_Object>> add_employee(Employee nuevo_empleado)
        {
            nuevo_empleado.Employee_Password = MD5Encrypt.EncryptPassword(nuevo_empleado.Employee_Password);

            JSON_Object json = new JSON_Object("okay", nuevo_empleado);

            bool var = DBData.ExecuteAddEmployee(nuevo_empleado);
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
