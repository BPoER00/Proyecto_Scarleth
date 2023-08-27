using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        [ForeignKey("Persona")]
        public int persona_id { get; set; }

        [Required(ErrorMessage = $"{ErrorHelperMessage.campoRequired} [numero colegiado]")]
        [StringLength(25, ErrorMessage = $"{ErrorHelperMessage.campoLenght} [25 caracteres] [numero colegiado]")]
        [DataType(DataType.Text)]
        public string numero_colegiado { get; set; }

        [Required(ErrorMessage = $"{ErrorHelperMessage.campoRequired} [cargo]")]
        [ForeignKey("Cargo")]
        public int cargo_id { get; set; }

        public int estado { get; set; } = ACTIVO;


        public DateTime CreateAt { get; set; } = DateTime.Now;
        public DateTime UpdateAt { get; set; }
        public DateTime DeleteAt { get; set; }


        [NotMapped]
        public virtual Cargo Cargo { get; set; }
        [NotMapped]
        public virtual Persona Persona { get; set; }
    }
}