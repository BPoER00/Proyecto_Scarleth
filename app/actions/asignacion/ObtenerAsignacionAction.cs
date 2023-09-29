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

        public async Task<Object[]> ejecutar(int tp, int np, string personaId, string cargoId)
        {

            int persona_id = int.Parse(personaId);
            int cargo_id = int.Parse(cargoId);

            var lista = await this.db
            .Asignacions
            .Where(x => x.estado == Asignacion.ACTIVO)
            .Include(x => x.Cargo)
            .Include(x => x.Persona)
            .ToListAsync();

            if (persona_id > 0)
            {
                lista = lista.Where(x => x.persona_id == persona_id).ToList();
            }

            if (cargo_id > 0)
            {
                lista = lista.Where(x => x.cargo_id == cargo_id).ToList();
            }

            int totalObjects = lista.Count();
            int[] paginate = this.pd.paginateData(tp, np, totalObjects);
            var listaFiltros = lista.Skip(paginate[0]).Take(paginate[1]).ToList();

            return new Object[] { listaFiltros, np, tp, paginate[2] };
        }
    }
}