using app.Models;
using Microsoft.EntityFrameworkCore;

namespace app.actions.asignacion
{
    public class ObtenerAsignacionSinPaginadoAction
    {
        private ConexionContext db;

        public ObtenerAsignacionSinPaginadoAction(ConexionContext _db)
        {
            this.db = _db;
        }

        public async Task<List<Asignacion>> ejecutar()
        {
            var lista = await this.db
            .Asignacions
            .Include(x => x.Persona)
            .Where(x => x.estado == Asignacion.ACTIVO)
            .ToListAsync();

            return lista;
        }
    }
}