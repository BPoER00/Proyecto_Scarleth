using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.Models;
using Microsoft.EntityFrameworkCore;

namespace app.actions.medicos
{
    public class ObtenerMedicoAction
    {
        private ConexionContext db;

        public ObtenerMedicoAction(ConexionContext _db)
        {
            this.db = _db;
        }

        public async Task<List<Medico>> ejecutar()
        {
            var lista = await this.db.Medicos
                        .Where(x => x.estado == Medico.ACTIVO)
                        .Take(10)
                        .ToListAsync();

            return lista;
        }
    }
}