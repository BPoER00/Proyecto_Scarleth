using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using app.Models;
using app.actions.pacientes;
using app.helpers;

namespace app.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacientesController : ControllerBase
    {
        //variable principal para la conexion de cada uno
        private PacientesAction action; 

        public PacientesController(ConexionContext _db)
        {
            this.action = new PacientesAction(_db);
        }

        [HttpGet("Get")]
        public async Task<Reply> Get()
        {
            try
            {
                return new Reply{
                    code = 1,
                    data = await this.action.obtener(),
                    message = "Pacientes Obtenidos Correctamente"
                };
            }
            catch(Exception e)
            {
                return new Reply{
                    code = 0,
                    data = null,
                    message = $"No se pudieron Obtener Pacientes | Error{e.Message}"
                };
            }
        }

        [HttpPost("Post")]
        public async Task<Reply> Post(Paciente paciente)
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
                        data = await this.action.guardar(paciente),
                        message = "Paciente Guardado Correctamente"
                    };
                }
            }
            catch(Exception e)
            {
                return new Reply{
                    code = 0,
                    data = null,
                    message = $"No se pudo guardar Paciente | Error{e.Message}"
                };
            }
        }

    }
}