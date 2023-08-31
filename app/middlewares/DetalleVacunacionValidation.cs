using app.actions.vacunacion;
using app.actions.asignacion;

namespace app.middlewares
{
    public class DetalleVacunacionValidation
    {
        private VacunacionesActions vacunacionesActions;
        private AsignacionAction asignacionAction;

        public DetalleVacunacionValidation()
        {
            this.vacunacionesActions = new VacunacionesActions();
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
    }
}