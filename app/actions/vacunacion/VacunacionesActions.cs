using app.Models;
using app.helpers;

namespace app.actions.vacunacion
{
    public class VacunacionesActions
    {
        private ConexionContext _db = new DbContextConection().context();
        private BuscarVacunacionesAction buscarVacunacionesAction;
        private NuevaVacunacionesAction nuevaVacunacionesAction;
        private ObtenerVacunacionesAction obtenerVacunacionesAction;

        public VacunacionesActions()
        {
            this.buscarVacunacionesAction = new BuscarVacunacionesAction(_db);
            this.nuevaVacunacionesAction = new NuevaVacunacionesAction(_db);
            this.obtenerVacunacionesAction = new ObtenerVacunacionesAction(_db);
        }

        public Task<Vacunacion> buscar(int id) => this.buscarVacunacionesAction.ejecutar(id);

        public Task<Boolean> guardar(VacunacionDetalles vacunacion) => this.nuevaVacunacionesAction.ejecutar(vacunacion);

        public Task<Object[]> obtener(int tp, int np, string personaId, string fechaInicioValue,
        string fechaFinValue, string vacunaId) => this.obtenerVacunacionesAction.ejecutar(tp, np, personaId, fechaInicioValue, fechaFinValue, vacunaId);
    }
}