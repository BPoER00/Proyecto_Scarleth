using Microsoft.AspNetCore.Mvc;
using app.Models;
using app.helpers;
using app.actions.medicos;

namespace app.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AsignacionController : ControllerBase
    {
        //variable principal para la conexion de cada uno
        private AsignacionAction action;

        public AsignacionController()
        {
            this.action = new AsignacionAction();
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get([FromQuery] int pagina, [FromQuery] int objetos)
        {
            try
            {
                var resultAction = await this.action.obtener(objetos, pagina);

                List<Asignacion> data = (List<Asignacion>)resultAction[0];

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

        [HttpGet("Get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                if (id <= 0) return BadRequest(
                    new ReturnClassDefault()
                    .returnDataDefault(
                        Reply.FAIL,
                        Reply.DATA_FAIL,
                        new ErrorHelperMessage().ErrorMessages(
                                "id",
                                ErrorHelperMessage.DEFAULT_VALUE,
                                ErrorHelperMessage.INVALIDO
                                )
                    )
                );

                var resultAction = await this.action.buscar(id);

                return Ok(
                    new ReturnClassDefault()
                        .returnDataDefault
                        (
                            Reply.SUCCESSFULL,
                            resultAction,
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
        public async Task<IActionResult> Post(Asignacion asignacion)
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

                    var result = await this.action.guardar(asignacion);

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