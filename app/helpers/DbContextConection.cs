using app.Models;

namespace app.helpers
{
    public class DbContextConection
    {
        private ConexionContext db;

        public ConexionContext context()
        {
            return this.db = new ConexionContext();
        }
    }
}