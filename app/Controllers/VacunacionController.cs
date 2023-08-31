using Microsoft.AspNetCore.Mvc;
using app.Models;
using app.helpers;
using app.actions.vacunacion;
using app.middlewares;

namespace app.Controllers
{
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
        public async Task<IActionResult> Get([FromQuery] int pagina, [FromQuery] int objetos)
        {
            try
            {
                var resultAction = await this.action.obtener(objetos, pagina);

                List<Vacuna> data = (List<Vacuna>)resultAction[0];

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
    }
}