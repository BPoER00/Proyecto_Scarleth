using Microsoft.EntityFrameworkCore;
using app.Models;
using app.helpers;

namespace app.actions.detalle_vacunacion
{
    public class ObtenerDetalleVacunacionAction
    {
        private ConexionContext db;
        private PaginateData pd;

        public ObtenerDetalleVacunacionAction(ConexionContext _db)
        {
            this.db = _db;
            this.pd = new PaginateData();
        }

        public async Task<Object[]> ejecutar(int tp, int np)
        {
            int totalObjects = this.db.Detalle_Vacunacions.Count();

            int[] paginate = this.pd.paginateData(tp, np, totalObjects);
            var lista = await this.db
            .Detalle_Vacunacions
            .Skip(paginate[0])
            .Take(paginate[1])
            .ToListAsync();

            return new Object[] { lista, np, tp, paginate[2] };
        }

    }
}
