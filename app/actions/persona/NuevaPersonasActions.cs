using app.Models;

namespace app.actions.persona
{
    public class NuevaPersonasActions
    {
        private ConexionContext db;

        public NuevaPersonasActions(ConexionContext _db)
        {
            this.db = _db;
        }
        public async Task<Boolean> ejecutar(Persona persona)
        {
            this.db.Personas.Add(persona);
            int result = await this.db.SaveChangesAsync();
            return result > 0 ? true : false;
        }
    }
}