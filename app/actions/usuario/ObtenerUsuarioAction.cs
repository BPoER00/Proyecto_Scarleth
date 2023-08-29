using app.Models;
using app.Models.ModelView;
using app.helpers;
using Microsoft.EntityFrameworkCore;

namespace app.actions.usuario
{
    public class ObtenerUsuarioAction
    {
        private ConexionContext db;
        private PaginateData pd;

        public ObtenerUsuarioAction(ConexionContext _db)
        {
            this.db = _db;
            this.pd = new PaginateData();
        }

        public async Task<Object[]> ejecutar(int tp, int np)
        {
            int totalObjects = this.db.Usuarios.Count();

            int[] paginate = this.pd.paginateData(tp, np, totalObjects);
            var lista = await this.db
            .Usuarios
            .Where(x => x.estado == Usuario.ACTIVO)
            .Skip(paginate[0])
            .Take(paginate[1])
            .Select(x => new UsuarioInfo // Utiliza la clase UsuarioInfo
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

            return new Object[] { lista, np, tp, paginate[2] };
        }
    }
}