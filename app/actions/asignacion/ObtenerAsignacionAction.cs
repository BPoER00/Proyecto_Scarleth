using app.helpers;
using app.Models;
using Microsoft.EntityFrameworkCore;

namespace app.actions.asignacion
{
    public class ObtenerAsignacionAction
    {
        private ConexionContext db;
        private PaginateData pd;

        public ObtenerAsignacionAction(ConexionContext _db)
        {
            this.db = _db;
            this.pd = new PaginateData();
        }

        public async Task<Object[]> ejecutar(int tp, int np)
        {
            int totalObjects = this.db.Asignacions.Count();

            int[] paginate = this.pd.paginateData(tp, np, totalObjects);
            var lista = await this.db
            .Asignacions
            .Where(x => x.estado == Asignacion.ACTIVO)
            .Include(x => x.Cargo)
            .Include(x => x.Persona)
            .Skip(paginate[0])
            .Take(paginate[1])
            .ToListAsync();

            return new Object[] { lista, np, tp, paginate[2] };
        }
    }
}