using Microsoft.AspNetCore.Mvc;
using app.Models;
using app.helpers;
using app.actions.vacunacion;
using app.middlewares;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;

namespace app.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class VacunacionController : ControllerBase
    {
        //variable principal para la conexion de cada uno
        private VacunacionesActions action;
        private VacunacionValidation validation;

        public VacunacionController()
        {
            this.action = new VacunacionesActions();
            this.validation = new VacunacionValidation();

        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get([FromQuery] int pagina, [FromQuery] int objetos, [FromQuery] string personaId, [FromQuery] string fechaInicioValue, [FromQuery] string fechaFinValue, [FromQuery] string vacunaId)
        {
            try
            {
                var resultAction = await this.action.obtener(objetos, pagina, personaId, fechaInicioValue, fechaFinValue, vacunaId);

                List<Vacunacion> data = (List<Vacunacion>)resultAction[0];

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
        public async Task<IActionResult> Post(VacunacionDetalles vacuncion)
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

                    if (await validation.ValidatePersonaAsignacionAsync(vacuncion.persona_id, vacuncion.asignacion_id))
                        return BadRequest(
                            new ReturnClassDefault()
                            .returnDataDefault(Reply.FAIL, Reply.DATA_FAIL, new ErrorHelperMessage()
                            .ErrorMessages("Persona/Asignacion", ErrorHelperMessage.DEFAULT_VALUE, ErrorHelperMessage.MISMA_PERSONA)));

                    if (!await validation.validateAsignacion(vacuncion.asignacion_id))
                        return BadRequest(
                            new ReturnClassDefault()
                            .returnDataDefault(Reply.FAIL, Reply.DATA_FAIL, new ErrorHelperMessage()
                            .ErrorMessages("Asignacion", ErrorHelperMessage.DEFAULT_VALUE, ErrorHelperMessage.NOT_FOUND)));

                    if (!await validation.validatePersona(vacuncion.persona_id))
                        return BadRequest(
                            new ReturnClassDefault()
                            .returnDataDefault(Reply.FAIL, Reply.DATA_FAIL, new ErrorHelperMessage()
                            .ErrorMessages("Persona", ErrorHelperMessage.DEFAULT_VALUE, ErrorHelperMessage.NOT_FOUND)));

                    if (!await validation.validateVacuna(vacuncion.vacuna_id))
                        return BadRequest(
                            new ReturnClassDefault()
                            .returnDataDefault(Reply.FAIL, Reply.DATA_FAIL, new ErrorHelperMessage()
                            .ErrorMessages("Vacuna", ErrorHelperMessage.DEFAULT_VALUE, ErrorHelperMessage.NOT_FOUND)));

                    if (!await validation.ValidatePersonaFinishDosisAsync(vacuncion.persona_id, vacuncion.vacuna_id))
                        return BadRequest(
                            new ReturnClassDefault()
                            .returnDataDefault(Reply.FAIL, Reply.DATA_FAIL, new ErrorHelperMessage()
                            .ErrorMessages("Ya existe un registro iniciado", ErrorHelperMessage.DEFAULT_VALUE, ErrorHelperMessage.REGISTRO_EXISTENTE)));

                    if (!await validation.validateRegistroDetalleVacunacion(vacuncion.vacuna_id, vacuncion.dosis))
                        return BadRequest(
                            new ReturnClassDefault()
                            .returnDataDefault(Reply.FAIL, Reply.DATA_FAIL, new ErrorHelperMessage()
                            .ErrorMessages("Vacunacion", ErrorHelperMessage.DEFAULT_VALUE, ErrorHelperMessage.SUPERA)));

                    if (!await validation.validateVacunas0(vacuncion.vacuna_id, vacuncion.dosis))
                        return BadRequest(
                            new ReturnClassDefault()
                            .returnDataDefault(Reply.FAIL, Reply.DATA_FAIL, new ErrorHelperMessage()
                            .ErrorMessages("Vacunacion", ErrorHelperMessage.DEFAULT_VALUE, ErrorHelperMessage.NO_ALCANZA)));


                    var result = await this.action.guardar(vacuncion);

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