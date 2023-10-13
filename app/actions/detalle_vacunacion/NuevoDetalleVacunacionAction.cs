using app.actions.vacuna;
using app.Models;

namespace app.actions.detalle_vacunacion
{
    public class NuevoDetalleVacunacionAction
    {
        private ConexionContext db;
        private VacunasActions vacunasActions;

        public NuevoDetalleVacunacionAction(ConexionContext _db)
        {
            this.db = _db;
            this.vacunasActions = new VacunasActions();
        }

        public async Task<Boolean> ejecutar(Detalle_Vacunacion detalle_Vacunacion)
        {
            var vacunacionExistente = await this.db.Vacunacions.FindAsync(detalle_Vacunacion.vacunacion_id);

            if (vacunacionExistente == null) return false;

            var vacuna = await this.db.Vacunas.FindAsync(vacunacionExistente.vacuna_id);

            this.db.Detalle_Vacunacions.Add(detalle_Vacunacion);
            vacunacionExistente.dosis += detalle_Vacunacion.dosis;
            vacunacionExistente.UpdateAt = DateTime.Now;

            if (vacuna.dosis == vacunacionExistente.dosis)
            {
                vacunacionExistente.estado = Vacunacion.NO_ACTIVO;
            }

            vacuna.unidades -= detalle_Vacunacion.dosis;

            int result = await this.db.SaveChangesAsync();

            return result > 0;
        }
    }
}