using app.actions.persona;
using app.Models;

namespace app.middlewares
{
    public class UsuarioValidation
    {
        private PersonasActions personasActions;
        private ConexionContext db;
        public UsuarioValidation()
        {
            this.personasActions = new PersonasActions();
            this.db = new ConexionContext();
        }

        public async Task<Boolean> validatePersona(int id)
        {
            var result = await this.personasActions.buscar(id);
            return result != null;
        }

        public async Task<Boolean> validateRol(int id)
        {
            var result = await db.Rols.FindAsync(id);
            return result != null;
        }
    }
}