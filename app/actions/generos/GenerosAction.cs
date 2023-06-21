using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.Models;

namespace app.actions.generos
{
    public class GenerosAction
    {
        public GenerosAction(ConexionContext _db)
        {
            this.obtenerGenerosAction = new ObtenerGenerosAction(_db);
            this.nuevoGenerosAction = new NuevoGenerosAction(_db);
        }

        private ObtenerGenerosAction obtenerGenerosAction;
        private NuevoGenerosAction nuevoGenerosAction;

        public Task<List<Genero>> obtener()
        {
            return this.obtenerGenerosAction.ejecutar();
        }

        public Task<Genero> guardar(Genero genero)
        {
            return this.nuevoGenerosAction.ejecutar(genero);
        }
    }
}