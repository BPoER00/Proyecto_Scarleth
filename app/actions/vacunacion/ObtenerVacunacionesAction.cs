using app.Models;
using app.helpers;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace app.actions.vacunacion
{
    public class ObtenerVacunacionesAction
    {
        private ConexionContext db;
        private PaginateData pd;

        public ObtenerVacunacionesAction(ConexionContext _db)
        {
            this.db = _db;
            this.pd = new PaginateData();
        }

        public async Task<Object[]> ejecutar(int tp, int np, string personaId, string fechaInicioValue,
        string fechaFinValue, string vacunaId)
        {
            int persona_id = int.Parse(personaId);
            int vacuna_id = int.Parse(vacunaId);

            var lista = await this.db
            .Vacunacions
            .Include(x => x.Vacuna)
            .Include(x => x.Persona)
            .ToListAsync();

            if (persona_id > 0)
            {
                lista = lista.Where(x => x.Persona.id == persona_id).ToList();
            }

            if (vacuna_id > 0)
            {
                lista = lista.Where(x => x.Vacuna.id == vacuna_id).ToList();
            }

            if (!string.IsNullOrEmpty(fechaFinValue) && !string.IsNullOrEmpty(fechaInicioValue))
            {
                var fechaInicio = DateTime.Parse(fechaInicioValue);
                var fechaFin = DateTime.Parse(fechaFinValue);

                if (fechaFin < fechaInicio)
                {
                    throw new ArgumentException("La fecha de fin debe ser posterior a la fecha de inicio.");
                }

                lista = lista.Where(e => e.CreateAt >= fechaInicio && e.CreateAt <= fechaFin).ToList();
            }

            int totalObjects = lista.Count();
            int[] paginate = this.pd.paginateData(tp, np, totalObjects);
            var listaFiltros = lista.Skip(paginate[0]).Take(paginate[1]).ToList();

            return new Object[] { listaFiltros, np, tp, paginate[2] };
        }
    }
}