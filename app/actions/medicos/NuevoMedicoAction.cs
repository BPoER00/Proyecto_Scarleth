using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.Models;
using Microsoft.EntityFrameworkCore;

namespace app.actions.medicos
{
    public class NuevoMedicoAction
    {
        private ConexionContext db;

        public NuevoMedicoAction(ConexionContext _db)
        {
            this.db = _db;
        }

        public async Task<Boolean> ejecutar(Medico medico)
        {
            this.db.Medicos.Add(medico);
            int result = await this.db.SaveChangesAsync();
            return result > 0 ? true : false;
        }

    }
}