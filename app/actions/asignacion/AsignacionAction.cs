using app.helpers;
using app.Models;

namespace app.actions.medicos
{
    public class AsignacionAction
    {
        private ConexionContext _db = new DbContextConection().context();
        private BuscarAsignacionAction buscarAsignacionAction;
        private NuevoAsignacionAction nuevoAsignacionAction;
        private ObtenerAsignacionAction obtenerAsignacionAction;
        
        public AsignacionAction()
        {
            this.obtenerAsignacionAction = new ObtenerAsignacionAction(_db);
            this.nuevoAsignacionAction = new NuevoAsignacionAction(_db);
            this.buscarAsignacionAction = new BuscarAsignacionAction(_db);
        }

        public Task<Asignacion> buscar(int id) => this.buscarAsignacionAction.ejecutar(id);

        public Task<Boolean> guardar(Asignacion asignacion) => this.nuevoAsignacionAction.ejecutar(asignacion);

        public Task<Object[]> obtener(int tp, int np) => this.obtenerAsignacionAction.ejecutar(tp, np);
    }
}