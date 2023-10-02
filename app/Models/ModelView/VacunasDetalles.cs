using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using app.helpers;

namespace app.Models.ModelView
{
    public class VacunasDetalles
    {
        //detalles vacuna
        [Required(ErrorMessage = $"{ErrorHelperMessage.campoRequired} [nombre]")]
        [StringLength(85, ErrorMessage = $"{ErrorHelperMessage.campoLenght} [85 caracteres] [nombre]")]
        [DataType(DataType.Text)]
        public string descripcion { get; set; }

        [Required(ErrorMessage = $"{ErrorHelperMessage.campoRequired} [cantidad]")]
        public long cantidad { get; set; }

        [Required(ErrorMessage = $"{ErrorHelperMessage.campoRequired} [dosis]")]
        public long dosis { get; set; }

        [Required(ErrorMessage = $"{ErrorHelperMessage.campoRequired} [fecha vencimiento]")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime fecha_vencimiento { get; set; }

        [Required(ErrorMessage = $"{ErrorHelperMessage.campoRequired} [usuario]")]
        public int usuario_id { get; set; }

        //vacuna
        [Required(ErrorMessage = $"{ErrorHelperMessage.campoRequired} [nombre]")]
        [StringLength(85, ErrorMessage = $"{ErrorHelperMessage.campoLenght} [85 caracteres] [nombre]")]
        [DataType(DataType.Text)]
        public string nombre { get; set; }

        [Required(ErrorMessage = $"{ErrorHelperMessage.campoRequired} [cubre]")]
        [StringLength(85, ErrorMessage = $"{ErrorHelperMessage.campoLenght} [85 caracteres] [cubre]")]
        [DataType(DataType.Text)]
        public string cubre { get; set; }
    }
}