using app.Models;
using app.actions.vacuna;

namespace app.actions.detalle_vacuna
{
    public class NuevoDetalleVacunasAction
    {
        private ConexionContext db;
        public NuevoDetalleVacunasAction(ConexionContext _db)
        {
            this.db = _db;
        }

        public async Task<Boolean> ejecutar(Detalle_Vacuna detalle_Vacuna)
        {
            var vacunaExistente = await this.db.Vacunas.FindAsync(detalle_Vacuna.vacuna_id);

            if (vacunaExistente == null) return false;

            this.db.Detalle_Vacunas.Add(detalle_Vacuna);

            vacunaExistente.unidades += detalle_Vacuna.cantidad;
            vacunaExistente.UpdateAt = DateTime.Now;

            int result = await this.db.SaveChangesAsync();

            return result > 0;
        }
    }
}