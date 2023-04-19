using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.Models;
using Microsoft.EntityFrameworkCore;

namespace app.actions.pacientes
{
    public class ObtenerPacientesAction
    {
        private ConexionContext db;

        public ObtenerPacientesAction(ConexionContext _db)
        {
            this.db = _db;
        }
        
        public async Task<List<Paciente>> ejecutar()
        {
            var pacientes = await this.db.Pacientes.ToListAsync(); 

            return pacientes;
        }
    }
}