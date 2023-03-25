using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.Models
{
    public class Usuario : IControl_Fechas
    {
        public const int ACTIVO = 1;
        public const int NO_ACTIVO = 0;

        public int id { get; set; }
        public string nombre { get; set; }
        public string telefono { get; set; }
        public string cui { get; set; }
        public string nombre_usuario { get; set; }
        public string correo { get; set; }
        public string password { get; set; }
        public string password_confirm { get; set; }
        public int id_rol { get; set; }
        public int estado { get; set; } = ACTIVO;
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public DateTime DeleteAt { get; set; }

        public virtual Rol rol { get; set; }


    }
}