using app.Models;
using app.helpers;

namespace app.actions.detalle_vacunacion
{
    public class DetalleVacunacionActions
    {
        private ConexionContext _db = new DbContextConection().context();
        private NuevoDetalleVacunacionAction nuevoDetalleVacunacionAction;
        private ObtenerDetalleVacunacionAction obtenerDetalleVacunacionAction;

        public DetalleVacunacionActions()
        {
            this.nuevoDetalleVacunacionAction = new NuevoDetalleVacunacionAction(_db);
            this.obtenerDetalleVacunacionAction = new ObtenerDetalleVacunacionAction(_db);
        }

        public Task<Boolean> guardar(Detalle_Vacunacion detalle_Vacunacion) => this.nuevoDetalleVacunacionAction.ejecutar(detalle_Vacunacion);

        public Task<Object[]> obtener(int tp, int np, string idPersona) => this.obtenerDetalleVacunacionAction.ejecutar(tp, np, idPersona);
    }
}