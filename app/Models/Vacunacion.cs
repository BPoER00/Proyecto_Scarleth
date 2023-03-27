using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using app.helpers;
namespace app.Models
{
    public class Vacunacion : IControl_Fechas
    {
        [NotMapped]
        public const int ACTIVO = 1;
        [NotMapped]
        public const int NO_ACTIVO = 0;

        [Key]
        public int id { get; set; }
        
        [Required(ErrorMessage = $"{ErrorHelperMessage.campoRequired} [descripcion]")]
        [StringLength(85, ErrorMessage = $"{ErrorHelperMessage.campoLenght} [85 caracteres] [descripcion]")]
        [DataType(DataType.Text)]
        public string descripcion { get; set; }

        [Required(ErrorMessage = $"{ErrorHelperMessage.campoRequired} [medico]")]
        [ForeignKey("Medico")]
        public int medico_id { get; set; }

        [Required(ErrorMessage = $"{ErrorHelperMessage.campoRequired} [vacuna]")]
        [ForeignKey("Vacuna")]
        public int vacuna_id { get; set; }

        [Required(ErrorMessage = $"{ErrorHelperMessage.campoRequired} [paciento]")]
        [ForeignKey("Paciente")]
        public int paciente_id { get; set; }

        [Required(ErrorMessage = $"{ErrorHelperMessage.campoRequired} [dosis]")]
        public long dosis { get; set; }

        [Required(ErrorMessage = $"{ErrorHelperMessage.campoRequired} [fecha registro]")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime fecha_registro { get; set; }
        public int estado { get; set; } = ACTIVO;
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public DateTime UpdateAt { get; set; }
        public DateTime DeleteAt { get; set; }

        [NotMapped]
        public virtual Medico Medico { get; set; }
        [NotMapped]
        public virtual Vacuna Vacuna { get; set; }
        [NotMapped]
        public virtual Paciente Paciente { get; set; }
    }
}