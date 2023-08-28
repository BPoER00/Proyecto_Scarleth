using Microsoft.AspNetCore.Mvc;
using app.Models;
using app.helpers;
using app.actions.detalle_vacuna;

namespace app.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DetalleVacunasController : ControllerBase
    {
        //variable principal para la conexion de cada uno
        private DetalleVacunasActions action;

        public DetalleVacunasController()
        {
            this.action = new DetalleVacunasActions();
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get([FromQuery] int pagina, [FromQuery] int objetos)
        {
            try
            {
                var resultAction = await this.action.obtener(objetos, pagina);

                List<Detalle_Vacuna> data = (List<Detalle_Vacuna>)resultAction[0];
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
                            message = data.Count == 0 ? "Detalle Vacunas Obtenidas Correctamente Pero No Se Encontro Ningun Dato" : "Detalle Vacunas Obtenidas Correctamente",
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

        [HttpPost("Post")]
        public async Task<IActionResult> Post(Detalle_Vacuna detalle_Vacuna)
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
                                data = await this.action.guardar(detalle_Vacuna),
                                message = "Detalle Vacuna Guardada Correctamente"
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