using app.actions.persona;
using app.actions.cargos;

namespace app.middlewares
{
    public class AsignacionValidation
    {
        private PersonasActions personasActions;
        private CargosAction cargosAction;

        public AsignacionValidation()
        {
            this.personasActions = new PersonasActions();
            this.cargosAction = new CargosAction();
        }

        public async Task<Boolean> validatePersona(int id)
        {
            var result = await this.personasActions.buscar(id);
            return result != null;
        }

        public async Task<Boolean> validateCargo(int id)
        {
            var result = await this.cargosAction.buscar(id);
            return result != null;
        }
    }
}