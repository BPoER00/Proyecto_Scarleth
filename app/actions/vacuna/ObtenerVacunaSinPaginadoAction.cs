using app.Models;
using app.helpers;
using Microsoft.EntityFrameworkCore;

namespace app.actions.vacuna
{
    public class ObtenerVacunaSinPaginadoAction
    {
        private ConexionContext db;

        public ObtenerVacunaSinPaginadoAction(ConexionContext _db)
        {
            this.db = _db;
        }

        public async Task<List<Vacuna>> ejecutar()
        {
            var lista = await this.db
            .Vacunas
            .Where(x => x.estado == Vacuna.ACTIVO)
            .ToListAsync();

            return lista;
        }
    }
}