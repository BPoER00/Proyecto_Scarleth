using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.Models;

namespace app.actions.direcciones
{
    public class DireccionesAction
    {
        public DireccionesAction(ConexionContext _db)
        {
            this.obtenerDireccionesAction = new ObtenerDireccionesAction(_db);
            this.nuevoDireccionesAction = new NuevoDireccionesAction(_db);
        }

        private ObtenerDireccionesAction obtenerDireccionesAction;
        private NuevoDireccionesAction nuevoDireccionesAction;
    
        public Task<List<Direccion>> obtener()
        {
            return this.obtenerDireccionesAction.ejecutar();
        }

        public Task<Direccion> guardar(Direccion direccion)
        {
            return this.nuevoDireccionesAction.ejecutar(direccion);
        }
    }
}