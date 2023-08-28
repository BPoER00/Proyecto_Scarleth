using app.Models;
using app.helpers;

namespace app.actions.persona
{
    public class PersonasActions
    {
        private ConexionContext _db = new DbContextConection().context();
        private BuscarPersonasAction buscarPersonasAction;
        private NuevaPersonasActions nuevaPersonasActions;
        private ObtenerPersonasAction obtenerPersonasAction;

        public PersonasActions()
        {
            this.buscarPersonasAction = new BuscarPersonasAction(_db);
            this.nuevaPersonasActions = new NuevaPersonasActions(_db);
            this.obtenerPersonasAction = new ObtenerPersonasAction(_db);
        }

        public Task<Persona> buscar(int id) => this.buscarPersonasAction.ejecutar(id);

        public Task<Boolean> guardar(Persona persona) => this.nuevaPersonasActions.ejecutar(persona);

        public Task<Object[]> obtener(int tp, int np) => this.obtenerPersonasAction.ejecutar(tp, np);

    }
}