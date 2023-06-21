using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.Models;

namespace app.actions.etnias
{
    public class EtniasAction
    {
        public EtniasAction(ConexionContext _db)
        {
            this.obtenerEtniasAction = new ObtenerEtniasAction(_db);
            this.nuevoEtniasAction = new NuevoEtniasAction(_db);
        }

        private ObtenerEtniasAction obtenerEtniasAction;
        private NuevoEtniasAction nuevoEtniasAction;

        public Task<List<Etnia>> obtener()
        {
            return this.obtenerEtniasAction.ejecutar();
        }

        public Task<Etnia> guardar(Etnia etnia)
        {
            return this.nuevoEtniasAction.ejecutar(etnia);
        }
    }
}