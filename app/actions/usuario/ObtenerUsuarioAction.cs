using app.Models;
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
            .Select(x => new
            {
                x.id,
                x.Persona.cui,
                x.nombre_usuario,
                x.correo,
                x.estado,
                x.rol_id,
                x.Rol.nombre,
                x.CreateAt,
                x.UpdateAt,
                x.DeleteAt
            })
            .ToListAsync();

            return new Object[] { lista, np, tp, paginate[2] };
        }
    }
}