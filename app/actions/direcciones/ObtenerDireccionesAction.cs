using Microsoft.EntityFrameworkCore;
using app.Models;
using app.helpers;
namespace app.actions.direcciones
{
    public class ObtenerDireccionesAction
    {
        private ConexionContext db;
        private PaginateData pd;

        public ObtenerDireccionesAction(ConexionContext _db)
        {
            this.db = _db;
            this.pd = new PaginateData();
        }

        public async Task<List<Direccion>> ejecutar(int tp, int np)
        {
            int[] paginate = this.pd.paginateData(tp, np);

            var lista = await this.db
            .Direccions
            .Where(x => x.estado == Direccion.ACTIVO)
            .Skip(paginate[0])
            .Take(paginate[1])
            .ToListAsync();

            return lista;
        }

    }
}