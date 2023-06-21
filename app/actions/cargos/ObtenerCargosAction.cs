using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.Models;
using Microsoft.EntityFrameworkCore;

namespace app.actions.cargos
{
    public class ObtenerCargosAction
    {
        private ConexionContext db;

        public ObtenerCargosAction(ConexionContext _db)
        {
            this.db = _db;
        }

        public async Task<List<Cargo>> ejecutar()
        {
            var lista = await this.db.Cargos
                        .Where(x => x.estado == Cargo.ACTIVO)
                        .Take(10)
                        .ToListAsync();

            return lista;
        }
    }
}