using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using app.helpers;

namespace app.Models
{
    public class Cargo : IControl_Fechas
    {
        [NotMapped]
        public const int ACTIVO = 1;
        [NotMapped]
        public const int NO_ACTIVO = 0;


        public int id { get; set; }
        [Required(ErrorMessage = $"{ErrorHelperMessage.campoRequired} [nombre]")]
        [StringLength(85, ErrorMessage = $"{ErrorHelperMessage.campoLenght} [85 caracteres] [nombre]")]
        public string nombre { get; set; }
        public int estado { get; set; } = ACTIVO;       
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public DateTime DeleteAt { get; set; }
    }
}