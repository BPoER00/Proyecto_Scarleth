using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.helpers;
using app.Models;
using Microsoft.EntityFrameworkCore;

namespace app.actions.generos
{
    public class ObtenerGenerosAction
    {
        private ConexionContext db;
        private PaginateData pd;

        public ObtenerGenerosAction(ConexionContext _db)
        {
            this.db = _db;
            this.pd = new PaginateData();
        }

        public async Task<Object[]> ejecutar(int tp, int np)
        {
            int totalObjects = this.db.Generos.Count();

            int[] paginate = this.pd.paginateData(tp, np, totalObjects);
            var lista = await this.db
            .Generos
            .Where(x => x.estado == Genero.ACTIVO)
            .Skip(paginate[0])
            .Take(paginate[1])
            .ToListAsync();

            return new Object[] { lista, np, tp, paginate[2] };
        }
    }
}