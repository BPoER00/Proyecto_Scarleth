using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        [Required(ErrorMessage = $"{ErrorHelperMessage.campoRequired} [nombre]")]
        [StringLength(85, ErrorMessage = $"{ErrorHelperMessage.campoLenght} [85 caracteres] [nombre]")]
        [DataType(DataType.Text)]
        public string nombre { get; set; }

        [Required(ErrorMessage = $"{ErrorHelperMessage.campoRequired} [telefono]")]
        [StringLength(15, ErrorMessage = $"{ErrorHelperMessage.campoLenght} [15 caracteres] [telefono]")]
        [DataType(DataType.PhoneNumber)]
        public string telefono { get; set; }


        [Required(ErrorMessage = $"{ErrorHelperMessage.campoRequired} [cui]")]
        [StringLength(15, ErrorMessage = $"{ErrorHelperMessage.campoLenght} [85 caracteres] [cui]")]
        [DataType(DataType.Text)]
        public string cui { get; set; }


        [Required(ErrorMessage = $"{ErrorHelperMessage.campoRequired} [nombre usuario]")]
        [StringLength(85, ErrorMessage = $"{ErrorHelperMessage.campoLenght} [85 caracteres] [nombre usuario]")]
        [DataType(DataType.Text)]
        public string nombre_usuario { get; set; }


        [Required(ErrorMessage = $"{ErrorHelperMessage.campoRequired} [nombre]")]
        [StringLength(85, ErrorMessage = $"{ErrorHelperMessage.campoLenght} [85 caracteres] [nombre]")]
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
        [ForeignKey("rol")]
        public int id_rol { get; set; }
        public string Sal { get; set; }
        public int estado { get; set; } = ACTIVO;
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public DateTime UpdateAt { get; set; }
        public DateTime DeleteAt { get; set; }

        [NotMapped]
        public virtual Rol rol { get; set; }

    }
}