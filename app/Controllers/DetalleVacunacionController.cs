using Microsoft.AspNetCore.Mvc;
using app.Models;
using app.helpers;
using app.actions.detalle_vacunacion;

namespace app.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DetalleVacunacionController : ControllerBase
    {
        //variable principal para la conexion de cada uno
        private DetalleVacunacionActions action; 

        public DetalleVacunacionController()
        {
            this.action = new DetalleVacunacionActions();
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get([FromQuery] int pagina, [FromQuery] int objetos)
        {
            try
            {
                var resultAction = await this.action.obtener(objetos, pagina);

                List<Detalle_Vacunacion> data = (List<Detalle_Vacunacion>)resultAction[0];
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
                            message = data.Count == 0 ? "Detalle Vacunaciones Obtenidas Correctamente Pero No Se Encontro Ningun Dato" : "Detalle Vacunaciones Obtenidas Correctamente",
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
        public async Task<IActionResult> Post(Detalle_Vacunacion detalle_Vacunacion)
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
                                data = await this.action.guardar(detalle_Vacunacion),
                                message = "Detalle Vacunacion Guardada Correctamente"
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