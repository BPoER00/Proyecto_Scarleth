using app.actions.vacuna;
using app.actions.persona;


namespace app.middlewares
{
    public class VacunacionValidation
    {
        private VacunasActions vacunasActions;
        private PersonasActions personasActions;

        public VacunacionValidation()
        {
            this.vacunasActions = new VacunasActions();
            this.personasActions = new PersonasActions();
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
    }
}