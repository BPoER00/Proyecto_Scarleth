using app.Models;
using app.Models.ModelView;
using app.actions.detalle_vacuna;

namespace app.actions.vacuna
{
    public class NuevaVacunaAction
    {
        private ConexionContext db;
        private DetalleVacunasActions action;
        public NuevaVacunaAction(ConexionContext _db)
        {
            this.db = _db;
            this.action = new DetalleVacunasActions();
        }
        public async Task<Boolean> ejecutar(VacunasDetalles vacuna)
        {
            int resultD = 0;

            var newVacuna = new Vacuna
            {
                nombre = vacuna.nombre,
                unidades = vacuna.cantidad,
                cubre = vacuna.cubre,
            };

            var newDetalleVacuna = new Detalle_Vacuna
            {
                descripcion = vacuna.descripcion,
                cantidad = vacuna.cantidad,
                fecha_vencimiento = vacuna.fecha_vencimiento,
            };

            this.db.Vacunas.Add(newVacuna);
            int result = await this.db.SaveChangesAsync();

            if (result > 0)
            {
                newDetalleVacuna.vacuna_id = newVacuna.id;
                this.db.Detalle_Vacunas.Add(newDetalleVacuna);
                resultD = await this.db.SaveChangesAsync();
            }

            return resultD > 0;
        }


    }
}