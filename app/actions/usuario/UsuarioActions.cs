using app.Models;
using app.helpers;

namespace app.actions.usuario
{
    public class UsuarioActions
    {
        private ConexionContext _db = new DbContextConection().context();
        private BuscarUsuarioAction buscarUsuarioAction;
        private BuscarXNombreUsuarioAction buscarXNombreUsuarioAction;
        private NuevoUsuarioAction nuevoUsuarioAction;
        private ObtenerUsuarioAction obtenerUsuarioAction;

        public UsuarioActions()
        {
            this.buscarUsuarioAction = new BuscarUsuarioAction(_db);
            this.buscarXNombreUsuarioAction = new BuscarXNombreUsuarioAction(_db);
            this.nuevoUsuarioAction = new NuevoUsuarioAction(_db);
            this.obtenerUsuarioAction = new ObtenerUsuarioAction(_db);
        }

        public Task<Usuario> buscar(int id) => this.buscarUsuarioAction.ejecutar(id);

        public Task<Usuario> buscarXNombre(string nombre) => this.buscarXNombreUsuarioAction.ejecutar(nombre);

        public Task<Boolean> guardar(Usuario usuario) => this.nuevoUsuarioAction.ejecutar(usuario);

        public Task<Object[]> obtener(int tp, int np) => this.obtenerUsuarioAction.ejecutar(tp, np);
    }
}