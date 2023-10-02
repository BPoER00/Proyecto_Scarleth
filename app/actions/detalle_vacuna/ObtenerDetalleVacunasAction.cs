using Microsoft.EntityFrameworkCore;
using app.Models;
using app.helpers;

namespace app.actions.detalle_vacuna
{
    public class ObtenerDetalleVacunasAction
    {
        private ConexionContext db;
        private PaginateData pd;

        public ObtenerDetalleVacunasAction(ConexionContext _db)
        {
            this.db = _db;
            this.pd = new PaginateData();
        }

        public async Task<Object[]> ejecutar(int tp, int np, string idVacuna)
        {
            int vacuna_id = int.Parse(idVacuna);

            var lista = await this.db
            .Detalle_Vacunas
            .Include(x => x.Vacuna)
            .ToListAsync();

            if (vacuna_id > 0)
            {
                lista = lista.Where(x => x.vacuna_id == vacuna_id).ToList();
            }

            int totalObjects = lista.Count();

            int[] paginate = this.pd.paginateData(tp, np, totalObjects);

            var listaResult = lista
                                .Skip(paginate[0])
                                .Take(paginate[1])
                                .ToList();

            return new Object[] { listaResult, np, tp, paginate[2] };
        }
    }
}