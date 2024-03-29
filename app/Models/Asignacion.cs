using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using app.helpers;
namespace app.Models
{
    public class Asignacion : IControl_Fechas
    {
        [NotMapped]
        public const int ACTIVO = 1;
        [NotMapped]
        public const int NO_ACTIVO = 0;

        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = $"{ErrorHelperMessage.campoRequired} [persona]")]
        public int persona_id { get; set; }

        [StringLength(25, ErrorMessage = $"{ErrorHelperMessage.campoLenght} [25 caracteres] [numero colegiado]")]
        [DataType(DataType.Text)]
        public string numero_colegiado { get; set; }

        [Required(ErrorMessage = $"{ErrorHelperMessage.campoRequired} [cargo]")]
        public int cargo_id { get; set; }

        public int estado { get; set; } = ACTIVO; 


        public DateTime CreateAt { get; set; } = DateTime.Now;
        public DateTime UpdateAt { get; set; }
        public DateTime DeleteAt { get; set; }


        [ForeignKey("persona_id")]
        public virtual Persona Persona { get; set; }

        [ForeignKey("cargo_id")]
        public virtual Cargo Cargo { get; set; }
    }
}