using app.Models;
using app.helpers;

namespace app.actions.usuario
{
    public class NuevoUsuarioAction
    {
        private ConexionContext db;
        private PasswordHasherService hash;

        public NuevoUsuarioAction(ConexionContext _db)
        {
            this.db = _db;
            this.hash = new PasswordHasherService();
        }
        public async Task<Boolean> ejecutar(Usuario usuario)
        {
            var newUsuario = new Usuario
            {
                persona_id = usuario.persona_id,
                nombre_usuario = usuario.nombre_usuario,
                password = hash.HashPassword(usuario.password),
                rol_id = usuario.rol_id
            };

            this.db.Usuarios.Add(newUsuario);
            int result = await this.db.SaveChangesAsync();
            return result > 0 ? true : false;
        }
    }
}