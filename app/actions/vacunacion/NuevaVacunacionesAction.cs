using app.actions.vacuna;
using app.Models;

namespace app.actions.vacunacion
{
    public class NuevaVacunacionesAction
    {
        private ConexionContext db;
        private VacunasActions vacunasActions;

        public NuevaVacunacionesAction(ConexionContext _db)
        {
            this.db = _db;
            this.vacunasActions = new VacunasActions();
        }
        public async Task<Boolean> ejecutar(VacunacionDetalles vacunacion)
        {
            int resultD = 0;

            var newVacunacion = new Vacunacion
            {
                descripcion = vacunacion.descripcion,
                vacuna_id = vacunacion.vacuna_id,
                persona_id = vacunacion.persona_id,
                dosis = vacunacion.dosis,
                estado = Vacunacion.ACTIVO
            };

            var newDetalleVacunacion = new Detalle_Vacunacion
            {
                fecha_vacunacion = vacunacion.fecha_vacunacion,
                dosis = vacunacion.dosis,
                asignacion_id = vacunacion.asignacion_id
            };

            var vacuna = await this.db.Vacunas.FindAsync(vacunacion.vacuna_id);

            if (vacuna.dosis == vacunacion.dosis)
            {
                newVacunacion.estado = Vacunacion.NO_ACTIVO;
            }

            this.db.Vacunacions.Add(newVacunacion);
            vacuna.unidades -= vacunacion.dosis;

            int result = await this.db.SaveChangesAsync();

            if (result > 0)
            {
                newDetalleVacunacion.vacunacion_id = newVacunacion.id;
                this.db.Detalle_Vacunacions.Add(newDetalleVacunacion);
                resultD = await this.db.SaveChangesAsync();
            }

            return resultD > 0;
        }
    }
}