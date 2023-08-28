using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using app.helpers;
namespace app.Models
{
    public class Paciente : IControl_Fechas
    {
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

        [Required(ErrorMessage = $"{ErrorHelperMessage.campoRequired} [cui]")]
        [StringLength(15, ErrorMessage = $"{ErrorHelperMessage.campoLenght} [15 caracteres] [cui]")]
        [DataType(DataType.Text)]
        public string cui { get; set; }

        [Required(ErrorMessage = $"{ErrorHelperMessage.campoRequired} [fecha nacimiento]")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime fecha_nacimiento { get; set; }

        [Required(ErrorMessage = $"{ErrorHelperMessage.campoRequired} [comunidad]")]
        [StringLength(150, ErrorMessage = $"{ErrorHelperMessage.campoLenght} [150 caracteres] [comunidad]")]
        [DataType(DataType.Text)]
        public string comunidad { get; set; }
        
        [Required(ErrorMessage = $"{ErrorHelperMessage.campoRequired} [direccion]")]
        public int direccion_id { get; set; }

        [Required(ErrorMessage = $"{ErrorHelperMessage.campoRequired} [genero]")]
        public int genero_id { get; set; }

        [Required(ErrorMessage = $"{ErrorHelperMessage.campoRequired} [telefono]")]
        [StringLength(20, ErrorMessage = $"{ErrorHelperMessage.campoLenght} [20 caracteres] [telefono]")]
        [DataType(DataType.PhoneNumber)]
        public string telefono { get; set; }


        public int estado { get; set; } = ACTIVO;
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public DateTime UpdateAt { get; set; }
        public DateTime DeleteAt { get; set; }
        
        [ForeignKey("direccion_id")]
        public virtual Direccion Direccion { get; set; }

        [ForeignKey("genero_id")]
        public virtual Genero Genero { get; set; }
        
    }
}