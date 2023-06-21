using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using app.Models;
using app.helpers;
using app.actions.medicos;

namespace app.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicosController : ControllerBase
    {
//variable principal para la conexion de cada uno
        private MedicosAction action; 

        public MedicosController(ConexionContext _db)
        {
            this.action = new MedicosAction(_db);
        }

        [HttpGet("Get")]
        public async Task<Reply> Get()
        {
            try
            {
                return new Reply{
                    code = 1,
                    data = await this.action.obtener(),
                    message = "Medicos Obtenidos Correctamente"
                };
            }
            catch(Exception e)
            {
                return new Reply{
                    code = 0,
                    data = null,
                    message = $"No se pudieron Obtener Medicos | Error{e.Message}"
                };
            }
        }

        [HttpGet("Get/{id}")]
        public async Task<Reply> Get(int? id)
        {
            try
            {
                return new Reply{
                    code = 1,
                    data = await this.action.obtener(id),
                    message = "Medico Obtenido Correctamente"
                };
            }
            catch(Exception e)
            {
                return new Reply{
                    code = 0,
                    data = null,
                    message = $"No se pudieron Obtener Medicos | Error{e.Message}"
                };
            }
        }

        [HttpPost("Post")]
        public async Task<Reply> Post(Medico medico)
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
                        data = await this.action.guardar(medico),
                        message = "Medico Guardado Correctamente"
                    };
                }
            }
            catch(Exception e)
            {
                return new Reply{
                    code = 0,
                    data = null,
                    message = $"No se pudo guardar Medico | Error{e.Message}"
                };
            }
        }
    }
}