using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.Models;
using Microsoft.EntityFrameworkCore;

namespace app.actions.medicos
{
    public class BuscarMedicoAction
    {
        private ConexionContext db;

        public BuscarMedicoAction(ConexionContext _db)
        {
            this.db = _db;
        }

        public async Task<Medico> ejecutar(int id)
        {
            var lista = await this.db.Medicos
                        .FindAsync(id);

            return lista;
        }
    }
}