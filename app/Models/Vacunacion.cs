using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.Models
{
    public class Vacunacion : IControl_Fechas
    {
        public const int ACTIVO = 1;
        public const int NO_ACTIVO = 0;

        public int id { get; set; }
        public string descripcion { get; set; }
        public int medico_id { get; set; }
        public int vacuna_id { get; set; }
        public int paciente_id { get; set; }
        public long dosis { get; set; }
        public int estado { get; set; } = ACTIVO;
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public DateTime DeleteAt { get; set; }

        public virtual Medico Medico { get; set; }
        public virtual Vacuna Vacuna { get; set; }
        public virtual Paciente Paciente { get; set; }
    }
}