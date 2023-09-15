using Microsoft.EntityFrameworkCore;
using app.Models;
namespace app.actions.direcciones
{
    public class ObtenerDireccionesAction
    {
        private ConexionContext db;

        public ObtenerDireccionesAction(ConexionContext _db)
        {
            this.db = _db;
        }

        public async Task<List<Direccion>> ejecutar()
        {
            var lista = await this.db
            .Direccions
            .Where(x => x.estado == Direccion.ACTIVO)
            .ToListAsync();

            return lista;
        }

    }
}