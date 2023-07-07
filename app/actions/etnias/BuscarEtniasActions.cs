using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.Models;

namespace app.actions.etnias
{
    public class BuscarEtniasActions
    {
        private ConexionContext db;

        public BuscarEtniasActions(ConexionContext _db)
        {
            this.db = _db;
        }

        public async Task<Etnia> ejecutar(int id)
        {
            var lista = await this.db.Etnias
                        .FindAsync(id);

            return lista;
        }
    }
}