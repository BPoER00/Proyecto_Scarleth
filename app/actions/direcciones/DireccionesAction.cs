using app.Models;
using app.helpers;

namespace app.actions.direcciones
{
    public class DireccionesAction
    {
        private ConexionContext _db = new DbContextConection().context();
        private BuscarDireccionesAction buscarDireccionesAction;
        private NuevoDireccionesAction nuevoDireccionesAction;
        private ObtenerDireccionesAction obtenerDireccionesAction;

        public DireccionesAction()
        {
            this.buscarDireccionesAction = new BuscarDireccionesAction(_db);
            this.nuevoDireccionesAction = new NuevoDireccionesAction(_db);
            this.obtenerDireccionesAction = new ObtenerDireccionesAction(_db);

        }

        public Task<Direccion> buscar(int id) => this.buscarDireccionesAction.ejecutar(id);

        public Task<Boolean> guardar(Direccion direccion) => this.nuevoDireccionesAction.ejecutar(direccion);

        public Task<Object[]> obtener(int tp, int np) => this.obtenerDireccionesAction.ejecutar(tp, np);
    }
}