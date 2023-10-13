using app.actions.vacunacion;
using app.actions.asignacion;
using app.actions.vacuna;
using app.actions.persona;

namespace app.middlewares
{
    public class DetalleVacunacionValidation
    {
        private VacunacionesActions vacunacionesActions;
        private VacunasActions vacunasActions;
        private AsignacionAction asignacionAction;
        private PersonasActions personasActions;

        public DetalleVacunacionValidation()
        {
            this.vacunacionesActions = new VacunacionesActions();
            this.vacunasActions = new VacunasActions();
            this.asignacionAction = new AsignacionAction();
            this.personasActions = new PersonasActions();
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

            return vacuna.dosis >= fin;
        }

        public async Task<bool> ValidatePersonaAsignacionAsync(int idVacunacion, int idAsignacion)
        {
            var vacunacion = await vacunacionesActions.buscar(idVacunacion);
            var persona = await personasActions.buscar(vacunacion.persona_id);
            var asignacion = await asignacionAction.buscar(idAsignacion);

            return persona?.id == asignacion?.persona_id;
        }

        public async Task<Boolean> validateVacunas0(int idVacunacion, int total)
        {
            var vacunacion = await this.vacunacionesActions.buscar(idVacunacion);
            var vacuna = await this.vacunasActions.buscar(vacunacion.vacuna_id);

            return (vacuna.dosis - total) > 0;
        }
    }
}