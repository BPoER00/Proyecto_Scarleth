using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.Models
{
    public class Vacuna : IControl_Fechas
    {
        public const int AGOTADO = 2;
        public const int ACTIVO = 1;
        public const int NO_ACTIVO = 0;

        public int id { get; set; }
        public string nombre { get; set; }
        public int unidades { get; set; }
        public int dosis { get; set; }
        public DateTime fecha_vencimiento { get; set; }
        public string descripcion { get; set; }
        public string cubre { get; set; }
        public int estado { get; set; } = ACTIVO;
        public int usuario_id { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public DateTime DeleteAt { get; set; }
    
        public virtual Usuario Usuario { get; set; }
    }
}