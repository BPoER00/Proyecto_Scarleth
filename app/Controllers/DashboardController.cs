using Microsoft.AspNetCore.Mvc;
using app.Models;
using app.actions.generos;
using app.helpers;
using Microsoft.AspNetCore.Authorization;
using app.actions.vacunacion;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;

namespace app.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class DashboardController : ControllerBase
    {
        private ConexionContext _db;
        private DateTime fechaHoy = DateTime.Now.Date;

        public DashboardController()
        {
            this._db = new DbContextConection().context();
        }

        [HttpGet("Get/Cuadros")]
        public async Task<IActionResult> GetCuadros()
        {
            try
            {
                var resultVacunacionHoy = await this._db.Detalle_Vacunacions
                .Where(x => x.fecha_vacunacion == fechaHoy).CountAsync();

                var resultVacunasInventario = await this._db.Vacunas.SumAsync(x => x.unidades);

                var resultMedicosActivos = await this._db.Asignacions.Where(x => x.estado == Asignacion.ACTIVO).CountAsync();

                var resultVacunacionTotal = await this._db.Vacunacions.SumAsync(x => x.dosis);

                var resultAction = new
                {
                    VacunacionHoy = resultVacunacionHoy,
                    VacunasInventario = resultVacunasInventario,
                    AsignacionesActivas = resultMedicosActivos,
                    VacunacionTotal = resultVacunacionTotal,
                };


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

        [HttpGet("Get/Grafica/1")]
        public async Task<IActionResult> GetGrafica1(int id)
        {
            try
            {
                var resultAction = await this._db.Vacunas
                    .GroupBy(x => x.nombre)
                    .Select(Group => new
                    {
                        Nombre = Group.Key,
                        Total = Group.Sum(x => x.unidades)
                    })
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

        [HttpGet("Get/Grafica/2")]
        public async Task<IActionResult> GetGrafica2(int id)
        {
            try
            {
                var resultAction = await this._db.Detalle_Vacunacions
                    .Where(x => x.fecha_vacunacion == fechaHoy)
                    .GroupBy(x => x.Vacunacion.Vacuna.nombre)
                    .Select(Group => new
                    {
                        Nombre = Group.Key,
                        Total = Group.Sum(x => x.dosis)
                    })
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