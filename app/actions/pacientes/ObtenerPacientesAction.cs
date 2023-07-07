using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.helpers;
using app.Models;
using Microsoft.EntityFrameworkCore;

namespace app.actions.pacientes
{
    public class ObtenerPacientesAction
    {
        private ConexionContext db;
        private PaginateData pd;

        public ObtenerPacientesAction(ConexionContext _db)
        {
            this.db = _db;
            this.pd = new PaginateData();
        }
        
        public async Task<Object[]> ejecutar(int tp, int np)
        {
            int totalObjects = this.db.Pacientes.Count();

            int[] paginate = this.pd.paginateData(tp, np, totalObjects);
            var lista = await this.db
            .Pacientes
            .Where(x => x.estado == Paciente.ACTIVO)
            .Skip(paginate[0])
            .Take(paginate[1])
            .ToListAsync();

            return new Object[] { lista, np, tp, paginate[2] };
        }
    }
}