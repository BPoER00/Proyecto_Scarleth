using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public DireccionesController(ConexionContext _db)
        {
            this.action = new DireccionesAction(_db);
        }

        [HttpGet("Get")]
        public async Task<Reply> Get()
        {
            try
            {
                return new Reply{
                    code = 1,
                    data = await this.action.obtener(),
                    message = "Direcciones obtenidas Correctamente"
                };
            }
            catch(Exception e)
            {
                return new Reply{
                    code = 0,
                    data = null,
                    message = $"No se pudieron obtener las Direcciones | Error{e.Message}"
                };
            }
        }

        [HttpPost("Post")]
        public async Task<Reply> Post(Direccion direccion)
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
                        data = await this.action.guardar(direccion),
                        message = "Direccion Guardada Correctamente"
                    };
                }
            }
            catch(Exception e)
            {
                return new Reply{
                    code = 0,
                    data = null,
                    message = $"No se pudo guardar la Direccion | Error{e.Message}"
                };
            }
        }
    }
}