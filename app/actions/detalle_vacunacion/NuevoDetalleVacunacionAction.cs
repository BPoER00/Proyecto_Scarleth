using app.Models;

namespace app.actions.detalle_vacunacion
{
    public class NuevoDetalleVacunacionAction
    {
        private ConexionContext db;

        public NuevoDetalleVacunacionAction(ConexionContext _db)
        {
            this.db = _db;
        }

        public async Task<Boolean> ejecutar(Detalle_Vacunacion detalle_Vacunacion)
        {
            var vacunacionExistente = await this.db.Vacunacions.FindAsync(detalle_Vacunacion.vacunacion_id);

            if (vacunacionExistente == null) return false;

            this.db.Detalle_Vacunacions.Add(detalle_Vacunacion);
            vacunacionExistente.dosis += detalle_Vacunacion.dosis;
            vacunacionExistente.UpdateAt = DateTime.Now;

            int result = await this.db.SaveChangesAsync();

            return result > 0;
        }
    }
}