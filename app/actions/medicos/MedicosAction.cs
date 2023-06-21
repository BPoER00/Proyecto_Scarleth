using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.Models;

namespace app.actions.medicos
{
    public class MedicosAction
    {
        public MedicosAction(ConexionContext _db)
        {
            this.obtenerMedicoAction = new ObtenerMedicoAction(_db);
            this.nuevoMedicoAction = new NuevoMedicoAction(_db);
            this.buscarMedicoAction = new BuscarMedicoAction(_db);
        }
    
        private ObtenerMedicoAction obtenerMedicoAction;
        private NuevoMedicoAction nuevoMedicoAction;
        private BuscarMedicoAction buscarMedicoAction;

        public Task<List<Medico>> obtener()
        {
            return this.obtenerMedicoAction.ejecutar();
        }

        public Task<Medico> obtener(int? id)
        {
            return this.buscarMedicoAction.ejecutar(id);
        }

        public Task<Medico> guardar(Medico medico)
        {
            return this.nuevoMedicoAction.ejecutar(medico);
        }
    }
}