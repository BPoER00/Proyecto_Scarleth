using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.Models;
namespace app.actions.generos
{
    public class NuevoGenerosAction
    {
        private ConexionContext db;

        public NuevoGenerosAction(ConexionContext _db)
        {
            this.db = _db;
        }

        public async Task<Boolean> ejecutar(Genero genero)
        {
            this.db.Generos.Add(genero);
            int result = await this.db.SaveChangesAsync();
            return result > 0 ? true : false;
        }
    }
}