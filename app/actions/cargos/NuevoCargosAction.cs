using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.Models;

namespace app.actions.cargos
{
    public class NuevoCargosAction
    {
        private ConexionContext db;

        public NuevoCargosAction(ConexionContext _db)
        {
            this.db = _db;
        }

        public async Task<Cargo> ejecutar(Cargo cargo)
        {
            this.db.Cargos.Add(cargo);
            await this.db.SaveChangesAsync();
            return cargo;
        }
    }
}