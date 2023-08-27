using app.Models;
using Microsoft.EntityFrameworkCore;

namespace app.actions.medicos
{
    public class BuscarAsignacionAction
    {
        private ConexionContext db;

        public BuscarAsignacionAction(ConexionContext _db)
        {
            this.db = _db;
        }

        public async Task<Asignacion> ejecutar(int id)
        {
            var lista = await this.db.Asignacions
                        .FindAsync(id);

            return lista;
        }
    }
}