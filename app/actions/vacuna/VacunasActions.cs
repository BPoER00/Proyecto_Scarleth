using app.Models;
using app.Models.ModelView;
using app.helpers;

namespace app.actions.vacuna
{
    public class VacunasActions
    {
        private ConexionContext _db = new DbContextConection().context();
        private BuscarVacunaAction buscarVacunaAction;
        private NuevaVacunaAction nuevaVacunaAction;
        private ObtenerVacunaAction obtenerVacunaAction;

        public VacunasActions()
        {
            this.buscarVacunaAction = new BuscarVacunaAction(_db);
            this.nuevaVacunaAction = new NuevaVacunaAction(_db);
            this.obtenerVacunaAction = new ObtenerVacunaAction(_db);
        }

        public Task<Vacuna> buscar(int id) => this.buscarVacunaAction.ejecutar(id);

        public Task<Boolean> guardar(VacunasDetalles vacuna) => this.nuevaVacunaAction.ejecutar(vacuna);

        public Task<Object[]> obtener(int tp, int np) => this.obtenerVacunaAction.ejecutar(tp, np);
    }
}