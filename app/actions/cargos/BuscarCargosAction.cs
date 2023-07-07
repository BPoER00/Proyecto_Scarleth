using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.Models;

namespace app.actions.cargos
{
    public class BuscarCargosAction
    {
        private ConexionContext db;

        public BuscarCargosAction(ConexionContext _db)
        {
            this.db = _db;
        }

        public async Task<Cargo> ejecutar(int id)
        {
            var lista = await this.db.Cargos
                        .FindAsync(id);

            return lista;
        }
    }
}