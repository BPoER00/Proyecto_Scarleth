using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.Models;
using Microsoft.EntityFrameworkCore;

namespace app.actions.generos
{
    public class ObtenerGenerosAction
    {
        private ConexionContext db;

        public ObtenerGenerosAction(ConexionContext _db)
        {
            this.db = _db;
        }

        public async Task<List<Genero>> ejecutar()
        {
            var lista = await this.db.Generos.ToListAsync();
            return lista;
        }
    }
}