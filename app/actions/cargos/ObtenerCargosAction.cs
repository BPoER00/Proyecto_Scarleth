using app.helpers;
using app.Models;
using Microsoft.EntityFrameworkCore;

namespace app.actions.cargos
{
    public class ObtenerCargosAction
    {
        private ConexionContext db;
        private PaginateData pd;

        public ObtenerCargosAction(ConexionContext _db)
        {
            this.db = _db;
            this.pd = new PaginateData();

        }

        public async Task<Object[]> ejecutar(int tp, int np)
        {
            int totalObjects = this.db.Cargos.Count();

            int[] paginate = this.pd.paginateData(tp, np, totalObjects);
            var lista = await this.db
            .Cargos
            .Where(x => x.estado == Direccion.ACTIVO)
            .Skip(paginate[0])
            .Take(paginate[1])
            .ToListAsync();

            return new Object[] { lista, np, tp, paginate[2] };
        }
    }
}