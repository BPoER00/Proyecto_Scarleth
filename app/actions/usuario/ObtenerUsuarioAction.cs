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

        public async Task<Object[]> ejecutar(int tp, int np, string usuarioId, string rolId)
        {

            int usuario_id = int.Parse(usuarioId);
            int rol_id = int.Parse(rolId);

            var lista = await this.db
            .Usuarios
            .Where(x => x.estado == Usuario.ACTIVO)
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

            if (usuario_id > 0)
            {
                lista = lista.Where(x => x.Id == usuario_id).ToList();
            }

            if (rol_id > 0)
            {
                lista = lista.Where(x => x.RolId == rol_id).ToList();
            }

            int totalObjects = lista.Count();
            int[] paginate = this.pd.paginateData(tp, np, totalObjects);
            var listaFiltros = lista.Skip(paginate[0]).Take(paginate[1]).ToList();

            return new Object[] { listaFiltros, np, tp, paginate[2] };
        }
    }
}