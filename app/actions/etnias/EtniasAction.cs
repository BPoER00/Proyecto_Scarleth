using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.helpers;
using app.Models;

namespace app.actions.etnias
{
    public class EtniasAction
    {
        private ConexionContext _db = new DbContextConection().context();
        private BuscarEtniasActions buscarEtniasActions;
        private NuevoEtniasAction nuevoEtniasAction;
        private ObtenerEtniasAction obtenerEtniasAction;

        public EtniasAction()
        {
            this.buscarEtniasActions = new BuscarEtniasActions(_db);
            this.nuevoEtniasAction = new NuevoEtniasAction(_db);
            this.obtenerEtniasAction = new ObtenerEtniasAction(_db);
        }

        public Task<Etnia> buscar(int id) => this.buscarEtniasActions.ejecutar(id);

        public Task<Boolean> guardar(Etnia direccion) => this.nuevoEtniasAction.ejecutar(direccion);

        public Task<Object[]> obtener(int tp, int np) => this.obtenerEtniasAction.ejecutar(tp, np);
    }
}