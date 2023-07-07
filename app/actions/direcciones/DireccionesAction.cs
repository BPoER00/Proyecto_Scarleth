using app.Models;
using app.helpers;

namespace app.actions.direcciones
{
    public class DireccionesAction
    {
        private ConexionContext _db = new DbContextConection().context();
        private ObtenerDireccionesAction obtenerDireccionesAction;
        private NuevoDireccionesAction nuevoDireccionesAction;

        public DireccionesAction()
        {
            this.obtenerDireccionesAction = new ObtenerDireccionesAction(_db);
            this.nuevoDireccionesAction = new NuevoDireccionesAction(_db);
        }

        public Task<Object[]> obtener(int tp, int np) => this.obtenerDireccionesAction.ejecutar(tp, np);
        public Task<Direccion> guardar(Direccion direccion) => this.nuevoDireccionesAction.ejecutar(direccion);

    }
}