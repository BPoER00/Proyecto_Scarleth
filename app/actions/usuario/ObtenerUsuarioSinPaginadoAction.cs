using app.Models;
using app.Models.ModelView;
using Microsoft.EntityFrameworkCore;

namespace app.actions.persona
{
    public class ObtenerUsuarioSinPaginadoAction
    {
        private ConexionContext db;

        public ObtenerUsuarioSinPaginadoAction(ConexionContext _db)
        {
            this.db = _db;
        }

        public async Task<List<UsuarioInfo>> ejecutar()
        {
            var lista = await this.db
            .Usuarios
            .Where(x => x.estado == Persona.ACTIVO)
            .Select(x => new UsuarioInfo
            {
                Id = x.id,
                Cui = x.Persona.cui,
                NombreUsuario = x.nombre_usuario,
                Correo = x.correo,
                Estado = x.estado,
                RolId = x.rol_id,
                RolNombre = x.Rol.nombre,
                CreateAt = x.CreateAt,
                UpdateAt = x.UpdateAt,
                DeleteAt = x.DeleteAt
            })
            .ToListAsync();

            return lista;
        }
    }
}