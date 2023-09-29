using System.Globalization;

namespace app.helpers
{
    public class FormatearFechas
    {
        public DateTime FormatearFecha(string fecha)
        {
            if (DateTime.TryParseExact(fecha, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fechaFormateada))
            {
                return fechaFormateada;
            }
            
            throw new ArgumentException("La cadena de fecha no es válida.");
        }
    }
}