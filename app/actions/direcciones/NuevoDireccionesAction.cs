using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using app.Models;

namespace app.actions.direcciones
{
    public class NuevoDireccionesAction
    {
        private ConexionContext db;

        public NuevoDireccionesAction(ConexionContext _db)
        {
            this.db = _db;
        }

        public async Task<Boolean> ejecutar(Direccion direccion)
        {
            this.db.Direccions.Add(direccion);
            int result = await this.db.SaveChangesAsync();
            
            return result > 0 ? true : false;
        }
    }
}