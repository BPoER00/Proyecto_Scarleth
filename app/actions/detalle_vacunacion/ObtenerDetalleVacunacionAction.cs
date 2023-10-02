using Microsoft.EntityFrameworkCore;
using app.Models;
using app.helpers;

namespace app.actions.detalle_vacunacion
{
    public class ObtenerDetalleVacunacionAction
    {
        private ConexionContext db;
        private PaginateData pd;

        public ObtenerDetalleVacunacionAction(ConexionContext _db)
        {
            this.db = _db;
            this.pd = new PaginateData();
        }

        public async Task<Object[]> ejecutar(int tp, int np, string idPersona)
        {
            var id_persona = int.Parse(idPersona);

            var lista = await this.db
            .Detalle_Vacunacions
            .Include(x => x.Vacunacion.Vacuna)
            .Include(x => x.Asignacion.Persona)
            .Include(x => x.Asignacion.Cargo)
            .ToListAsync();

            if (id_persona > 0)
            {
                lista = lista.Where(x => x.Vacunacion.persona_id == id_persona).ToList();
            }

            int totalObjects = lista.Count();

            int[] paginate = this.pd.paginateData(tp, np, totalObjects);

            var listaResult = lista
                                .Skip(paginate[0])
                                .Take(paginate[1])
                                .ToList();

            return new Object[] { listaResult, np, tp, paginate[2] };
        }

    }
}
