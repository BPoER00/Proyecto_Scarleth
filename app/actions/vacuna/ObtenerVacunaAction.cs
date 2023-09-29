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

        public async Task<Object[]> ejecutar(int tp, int np, string vacunaId)
        {

            int vacuna_id = int.Parse(vacunaId);


            var lista = await this.db
            .Vacunas
            .Where(x => x.estado == Vacuna.ACTIVO)
            .ToListAsync();

            if (vacuna_id > 0)
            {
                lista = lista.Where(x => x.id == vacuna_id).ToList();
            }

            int totalObjects = lista.Count();
            int[] paginate = this.pd.paginateData(tp, np, totalObjects);
            var listaFiltros = lista.Skip(paginate[0]).Take(paginate[1]).ToList();

            return new Object[] { lista, np, tp, paginate[2] };
        }
    }
}