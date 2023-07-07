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
        public async Task<Boolean> ejecutar(Paciente paciente)
        {
            this.db.Pacientes.Add(paciente);
            int result = await this.db.SaveChangesAsync();
            return result > 0 ? true : false;
        }
    }
}