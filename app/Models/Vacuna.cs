using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using app.helpers;
namespace app.Models
{
    public class Vacuna : IControl_Fechas
    {
        [NotMapped]
        public const int AGOTADO = 2;
        [NotMapped]
        public const int ACTIVO = 1;
        [NotMapped]
        public const int NO_ACTIVO = 0;

        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = $"{ErrorHelperMessage.campoRequired} [nombre]")]
        [StringLength(85, ErrorMessage = $"{ErrorHelperMessage.campoLenght} [85 caracteres] [nombre]")]
        [DataType(DataType.Text)]
        public string nombre { get; set; }

        [Required(ErrorMessage = $"{ErrorHelperMessage.campoRequired} [unidades]")]
        public int unidades { get; set; }
        
        [Required(ErrorMessage = $"{ErrorHelperMessage.campoRequired} [dosis]")]
        public int dosis { get; set; }

        [Required(ErrorMessage = $"{ErrorHelperMessage.campoRequired} [fecha vencimiento]")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime fecha_vencimiento { get; set; }

        [Required(ErrorMessage = $"{ErrorHelperMessage.campoRequired} [descripcion]")]
        [StringLength(85, ErrorMessage = $"{ErrorHelperMessage.campoLenght} [85 caracteres] [descripcion]")]
        [DataType(DataType.Text)]
        public string descripcion { get; set; }

        [Required(ErrorMessage = $"{ErrorHelperMessage.campoRequired} [cubre]")]
        [StringLength(85, ErrorMessage = $"{ErrorHelperMessage.campoLenght} [85 caracteres] [cubre]")]
        [DataType(DataType.Text)]
        public string cubre { get; set; }
        public int estado { get; set; } = ACTIVO;
        
        [Required(ErrorMessage = $"{ErrorHelperMessage.campoRequired} [cubre]")]
        [ForeignKey("Usuario")]
        public int usuario_id { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public DateTime UpdateAt { get; set; }
        public DateTime DeleteAt { get; set; }
    
        [NotMapped]
        public virtual Usuario Usuario { get; set; }
    }
}