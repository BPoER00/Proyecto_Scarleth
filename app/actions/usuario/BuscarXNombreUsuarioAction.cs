using app.Models;
using Microsoft.EntityFrameworkCore;

namespace app.actions.usuario
{
    public class BuscarXNombreUsuarioAction
    {
        private ConexionContext db;

        public BuscarXNombreUsuarioAction(ConexionContext _db)
        {
            this.db = _db;
        }

        public async Task<Usuario> ejecutar(string nombre_usuario)
        {
            var lista = await this.db.Usuarios
                        .FirstOrDefaultAsync(u => u.nombre_usuario == nombre_usuario);

            return lista;
        }
    }
}