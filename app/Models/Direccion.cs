using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.Models
{
    public class Direccion : IControl_Fechas
    {
        public const int ACTIVO = 1;
        public const int NO_ACTIVO = 0;

        public int id { get; set; }
        public string nombre { get; set; }
        public int estado { get; set; } = ACTIVO;


        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public DateTime DeleteAt { get; set; }
    }
}