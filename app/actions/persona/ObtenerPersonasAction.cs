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

        public async Task<Object[]> ejecutar(int tp, int np, string personaId, string direccionId, string generoId)
        {

            int persona_id = int.Parse(personaId);
            int direccion_id = int.Parse(direccionId);
            int genero_id = int.Parse(generoId);

            var lista = await this.db
            .Personas
            .Where(x => x.estado == Persona.ACTIVO)
            .Include(x => x.Genero)
            .Include(x => x.Direccion)
            .ToListAsync();

            if (persona_id > 0)
            {
                lista = lista.Where(x => x.id == persona_id).ToList();
            }

            if (direccion_id > 0)
            {
                lista = lista.Where(x => x.direccion_id == direccion_id).ToList();
            }

            if (genero_id > 0)
            {
                lista = lista.Where(x => x.genero_id == genero_id).ToList();
            }

            int totalObjects = lista.Count();
            int[] paginate = this.pd.paginateData(tp, np, totalObjects);
            var listaFiltros = lista.Skip(paginate[0]).Take(paginate[1]).ToList();

            return new Object[] { listaFiltros, np, tp, paginate[2] };
        }
    }
}