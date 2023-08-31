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
                    new ReturnClassDefault().returnDataPaginate(
                        resultAction,
                        Reply.SUCCESSFULL,
                        data,
                        new ErrorHelperMessage().ErrorMessages(
                                ErrorHelperMessage.DEFAULT_VALUE,
                                ErrorHelperMessage.DEFAULT_VALUE,
                                ErrorHelperMessage.OBTENIDO
                                )
                    )
                );
            }
            catch (Exception e)
            {
                return StatusCode(500,
                    new ReturnClassDefault()
                        .returnDataDefault(
                        Reply.FAIL,
                        Reply.DATA_FAIL,
                        $"Error: {e.Message}"
                        )
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
                        new ReturnClassDefault()
                        .returnDataDefault
                        (
                            Reply.FAIL,
                            ErrorValidationHelper.GetModelStateErrors(ModelState),
                            new ErrorHelperMessage().ErrorMessages(
                                ErrorHelperMessage.DEFAULT_VALUE,
                                ErrorHelperMessage.DEFAULT_VALUE,
                                ErrorHelperMessage.INVALIDO
                                )
                        )
                    );
                }
                else
                {
                    var result = await this.action.guardar(detalle_Vacuna);

                    return StatusCode(201,
                        new ReturnClassDefault()
                        .returnDataDefault(result ? Reply.SUCCESSFULL : Reply.FAIL,
                        result,
                        new ErrorHelperMessage()
                            .ErrorMessages(
                                    ErrorHelperMessage.DEFAULT_VALUE,
                                    ErrorHelperMessage.DEFAULT_VALUE,
                                    result ? ErrorHelperMessage.GUARDADO : ErrorHelperMessage.NO_GUARDADO
                                    )
                        )
                    );
                }
            }
            catch (Exception e)
            {
                return StatusCode(500,
                    new ReturnClassDefault()
                        .returnDataDefault(
                        Reply.FAIL,
                        Reply.DATA_FAIL,
                        $"Error: {e.Message}"
                        )
                );
            }
        }
    }
}