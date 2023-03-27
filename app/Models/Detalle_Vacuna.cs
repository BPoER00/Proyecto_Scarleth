using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using app.helpers;
namespace app.Models
{
    public class Detalle_Vacuna : IControl_Fechas
    {
        public int id { get; set; }
        
        [Required(ErrorMessage = $"{ErrorHelperMessage.campoRequired} [nombre]")]
        [StringLength(85, ErrorMessage = $"{ErrorHelperMessage.campoLenght} [85 caracteres] [nombre]")]
        public string descripcion { get; set; }
        
        [Required(ErrorMessage = $"{ErrorHelperMessage.campoRequired} [cantidad]")]
        public long cantidad { get; set; }
        
        [Required(ErrorMessage = $"{ErrorHelperMessage.campoRequired} [fecha ingreso]")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime fecha_ingreso { get; set; }
        
        [Required(ErrorMessage = $"{ErrorHelperMessage.campoRequired} [vacuna]")]
        public int vacuna_id { get; set; }
        
        public int usuario_id { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public DateTime UpdateAt { get; set; }
        public DateTime DeleteAt { get; set; }

        [NotMapped]
        public virtual Vacuna Vacuna { get; set; }
        [NotMapped]
        public virtual Usuario Usuario { get; set; }
    }
}