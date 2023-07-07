using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.Models;

namespace app.actions.direcciones
{
    public class BuscarDireccionesAction
    {
        private ConexionContext db;

        public BuscarDireccionesAction(ConexionContext _db)
        {
            this.db = _db;
        }

        public async Task<Direccion> ejecutar(int id)
        {
            var lista = await this.db.Direccions
                        .FindAsync(id);

            return lista;
        }
    }
}