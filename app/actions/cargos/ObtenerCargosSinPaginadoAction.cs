using app.Models;
using Microsoft.EntityFrameworkCore;

namespace app.actions.cargos
{
    public class ObtenerCargosSinPaginadoAction
    {
        private ConexionContext db;

        public ObtenerCargosSinPaginadoAction(ConexionContext _db)
        {
            this.db = _db;
        }

        public async Task<List<Cargo>> ejecutar()
        {
            var lista = await this.db
            .Cargos
            .Where(x => x.estado == Cargo.ACTIVO)
            .ToListAsync();

            return lista;
        }
    }
}