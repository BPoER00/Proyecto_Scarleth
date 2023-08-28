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
        public async Task<Boolean> ejecutar(Vacunacion vacunacion)
        {
            this.db.Vacunacions.Add(vacunacion);
            int result = await this.db.SaveChangesAsync();
            return result > 0 ? true : false;
        }
    }
}