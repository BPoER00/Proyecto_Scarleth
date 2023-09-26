using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using app.helpers;

namespace app.Models
{
    public class Detalle_Vacunacion : IControl_Fechas
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = $"{ErrorHelperMessage.campoRequired} [vacunacion]")]
        public int vacunacion_id { get; set; }

        [Required(ErrorMessage = $"{ErrorHelperMessage.campoRequired} [fecha vacunacion]")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}")]
        public DateTime fecha_vacunacion { get; set; }

        [Required(ErrorMessage = $"{ErrorHelperMessage.campoRequired} [dosis]")]
        public int dosis { get; set; }

        [Required(ErrorMessage = $"{ErrorHelperMessage.campoRequired} [medico]")]
        public int asignacion_id { get; set; }

        public DateTime CreateAt { get; set; } = DateTime.Now;
        public DateTime UpdateAt { get; set; }
        public DateTime DeleteAt { get; set; }

        [ForeignKey("vacunacion_id")]
        public virtual Vacunacion Vacunacion { get; set; }

        [ForeignKey("asignacion_id")]
        public virtual Asignacion Asignacion { get; set; }

    }
}