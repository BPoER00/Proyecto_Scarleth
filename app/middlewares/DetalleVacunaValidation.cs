using app.actions.vacuna;
using app.actions.usuario;

namespace app.middlewares
{
    public class DetalleVacunaValidation
    {
        private VacunasActions vacunasActions;
        private UsuarioActions usuarioActions;

        public DetalleVacunaValidation()
        {
            this.vacunasActions = new VacunasActions();
            this.usuarioActions = new UsuarioActions();
        }

        public async Task<Boolean> validateVacuna(int id)
        {
            var result = await this.vacunasActions.buscar(id);
            return result != null;
        }

        public async Task<Boolean> validateUsuario(int id)
        {
            var result = await this.usuarioActions.buscar(id);
            return result != null;
        }
    }
}