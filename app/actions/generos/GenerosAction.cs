using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.helpers;
using app.Models;

namespace app.actions.generos
{
    public class GenerosAction
    {
        private ConexionContext _db = new DbContextConection().context();
        private BuscarGenerosAction buscarGenerosAction;
        private NuevoGenerosAction nuevoGenerosAction;
        private ObtenerGenerosAction obtenerGenerosAction;


        public GenerosAction()
        {
            this.buscarGenerosAction = new BuscarGenerosAction(_db);
            this.nuevoGenerosAction = new NuevoGenerosAction(_db);
            this.obtenerGenerosAction = new ObtenerGenerosAction(_db);
        }

        public Task<Genero> buscar(int id) => this.buscarGenerosAction.ejecutar(id);

        public Task<Boolean> guardar(Genero genero) => this.nuevoGenerosAction.ejecutar(genero);

        public Task<Object[]> obtener(int tp, int np) => this.obtenerGenerosAction.ejecutar(tp, np);
    }
}