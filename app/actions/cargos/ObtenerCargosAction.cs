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

        public async Task<Object[]> ejecutar(int tp, int np, string cargoId)
        {
            int cargo_id = int.Parse(cargoId);

            var lista = await this.db
            .Cargos
            .Where(x => x.estado == Cargo.ACTIVO)
            .ToListAsync();

            if (cargo_id > 0)
            {
                lista = lista.Where(x => x.id == cargo_id).ToList();
            }

            int totalObjects = lista.Count();
            int[] paginate = this.pd.paginateData(tp, np, totalObjects);
            var listaFiltros = lista.Skip(paginate[0]).Take(paginate[1]).ToList();

            return new Object[] { listaFiltros, np, tp, paginate[2] };
        }
    }
}