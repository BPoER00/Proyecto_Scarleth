using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using app.helpers;


namespace app.Models
{

    public class VacunacionDetalles
    {
        [Required(ErrorMessage = $"{ErrorHelperMessage.campoRequired} [fecha vacunacion]")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime fecha_vacunacion { get; set; }

        [Required(ErrorMessage = $"{ErrorHelperMessage.campoRequired} [dosis]")]
        public int dosis { get; set; }

        [Required(ErrorMessage = $"{ErrorHelperMessage.campoRequired} [medico]")]
        public int asignacion_id { get; set; }

        [Required(ErrorMessage = $"{ErrorHelperMessage.campoRequired} [descripcion]")]
        [StringLength(85, ErrorMessage = $"{ErrorHelperMessage.campoLenght} [85 caracteres] [descripcion]")]
        [DataType(DataType.Text)]
        public string descripcion { get; set; }

        [Required(ErrorMessage = $"{ErrorHelperMessage.campoRequired} [vacuna]")]
        public int vacuna_id { get; set; }

        [Required(ErrorMessage = $"{ErrorHelperMessage.campoRequired} [paciente]")]
        public int persona_id { get; set; }
    }
}