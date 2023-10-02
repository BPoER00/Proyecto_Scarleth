using app.actions.vacuna;
using app.actions.persona;
using app.actions.asignacion;
using app.Models;
using Microsoft.EntityFrameworkCore;


namespace app.middlewares
{
    public class VacunacionValidation
    {
        private VacunasActions vacunasActions;
        private PersonasActions personasActions;
        private AsignacionAction asignacionAction;
        private ConexionContext db;

        public VacunacionValidation()
        {
            this.vacunasActions = new VacunasActions();
            this.personasActions = new PersonasActions();
            this.asignacionAction = new AsignacionAction();
            this.db = new ConexionContext();
        }

        public async Task<Boolean> validateVacuna(int id)
        {
            var result = await this.vacunasActions.buscar(id);
            return result != null;
        }

        public async Task<Boolean> validatePersona(int id)
        {
            var result = await this.personasActions.buscar(id);
            return result != null;
        }

        public async Task<Boolean> validateAsignacion(int id)
        {
            var result = await this.asignacionAction.buscar(id);
            return result != null;
        }

        public async Task<bool> ValidatePersonaAsignacionAsync(int idPersona, int idAsignacion)
        {
            var persona = await personasActions.buscar(idPersona);
            var asignacion = await asignacionAction.buscar(idAsignacion);

            return persona?.id == asignacion?.persona_id;
        }

        public async Task<bool> ValidatePersonaFinishDosisAsync(int idPersona, int idVacuna)
        {
            var vacunacionActiva = await this.db.Vacunacions
                                        .Where(x => x.persona_id == idPersona && x.vacuna_id == idVacuna && x.estado == Vacunacion.ACTIVO).FirstAsync();

            if (vacunacionActiva != null)
            {
                var vacuna = await this.vacunasActions.buscar(idVacuna);

                if (vacuna.dosis == vacunacionActiva.dosis)
                {
                    return true;
                }

                return false;
            }

            return true;
        }
    }
}