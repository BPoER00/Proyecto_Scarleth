using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.Models
{
    public class Detalle_Vacuna : IControl_Fechas
    {
        public int id { get; set; }
        public string descripcion { get; set; }
        public long cantidad { get; set; }
        public DateTime fecha_ingreso { get; set; }
        public int vacuna_id { get; set; }
        public int usuario_id { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public DateTime DeleteAt { get; set; }

        public virtual Vacuna Vacuna { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}