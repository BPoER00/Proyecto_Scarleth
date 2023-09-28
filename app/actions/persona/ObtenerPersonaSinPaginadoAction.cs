using app.Models;
using Microsoft.EntityFrameworkCore;

namespace app.actions.persona
{
    public class ObtenerPersonaSinPaginadoAction
    {
        private ConexionContext db;

        public ObtenerPersonaSinPaginadoAction(ConexionContext _db)
        {
            this.db = _db;
        }

        public async Task<List<Persona>> ejecutar()
        {
            var lista = await this.db
            .Personas
            .Where(x => x.estado == Persona.ACTIVO)
            .ToListAsync();

            return lista;
        }
    }
}