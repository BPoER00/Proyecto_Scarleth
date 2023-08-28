using app.Models;

namespace app.actions.usuario
{
    public class BuscarUsuarioAction
    {
        private ConexionContext db;

        public BuscarUsuarioAction(ConexionContext _db)
        {
            this.db = _db;
        }

        public async Task<Usuario> ejecutar(int id)
        {
            var lista = await this.db.Usuarios
                        .FindAsync(id);

            return lista;
        }
    }
}