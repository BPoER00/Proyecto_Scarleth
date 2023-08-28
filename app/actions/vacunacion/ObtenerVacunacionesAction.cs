using app.Models;
using app.helpers;
using Microsoft.EntityFrameworkCore;

namespace app.actions.vacunacion
{
    public class ObtenerVacunacionesAction
    {
        private ConexionContext db;
        private PaginateData pd;

        public ObtenerVacunacionesAction(ConexionContext _db)
        {
            this.db = _db;
            this.pd = new PaginateData();
        }

        public async Task<Object[]> ejecutar(int tp, int np)
        {
            int totalObjects = this.db.Vacunacions.Count();

            int[] paginate = this.pd.paginateData(tp, np, totalObjects);
            var lista = await this.db
            .Vacunacions
            .Where(x => x.estado == Vacunacion.ACTIVO)
            .Skip(paginate[0])
            .Take(paginate[1])
            .ToListAsync();

            return new Object[] { lista, np, tp, paginate[2] };
        }
    }
}