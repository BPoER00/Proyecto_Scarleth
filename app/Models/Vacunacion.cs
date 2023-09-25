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

        [Required(ErrorMessage = $"{ErrorHelperMessage.campoRequired} [vacuna]")]
        public int vacuna_id { get; set; }

        [Required(ErrorMessage = $"{ErrorHelperMessage.campoRequired} [paciente]")]
        public int persona_id { get; set; }

        [Required(ErrorMessage = $"{ErrorHelperMessage.campoRequired} [dosis]")]
        public long dosis { get; set; }

        public int estado { get; set; } = ACTIVO;
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public DateTime UpdateAt { get; set; }
        public DateTime DeleteAt { get; set; }

        [ForeignKey("vacuna_id")]
        public virtual Vacuna Vacuna { get; set; }

        [ForeignKey("persona_id")]
        public virtual Persona Persona { get; set; }
    }
}