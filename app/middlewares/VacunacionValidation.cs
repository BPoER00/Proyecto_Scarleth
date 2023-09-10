using app.actions.vacuna;
using app.actions.persona;
using app.actions.asignacion;


namespace app.middlewares
{
    public class VacunacionValidation
    {
        private VacunasActions vacunasActions;
        private PersonasActions personasActions;
        private AsignacionAction asignacionAction;

        public VacunacionValidation()
        {
            this.vacunasActions = new VacunasActions();
            this.personasActions = new PersonasActions();
            this.asignacionAction = new AsignacionAction();
        }

        public async Task<Boolean> validateVacuna(int id)
        {
            var result = await this.vacunasActions.buscar(id);
            return result != null;
        }

        public async Task<Boolean> validatePersona(int id)
        {
            var result = await this.personasActions.buscar(id);
            return result != null;
        }

        public async Task<Boolean> validateAsignacion(int id)
        {
            var result = await this.asignacionAction.buscar(id);
            return result != null;
        }
    }
}