using app.actions.direcciones;
using app.actions.generos;
namespace app.middlewares
{

    public class PersonaValidation
    {
        private DireccionesAction direccionesAction;
        private GenerosAction generosAction;

        public PersonaValidation()
        {
            this.direccionesAction = new DireccionesAction();
            this.generosAction = new GenerosAction();
        }

        public async Task<Boolean> validateDirecciones(int id)
        {
            var result = await this.direccionesAction.buscar(id);
            return result != null;
        }

        public async Task<Boolean> validateGeneros(int id)
        {
            var result = await this.generosAction.buscar(id);
            return result != null;
        }
    }
}