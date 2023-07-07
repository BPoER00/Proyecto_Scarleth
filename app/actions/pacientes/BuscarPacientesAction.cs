using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.Models;

namespace app.actions.pacientes
{
    public class BuscarPacientesAction
    {
        private ConexionContext db;

        public BuscarPacientesAction(ConexionContext _db)
        {
            this.db = _db;
        }

        public async Task<Paciente> ejecutar(int id)
        {
            var lista = await this.db.Pacientes
                        .FindAsync(id);

            return lista;
        }
    }
}