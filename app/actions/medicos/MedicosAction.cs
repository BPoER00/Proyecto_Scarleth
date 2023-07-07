using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.helpers;
using app.Models;

namespace app.actions.medicos
{
    public class MedicosAction
    {
        private ConexionContext _db = new DbContextConection().context();
        private BuscarMedicoAction buscarMedicoAction;
        private NuevoMedicoAction nuevoMedicoAction;
        private ObtenerMedicoAction obtenerMedicoAction;
        
        public MedicosAction()
        {
            this.obtenerMedicoAction = new ObtenerMedicoAction(_db);
            this.nuevoMedicoAction = new NuevoMedicoAction(_db);
            this.buscarMedicoAction = new BuscarMedicoAction(_db);
        }

        public Task<Medico> buscar(int id) => this.buscarMedicoAction.ejecutar(id);

        public Task<Boolean> guardar(Medico medico) => this.nuevoMedicoAction.ejecutar(medico);

        public Task<Object[]> obtener(int tp, int np) => this.obtenerMedicoAction.ejecutar(tp, np);
    }
}