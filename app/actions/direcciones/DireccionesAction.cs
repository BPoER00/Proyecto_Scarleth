using app.Models;
using app.helpers;
using app.actions.persona;

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

        public Task<List<Direccion>> obtener() => this.obtenerDireccionesAction.ejecutar();

    }
}