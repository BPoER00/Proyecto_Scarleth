using Microsoft.AspNetCore.Mvc;
using app.Models;
using app.helpers;
using app.actions.vacunacion;

namespace app.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VacunacionController : ControllerBase
    {
        //variable principal para la conexion de cada uno
        private VacunacionesActions action;

        public VacunacionController()
        {
            this.action = new VacunacionesActions();
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get([FromQuery] int pagina, [FromQuery] int objetos)
        {
            try
            {
                var resultAction = await this.action.obtener(objetos, pagina);

                List<Vacuna> data = (List<Vacuna>)resultAction[0];
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
                            message = data.Count == 0 ? "Vacunaciones Obtenidas Correctamente Pero No Se Encontro Ningun Dato" : "Vacunaciones obtenidas Correctamente",
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
                            message = resultAction == null ? "Vacunacion obtenida Correctamente Pero No Se Encontro Ningun Dato" : "Vacunacion Obtenida Correctamente",
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
    }
}