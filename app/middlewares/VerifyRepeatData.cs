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
                return await db.Set<T>().AnyAsync(entity => EF.Property<object>(entity, property) == value);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al verificar datos duplicados: {ex.Message}");
                return false;
            }
        }
    }
}