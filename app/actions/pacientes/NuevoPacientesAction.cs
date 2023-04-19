using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.Models;

namespace app.actions.pacientes
{
    public class NuevoPacientesAction
    {
        private ConexionContext db;

        public NuevoPacientesAction(ConexionContext _db)
        {
            this.db = _db;
        }
        public async Task<Paciente> ejecutar(Paciente paciente)
        {
            this.db.Pacientes.Add(paciente);
            await this.db.SaveChangesAsync();
            return paciente;
        }
    }
}