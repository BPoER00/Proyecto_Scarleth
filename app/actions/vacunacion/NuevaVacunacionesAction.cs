using app.Models;

namespace app.actions.vacunacion
{
    public class NuevaVacunacionesAction
    {
        private ConexionContext db;

        public NuevaVacunacionesAction(ConexionContext _db)
        {
            this.db = _db;
        }
        public async Task<Boolean> ejecutar(VacunacionDetalles vacunacion)
        {
            int resultD = 0;

            var newVacunacion = new Vacunacion
            {
                descripcion = vacunacion.descripcion,
                vacuna_id = vacunacion.vacuna_id,
                persona_id = vacunacion.persona_id,
                dosis = vacunacion.dosis
            };

            var newDetalleVacunacion = new Detalle_Vacunacion
            {
                fecha_vacunacion = vacunacion.fecha_vacunacion,
                dosis = vacunacion.dosis,
                asignacion_id = vacunacion.asignacion_id
            };

            this.db.Vacunacions.Add(newVacunacion);
            int result = await this.db.SaveChangesAsync();
            
            if(result > 0)
            {
                newDetalleVacunacion.vacunacion_id = newVacunacion.id;
                this.db.Detalle_Vacunacions.Add(newDetalleVacunacion);
                resultD = await this.db.SaveChangesAsync();
            }
            
            return resultD > 0;
        }
    }
}