using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.Models
{
    public class Medico : IControl_Fechas
    {
        public const int ACTIVO = 1;
        public const int NO_ACTIVO = 0;

        public int id { get; set; }
        public string nombre { get; set; }
        public string cui { get; set; }
        public string numero_colegiado { get; set; }
        public DateTime fecha_registro { get; set; }
        public string telefono { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public int cargo_id { get; set; }
        public int etnia_id { get; set; }
        public int genero_id { get; set; }
        public int estado { get; set; } = ACTIVO;
        public int usuario_id { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public DateTime DeleteAt { get; set; }

        public virtual Cargo Cargo { get; set; }
        public virtual Etnia Etnia { get; set; }
        public virtual Genero Genero { get; set; }
        public virtual Direccion Direccion { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}