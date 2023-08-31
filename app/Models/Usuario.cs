using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using app.helpers;
namespace app.Models
{
    public class Usuario : IControl_Fechas
    {
        [NotMapped]
        public const int ACTIVO = 1;
        [NotMapped]
        public const int NO_ACTIVO = 0;

        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = $"{ErrorHelperMessage.campoRequired} [Persona]")]
        public int persona_id { get; set; }

        [Required(ErrorMessage = $"{ErrorHelperMessage.campoRequired} [nombre usuario]")]
        [StringLength(85, ErrorMessage = $"{ErrorHelperMessage.campoLenght} [85 caracteres] [nombre usuario]")]
        [DataType(DataType.Text)]
        public string nombre_usuario { get; set; }

        [Required(ErrorMessage = $"{ErrorHelperMessage.campoRequired} [nombre]")]
        [StringLength(255, ErrorMessage = $"{ErrorHelperMessage.campoLenght} [255 caracteres] [correo]")]
        [DataType(DataType.EmailAddress)]
        public string correo { get; set; }

        [Required(ErrorMessage = $"{ErrorHelperMessage.campoRequired} [password]")]
        [StringLength(255, ErrorMessage = $"{ErrorHelperMessage.campoLenght} [255 caracteres] [password]", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [NotMapped]
        [Compare("password", ErrorMessage = "Las Password No Coinciden")]
        [Required(ErrorMessage = $"{ErrorHelperMessage.campoRequired} [password confirm]")]
        [StringLength(255, ErrorMessage = $"{ErrorHelperMessage.campoLenght} [255 caracteres] [password confirm]", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string password_confirm { get; set; }

        [Required(ErrorMessage = $"{ErrorHelperMessage.campoRequired} [rol]")]
        public int rol_id { get; set; }
        public int estado { get; set; } = ACTIVO;
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public DateTime UpdateAt { get; set; }
        public DateTime DeleteAt { get; set; }

        [ForeignKey("rol_id")]
        public virtual Rol Rol { get; set; }

        [ForeignKey("persona_id")]
        public virtual Persona Persona { get; set; }
    }
}