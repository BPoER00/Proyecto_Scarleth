using Microsoft.AspNetCore.Mvc;
using app.Models;
using app.helpers;
using app.actions.detalle_vacunacion;
using app.middlewares;
using Microsoft.AspNetCore.Authorization;

namespace app.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class DetalleVacunacionController : ControllerBase
    {
        //variable principal para la conexion de cada uno
        private DetalleVacunacionActions action;
        private DetalleVacunacionValidation validation;

        public DetalleVacunacionController()
        {
            this.action = new DetalleVacunacionActions();
            this.validation = new DetalleVacunacionValidation();

        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get([FromQuery] int pagina, [FromQuery] int objetos, [FromQuery] string idPersona)
        {
            try
            {
                Console.WriteLine(idPersona);
                var resultAction = await this.action.obtener(objetos, pagina, idPersona);

                List<Detalle_Vacunacion> data = (List<Detalle_Vacunacion>)resultAction[0];

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
        public async Task<IActionResult> Post(Detalle_Vacunacion detalle_Vacunacion)
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
                    if (!await validation.validateVacunacion(detalle_Vacunacion.vacunacion_id))
                        return BadRequest(
                            new ReturnClassDefault()
                            .returnDataDefault(Reply.FAIL, Reply.DATA_FAIL, new ErrorHelperMessage()
                            .ErrorMessages("Vacunacion", ErrorHelperMessage.DEFAULT_VALUE, ErrorHelperMessage.NOT_FOUND)));

                    if (!await validation.validateAsignacion(detalle_Vacunacion.asignacion_id))
                        return BadRequest(
                            new ReturnClassDefault()
                            .returnDataDefault(Reply.FAIL, Reply.DATA_FAIL, new ErrorHelperMessage()
                            .ErrorMessages("Medico", ErrorHelperMessage.DEFAULT_VALUE, ErrorHelperMessage.NOT_FOUND)));

                    if (!await validation.validateRegistroDetalleVacunacion(detalle_Vacunacion.vacunacion_id, detalle_Vacunacion.dosis))
                        return BadRequest(
                            new ReturnClassDefault()
                            .returnDataDefault(Reply.FAIL, Reply.DATA_FAIL, new ErrorHelperMessage()
                            .ErrorMessages("Vacunacion", ErrorHelperMessage.DEFAULT_VALUE, ErrorHelperMessage.NO_GUARDADO)));

                    var result = await this.action.guardar(detalle_Vacunacion);

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