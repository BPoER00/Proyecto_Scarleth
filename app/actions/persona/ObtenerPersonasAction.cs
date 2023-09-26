using app.Models;
using app.helpers;
using Microsoft.EntityFrameworkCore;

namespace app.actions.persona
{
    public class ObtenerPersonasAction
    {
        private ConexionContext db;
        private PaginateData pd;

        public ObtenerPersonasAction(ConexionContext _db)
        {
            this.db = _db;
            this.pd = new PaginateData();
        }

        public async Task<Object[]> ejecutar(int tp, int np)
        {
            int totalObjects = this.db.Personas.Count();

            int[] paginate = this.pd.paginateData(tp, np, totalObjects);
            var lista = await this.db
            .Personas
            .Where(x => x.estado == Persona.ACTIVO)
            .Include(x => x.Genero)
            .Include(x => x.Direccion)
            .Skip(paginate[0])
            .Take(paginate[1])
            .ToListAsync();

            return new Object[] { lista, np, tp, paginate[2] };
        }
    }
}