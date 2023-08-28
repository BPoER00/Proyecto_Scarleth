using app.Models;
using app.helpers;
using Microsoft.EntityFrameworkCore;

namespace app.actions.vacuna
{
    public class ObtenerVacunaAction
    {
        private ConexionContext db;
        private PaginateData pd;

        public ObtenerVacunaAction(ConexionContext _db)
        {
            this.db = _db;
            this.pd = new PaginateData();
        }

        public async Task<Object[]> ejecutar(int tp, int np)
        {
            int totalObjects = this.db.Vacunas.Count();

            int[] paginate = this.pd.paginateData(tp, np, totalObjects);
            var lista = await this.db
            .Vacunas
            .Where(x => x.estado == Vacuna.ACTIVO)
            .Skip(paginate[0])
            .Take(paginate[1])
            .ToListAsync();

            return new Object[] { lista, np, tp, paginate[2] };
        }
    }
}