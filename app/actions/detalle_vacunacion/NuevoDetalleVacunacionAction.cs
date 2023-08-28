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
            this.db.Detalle_Vacunacions.Add(detalle_Vacunacion);
            int result = await this.db.SaveChangesAsync();

            return result > 0 ? true : false;
        }
    }
}