using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.Models
{
    public class Paciente : IControl_Fechas
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string cui { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public string comunidad { get; set; }
        public int id_direccion { get; set; }
        public int id_genero { get; set; }
        public int id_etnia { get; set; }
        public DateTime fecha_registro { get; set; }
        public string telefono { get; set; }
        public int estado { get; set; }
        public virtual Direccion direccion { get; set; }
        public virtual Genero genero { get; set; }
        public virtual Etnia etnia { get; set; }

        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public DateTime DeleteAt { get; set; }
    }
}