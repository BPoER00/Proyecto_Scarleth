using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.Models;
using Microsoft.EntityFrameworkCore;

namespace app.actions.asignacion
{
    public class NuevoAsignacionAction
    {
        private ConexionContext db;

        public NuevoAsignacionAction(ConexionContext _db)
        {
            this.db = _db;
        }

        public async Task<Boolean> ejecutar(Asignacion asignacion)
        {
            this.db.Asignacions.Add(asignacion);
            int result = await this.db.SaveChangesAsync();
            return result > 0 ? true : false;
        }

    }
}