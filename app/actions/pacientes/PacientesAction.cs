using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.helpers;
using app.Models;

namespace app.actions.pacientes
{
    public class PacientesAction
    {
        private ConexionContext _db = new DbContextConection().context();
        private BuscarPacientesAction buscarPacientesAction;
        private NuevoPacientesAction nuevoPacientesAction;
        private ObtenerPacientesAction obtenerPacientesAction;

        public PacientesAction()
        {
            this.buscarPacientesAction = new BuscarPacientesAction(_db);
            this.nuevoPacientesAction = new NuevoPacientesAction(_db);
            this.obtenerPacientesAction = new ObtenerPacientesAction(_db);
        }

        public Task<Paciente> buscar(int id) => this.buscarPacientesAction.ejecutar(id);

        public Task<Boolean> guardar(Paciente paciente) => this.nuevoPacientesAction.ejecutar(paciente);

        public Task<Object[]> obtener(int tp, int np) => this.obtenerPacientesAction.ejecutar(tp, np);
    }
}