using app.Models;
using app.helpers;

namespace app.actions.detalle_vacuna
{
    public class DetalleVacunasActions
    {
        private ConexionContext _db = new DbContextConection().context();
        private NuevoDetalleVacunasAction nuevoDetalleVacunasAction;
        private ObtenerDetalleVacunasAction obtenerDetalleVacunasAction;

        public DetalleVacunasActions()
        {
            this.nuevoDetalleVacunasAction = new NuevoDetalleVacunasAction(_db);
            this.obtenerDetalleVacunasAction = new ObtenerDetalleVacunasAction(_db);
        }

        public Task<Boolean> guardar(Detalle_Vacuna detalle_Vacuna) => this.nuevoDetalleVacunasAction.ejecutar(detalle_Vacuna);

        public Task<Object[]> obtener(int tp, int np, string idVacuna) => this.obtenerDetalleVacunasAction.ejecutar(tp, np, idVacuna);
    }
}