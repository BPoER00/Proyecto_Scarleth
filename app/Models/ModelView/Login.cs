using System.ComponentModel.DataAnnotations;
using app.helpers;

namespace app.Models.ModelView
{
    public class Login
    {
        [Required(ErrorMessage = $"{ErrorHelperMessage.campoRequired} [usuario]")]
        public string nombre_usuario { get; set; }

        [Required(ErrorMessage = $"{ErrorHelperMessage.campoRequired} [password]")]
        public string password { get; set; }

    }
}