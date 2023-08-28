using app.Models;

namespace app.actions.vacunacion
{
    public class BuscarVacunacionesAction
    {
        private ConexionContext db;

        public BuscarVacunacionesAction(ConexionContext _db)
        {
            this.db = _db;
        }

        public async Task<Vacunacion> ejecutar(int id)
        {
            var lista = await this.db.Vacunacions
                        .FindAsync(id);

            return lista;
        }
    }
}