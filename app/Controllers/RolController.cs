using Microsoft.AspNetCore.Mvc;
using app.actions.direcciones;
using app.helpers;
using app.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace app.Controllers
{
    // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private ConexionContext _db = new DbContextConection().context();

        public RolController()
        {
            this._db = new DbContextConection().context();
        }

        [HttpGet("GetSP")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var resultAction = await this._db.Rols
                                    .Where(x => x.estado == Rol.ACTIVO)
                                    .ToListAsync();

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