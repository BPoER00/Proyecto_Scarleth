using app.Models;

namespace app.actions.vacuna
{
    public class NuevaVacunaAction
    {
        private ConexionContext db;

        public NuevaVacunaAction(ConexionContext _db)
        {
            this.db = _db;
        }
        public async Task<Boolean> ejecutar(Vacuna vacuna)
        {
            this.db.Vacunas.Add(vacuna);
            int result = await this.db.SaveChangesAsync();
            return result > 0 ? true : false;
        }
    }
}