using Microsoft.AspNetCore.Mvc;
using app.helpers;
using app.Models;
using app.actions.persona;

namespace app.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonaController : ControllerBase
    {
        //variable principal para la conexion de cada uno
        private PersonasActions action;

        public PersonaController()
        {
            this.action = new PersonasActions();
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get([FromQuery] int pagina, [FromQuery] int objetos)
        {
            try
            {
                var resultAction = await this.action.obtener(objetos, pagina);

                List<Persona> data = (List<Persona>)resultAction[0];
                return Ok(
                    new PaginateReturn
                    {
                        pages = (int)resultAction[3],
                        objects_page = (int)resultAction[2],
                        current_page = (int)resultAction[1],
                        records = new Reply
                        {
                            code = Reply.SUCCESSFULL,
                            data = data,
                            message = data.Count == 0 ? "Personas Obtenidas Correctamente Pero No Se Encontro Ningun Dato" : "Personas obtenidas Correctamente",
                        }
                    }
                );
            }
            catch (Exception e)
            {
                return StatusCode(500,
                    new
                    {
                        records = new Reply
                        {
                            code = Reply.FAIL,
                            data = null,
                            message = $"Error: {e.Message}",
                        }
                    }
                );
            }
        }

        [HttpGet("Get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var resultAction = await this.action.buscar(id);

                return Ok(
                    new
                    {
                        records = new Reply
                        {
                            code = Reply.SUCCESSFULL,
                            data = resultAction,
                            message = resultAction == null ? "Persona obtenida Correctamente Pero No Se Encontro Ningun Dato" : "Persona Obtenida Correctamente",
                        }
                    }
                );
            }
            catch (Exception e)
            {
                return StatusCode(500,
                    new
                    {
                        record = new Reply
                        {
                            code = Reply.FAIL,
                            data = null,
                            message = $"Error: {e.Message}",
                        }
                    }
                );
            }
        }

        [HttpPost("Post")]
        public async Task<IActionResult> Post(Persona persona)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(
                        new
                        {
                            records = new Reply
                            {
                                code = Reply.FAIL,
                                data = ErrorValidationHelper.GetModelStateErrors(ModelState),
                                message = "Campos invalidos"
                            }
                        }
                    );
                }
                else
                {
                    return StatusCode(201,
                        new
                        {
                            records = new Reply
                            {
                                code = Reply.SUCCESSFULL,
                                data = await this.action.guardar(persona),
                                message = "Persona Guardada Correctamente"
                            }
                        }
                    );
                }
            }
            catch (Exception e)
            {
                return StatusCode(500,
                    new
                    {
                        record = new Reply
                        {
                            code = Reply.FAIL,
                            data = null,
                            message = $"Error: {e.Message}",
                        }
                    }
                );
            }
        }
    }
}