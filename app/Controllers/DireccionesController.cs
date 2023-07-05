using Microsoft.AspNetCore.Mvc;
using app.actions.direcciones;
using app.helpers;
using app.Models;

namespace app.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DireccionesController : ControllerBase
    {
        private DireccionesAction action;
        public DireccionesController()
        {
            this.action = new DireccionesAction();
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get([FromQuery]int pagina, [FromQuery] int objetos)
        {
            try
            {
                var resultAction = await this.action.obtener(pagina, objetos);

                return Accepted(
                    new Reply
                    {
                        code = resultAction.Count < 0 ? Reply.FAIL : Reply.SUCCESSFULL,
                        data = resultAction,
                        message = resultAction.Count < 0 ? "Direcciones obtenidas Correctamente Pero No Se Encontro Ningun Dato" : "Direcciones obtenidas Correctamente"
                    }
                );
            }
            catch (Exception e)
            {
                return StatusCode(
                    500,
                    $"Error: {e.Message}"
                );
            }
        }

        [HttpPost("Post")]
        public async Task<Reply> Post(Direccion direccion)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return new Reply
                    {
                        code = 400,
                        data = ErrorValidationHelper.GetModelStateErrors(ModelState),
                        message = "Campos invalidos"
                    };
                }
                else
                {
                    return new Reply
                    {
                        code = 1,
                        data = await this.action.guardar(direccion),
                        message = "Direccion Guardada Correctamente"
                    };
                }
            }
            catch (Exception e)
            {
                return new Reply
                {
                    code = 0,
                    data = null,
                    message = $"No se pudo guardar la Direccion | Error{e.Message}"
                };
            }
        }
    }
}