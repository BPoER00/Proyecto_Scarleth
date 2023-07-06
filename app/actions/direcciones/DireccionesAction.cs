using app.Models;
using app.helpers;

namespace app.actions.direcciones
{
    public class DireccionesAction
    {
        private ConexionContext _db = new DbContextConection().context();

        public DireccionesAction()
        {
            this.obtenerDireccionesAction = new ObtenerDireccionesAction(_db);
            this.nuevoDireccionesAction = new NuevoDireccionesAction(_db);
        }

        private ObtenerDireccionesAction obtenerDireccionesAction;
        private NuevoDireccionesAction nuevoDireccionesAction;
    
        public Task<Object[]> obtener(int tp, int np)
        {
            return this.obtenerDireccionesAction.ejecutar(tp, np);
        }

        public Task<Direccion> guardar(Direccion direccion)
        {
            return this.nuevoDireccionesAction.ejecutar(direccion);
        }
    }
}