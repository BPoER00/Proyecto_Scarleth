using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.helpers;
using app.Models;

namespace app.actions.cargos
{
    public class CargosAction
    {
        private ConexionContext _db = new DbContextConection().context();
        private BuscarCargosAction buscarCargosAction;
        private NuevoCargosAction nuevoCargosAction;
        private ObtenerCargosAction obtenerCargosAction;
        private ObtenerCargosSinPaginadoAction obtenerCargosSinPaginadoAction;


        public CargosAction()
        {
            this.buscarCargosAction = new BuscarCargosAction(_db);
            this.nuevoCargosAction = new NuevoCargosAction(_db);
            this.obtenerCargosAction = new ObtenerCargosAction(_db);
            this.obtenerCargosSinPaginadoAction = new ObtenerCargosSinPaginadoAction(_db);
        }

        public Task<Object[]> obtener(int tp, int np) => this.obtenerCargosAction.ejecutar(tp, np);

        public Task<Boolean> guardar(Cargo cargo) => this.nuevoCargosAction.ejecutar(cargo);

        public Task<Cargo> buscar(int id) => this.buscarCargosAction.ejecutar(id);

        public Task<List<Cargo>> obtenerSP() => this.obtenerCargosSinPaginadoAction.ejecutar();
    }
}