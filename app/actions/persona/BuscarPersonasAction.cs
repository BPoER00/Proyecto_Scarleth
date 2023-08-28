using app.Models;

namespace app.actions.persona
{
    public class BuscarPersonasAction
    {
        private ConexionContext db;

        public BuscarPersonasAction(ConexionContext _db)
        {
            this.db = _db;
        }

        public async Task<Persona> ejecutar(int id)
        {
            var lista = await this.db.Personas
                        .FindAsync(id);

            return lista;
        }
    }
}