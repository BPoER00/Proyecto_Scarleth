using Microsoft.AspNetCore.Mvc;
using app.helpers;
using app.Models;
using app.actions.usuario;
using app.Models.ModelView;
using app.middlewares;
using Microsoft.AspNetCore.Authorization;

namespace app.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        //variable principal para la conexion de cada uno
        private UsuarioActions action;
        private UsuarioValidation validation;
        private VerifyRepeatData<Usuario> verify;

        public UsuarioController()
        {
            this.action = new UsuarioActions();
            this.validation = new UsuarioValidation();
            this.verify = new VerifyRepeatData<Usuario>();

        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get([FromQuery] int pagina, [FromQuery] int objetos, [FromQuery] string usuarioId, [FromQuery] string rolId)
        {
            try
            {
                var resultAction = await this.action.obtener(objetos, pagina, usuarioId, rolId);

                List<UsuarioInfo> data = (List<UsuarioInfo>)resultAction[0];

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

        [HttpGet("GetSP")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var resultAction = await this.action.obtenerSP();

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
        public async Task<IActionResult> Post(Usuario usuario)
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
                    if (await verify.IsDataDuplicated("nombre_usuario", usuario.nombre_usuario))
                        return BadRequest(
                                new ReturnClassDefault()
                                .returnDataDefault(Reply.FAIL, Reply.DATA_FAIL, new ErrorHelperMessage()
                                .ErrorMessages(usuario.nombre_usuario, ErrorHelperMessage.DEFAULT_VALUE, ErrorHelperMessage.REPETIDO)));

                    if (await verify.IsDataDuplicated("persona_id", usuario.persona_id))
                        return BadRequest(
                                new ReturnClassDefault()
                                .returnDataDefault(Reply.FAIL, Reply.DATA_FAIL, new ErrorHelperMessage()
                                .ErrorMessages($"{usuario.persona_id}", ErrorHelperMessage.DEFAULT_VALUE, ErrorHelperMessage.REPETIDO)));

                    if (await verify.IsDataDuplicated("correo", usuario.correo))
                        return BadRequest(
                                new ReturnClassDefault()
                                .returnDataDefault(Reply.FAIL, Reply.DATA_FAIL, new ErrorHelperMessage()
                                .ErrorMessages(usuario.correo, ErrorHelperMessage.DEFAULT_VALUE, ErrorHelperMessage.REPETIDO)));

                    if (!await validation.validatePersona(usuario.persona_id))
                        return BadRequest(
                            new ReturnClassDefault()
                            .returnDataDefault(Reply.FAIL, Reply.DATA_FAIL, new ErrorHelperMessage()
                            .ErrorMessages("Persona", ErrorHelperMessage.DEFAULT_VALUE, ErrorHelperMessage.NOT_FOUND)));

                    if (!await validation.validateRol(usuario.rol_id))
                        return BadRequest(
                            new ReturnClassDefault()
                            .returnDataDefault(Reply.FAIL, Reply.DATA_FAIL, new ErrorHelperMessage()
                            .ErrorMessages("Rol", ErrorHelperMessage.DEFAULT_VALUE, ErrorHelperMessage.NOT_FOUND)));

                    var result = await this.action.guardar(usuario);

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