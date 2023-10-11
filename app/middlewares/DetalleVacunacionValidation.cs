using app.actions.vacunacion;
using app.actions.asignacion;
using app.actions.vacuna;

namespace app.middlewares
{
    public class DetalleVacunacionValidation
    {
        private VacunacionesActions vacunacionesActions;
        private VacunasActions vacunasActions;
        private AsignacionAction asignacionAction;

        public DetalleVacunacionValidation()
        {
            this.vacunacionesActions = new VacunacionesActions();
            this.vacunasActions = new VacunasActions();
            this.asignacionAction = new AsignacionAction();
        }

        public async Task<Boolean> validateVacunacion(int id)
        {
            var result = await this.vacunacionesActions.buscar(id);
            return result != null;
        }

        public async Task<Boolean> validateAsignacion(int id)
        {
            var result = await this.asignacionAction.buscar(id);
            return result != null;
        }

        public async Task<Boolean> validateRegistroDetalleVacunacion(int idVacunacion, int total)
        {
            var vacunacion = await this.vacunacionesActions.buscar(idVacunacion);
            var vacuna = await this.vacunasActions.buscar(vacunacion.vacuna_id);

            int fin = (int)(vacunacion.dosis + total);

            return vacuna.dosis > fin;
        }
    }
}