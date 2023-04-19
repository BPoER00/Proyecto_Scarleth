using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using app.Models;

namespace app.actions.etnias
{
    public class ObtenerEtniasAction
    {
        private ConexionContext db;

        public ObtenerEtniasAction(ConexionContext _db)
        {
            this.db = _db;
        }

        public async Task<List<Etnia>> ejecutar()
        {
            var lista = await this.db
            .Etnias
            .Where(x => x.estado == Etnia.ACTIVO)
            .ToListAsync();
            
            return lista;
        }
    }
}