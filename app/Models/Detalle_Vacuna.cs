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
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = $"{ErrorHelperMessage.campoRequired} [nombre]")]
        [StringLength(85, ErrorMessage = $"{ErrorHelperMessage.campoLenght} [85 caracteres] [nombre]")]
        [DataType(DataType.Text)]
        public string descripcion { get; set; }

        [Required(ErrorMessage = $"{ErrorHelperMessage.campoRequired} [cantidad]")]
        public long cantidad { get; set; }

        [Required(ErrorMessage = $"{ErrorHelperMessage.campoRequired} [fecha vencimiento]")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}")]
        public DateTime fecha_vencimiento { get; set; }

        [Required(ErrorMessage = $"{ErrorHelperMessage.campoRequired} [vacuna]")]
        public int vacuna_id { get; set; }

        public DateTime CreateAt { get; set; } = DateTime.Now;
        public DateTime UpdateAt { get; set; }
        public DateTime DeleteAt { get; set; }

        [ForeignKey("vacuna_id")]
        public virtual Vacuna Vacuna { get; set; }

    }
}