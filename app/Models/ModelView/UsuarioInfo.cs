using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.Models.ModelView
{
    public class UsuarioInfo
    {
        public int Id { get; set; }
        public string Cui { get; set; }
        public string NombreUsuario { get; set; }
        public string Correo { get; set; }
        public int Estado { get; set; }
        public int RolId { get; set; }
        public string RolNombre { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public DateTime DeleteAt { get; set; }
    }
}