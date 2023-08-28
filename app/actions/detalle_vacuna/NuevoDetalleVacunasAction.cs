using app.Models;

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
            this.db.Detalle_Vacunas.Add(detalle_Vacuna);
            int result = await this.db.SaveChangesAsync();

            return result > 0 ? true : false;
        }
    }
}