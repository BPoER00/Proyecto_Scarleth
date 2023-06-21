using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using app.Models;
using app.helpers;
using app.actions.etnias;

namespace app.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EtniasController : ControllerBase
    {
        private EtniasAction action;
        public EtniasController(ConexionContext _db)
        {
            this.action = new EtniasAction(_db);
        }

        [HttpGet("Get")]
        public async Task<Reply> Get()
        {
            try
            {
                return new Reply{
                    code = 1,
                    data = await this.action.obtener(),
                    message = "Etnias obtenidas Correctamente"
                };
            }
            catch(Exception e)
            {
                return new Reply{
                    code = 0,
                    data = null,
                    message = $"No se pudieron obtener las etnias | Error{e.Message}"
                };
            }
        }

        [HttpPost("Post")]
        public async Task<Reply> Post(Etnia etnia)
        {
            try
            {
                if(!ModelState.IsValid)
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
                    return new Reply{
                        code = 1,
                        data = await this.action.guardar(etnia),
                        message = "Etnia Guardada Correctamente"
                    };
                }
            }
            catch(Exception e)
            {
                return new Reply{
                    code = 0,
                    data = null,
                    message = $"No se pudo guardar la Etnia | Error{e.Message}"
                };
            }
        }
    }
}