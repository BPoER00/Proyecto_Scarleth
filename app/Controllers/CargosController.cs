using app.actions.cargos;
using app.helpers;
using app.Models;
using Microsoft.AspNetCore.Mvc;

namespace app.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CargosController : ControllerBase
    {
        private CargosAction action;
        public CargosController()
        {
            this.action = new CargosAction();
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get([FromQuery] int pagina, [FromQuery] int objetos)
        {
            try
            {
                var resultAction = await this.action.obtener(objetos, pagina);

                List<Cargo> data = (List<Cargo>)resultAction[0];
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
                            message = data.Count == 0 ? "Cargos obtenidas Correctamente Pero No Se Encontro Ningun Dato" : "Cargos obtenidas Correctamente",
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
                            message = resultAction == null ? "Cargo obtenido Correctamente Pero No Se Encontro Ningun Dato" : "Cargo Obtenido Correctamente",
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
        public async Task<IActionResult> Post(Cargo cargo)
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
                                code = 1,
                                data = await this.action.guardar(cargo),
                                message = "Cargo Guardada Correctamente"
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