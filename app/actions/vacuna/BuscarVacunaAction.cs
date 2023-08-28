using app.Models;

namespace app.actions.vacuna
{
    public class BuscarVacunaAction
    {
        private ConexionContext db;

        public BuscarVacunaAction(ConexionContext _db)
        {
            this.db = _db;
        }

        public async Task<Vacuna> ejecutar(int id)
        {
            var lista = await this.db.Vacunas
                        .FindAsync(id);

            return lista;
        }
    }
}