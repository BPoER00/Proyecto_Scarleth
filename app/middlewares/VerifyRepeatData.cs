using app.Models;
using Microsoft.EntityFrameworkCore;

namespace app.middlewares
{
    public class VerifyRepeatData<T> where T : class
    {
        private readonly ConexionContext db;

        public VerifyRepeatData()
        {
            this.db = new ConexionContext();
        }

        public async Task<bool> IsDataDuplicated(string property, object value)
        {
            try
            {
                if (value.ToString().Length > 0)
                {

                    return await db.Set<T>().AnyAsync(entity => EF.Property<object>(entity, property) == value);
                }

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al verificar datos duplicados: {ex.Message}");
                return false;
            }
        }
    }
}