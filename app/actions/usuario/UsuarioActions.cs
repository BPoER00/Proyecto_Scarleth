using app.Models;
using app.helpers;
using app.Models.ModelView;
using app.actions.asignacion;
using app.actions.persona;

namespace app.actions.usuario
{
    public class UsuarioActions
    {
        private ConexionContext _db = new DbContextConection().context();
        private BuscarUsuarioAction buscarUsuarioAction;
        private BuscarXNombreUsuarioAction buscarXNombreUsuarioAction;
        private NuevoUsuarioAction nuevoUsuarioAction;
        private ObtenerUsuarioAction obtenerUsuarioAction;
        private ObtenerUsuarioSinPaginadoAction obtenerUsuarioSinPaginadoAction;
        public UsuarioActions()
        {
            this.buscarUsuarioAction = new BuscarUsuarioAction(_db);
            this.buscarXNombreUsuarioAction = new BuscarXNombreUsuarioAction(_db);
            this.nuevoUsuarioAction = new NuevoUsuarioAction(_db);
            this.obtenerUsuarioAction = new ObtenerUsuarioAction(_db);
            this.obtenerUsuarioSinPaginadoAction = new ObtenerUsuarioSinPaginadoAction(_db);
        }

        public Task<Usuario> buscar(int id) => this.buscarUsuarioAction.ejecutar(id);

        public Task<Usuario> buscarXNombre(string nombre) => this.buscarXNombreUsuarioAction.ejecutar(nombre);

        public Task<Boolean> guardar(Usuario usuario) => this.nuevoUsuarioAction.ejecutar(usuario);

        public Task<Object[]> obtener(int tp, int np, string usuarioId, string rolId) => this.obtenerUsuarioAction.ejecutar(tp, np, usuarioId, rolId);

        public Task<List<UsuarioInfo>> obtenerSP() => this.obtenerUsuarioSinPaginadoAction.ejecutar();
    }
}