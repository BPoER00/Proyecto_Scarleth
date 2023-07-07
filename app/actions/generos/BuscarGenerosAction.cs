using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.Models;

namespace app.actions.generos
{
    public class BuscarGenerosAction
    {
        private ConexionContext db;

        public BuscarGenerosAction(ConexionContext _db)
        {
            this.db = _db;
        }

        public async Task<Genero> ejecutar(int id)
        {
            var lista = await this.db.Generos
                        .FindAsync(id);

            return lista;
        }
    }
}