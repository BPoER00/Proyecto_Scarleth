using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.Models;

namespace app.actions.pacientes
{
    public class PacientesAction
    {
        public PacientesAction(ConexionContext _db)
        {
            this.obtenerPacientesAction = new ObtenerPacientesAction(_db);
            this.nuevoPacientesAction = new NuevoPacientesAction(_db);
        }

        private ObtenerPacientesAction obtenerPacientesAction;
        private NuevoPacientesAction nuevoPacientesAction;

        public Task<List<Paciente>> obtener()
        {
            return this.obtenerPacientesAction.ejecutar();
        }

        public Task<Paciente> guardar(Paciente paciente)
        {
            return this.nuevoPacientesAction.ejecutar(paciente);
        }
    }
}