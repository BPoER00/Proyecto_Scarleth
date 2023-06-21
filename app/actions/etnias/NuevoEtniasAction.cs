using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using app.Models;

namespace app.actions.etnias
{
    public class NuevoEtniasAction
    {
        private ConexionContext db;

        public NuevoEtniasAction(ConexionContext _db)
        {
            this.db = _db;
        }

        public async Task<Etnia> ejecutar(Etnia etnia)
        {
            this.db.Etnias.Add(etnia);
            await this.db.SaveChangesAsync();
            return etnia;
        }
    }
}