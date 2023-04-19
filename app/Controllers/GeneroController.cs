using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using app.Models;
using app.actions.generos;
using app.helpers;

namespace app.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GeneroController : ControllerBase
    {
        private GenerosAction action;

        public GeneroController(ConexionContext _db)
        {
            this.action = new GenerosAction(_db);
        }

        [HttpGet("Get")]
        public async Task<Reply> Get()
        {
            try
            {
                return new Reply{
                    code = 1,
                    data = await this.action.obtener(),
                    message = "Generos obtenidos Correctamente"
                };
            }
            catch(Exception e)
            {
                return new Reply{
                    code = 0,
                    data = null,
                    message = $"No se pudieron obtener los generos | Error{e.Message}"
                };
            }
        }

        [HttpPost("Post")]
        public async Task<Reply> Post(Genero genero)
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
                        data = await this.action.guardar(genero),
                        message = "Genero Guardado Correctamente"
                    };
                }
            }
            catch(Exception e)
            {
                return new Reply{
                    code = 0,
                    data = null,
                    message = $"No se pudo guardar el Genero | Error{e.Message}"
                };
            }
        }
    }
}