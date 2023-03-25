using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.Models
{
    public class Detalle_Vacunacion : IControl_Fechas
    {
        public int id { get; set; }
        public int vacunacion_id { get; set; }
        public DateTime fecha_vacunacion { get; set; }
        public int dosis { get; set; }
        public int usuario_id { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public DateTime DeleteAt { get; set; }
    
        public virtual Vacunacion Vacunacion { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}