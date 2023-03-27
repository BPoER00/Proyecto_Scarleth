using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using app.helpers;
namespace app.Models
{
    public class Detalle_Vacunacion : IControl_Fechas
    {
        public int id { get; set; }
        
        [Required(ErrorMessage = $"{ErrorHelperMessage.campoRequired} [vacunacion]")]
        public int vacunacion_id { get; set; }
        
        [Required(ErrorMessage = $"{ErrorHelperMessage.campoRequired} [fecha vacunacion]")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime fecha_vacunacion { get; set; }
        
        [Required(ErrorMessage = $"{ErrorHelperMessage.campoRequired} [dosis]")]
        public int dosis { get; set; }
        
        public int usuario_id { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public DateTime UpdateAt { get; set; }
        public DateTime DeleteAt { get; set; }
    
        [NotMapped]
        public virtual Vacunacion Vacunacion { get; set; }
        [NotMapped]
        public virtual Usuario Usuario { get; set; }
    }
}