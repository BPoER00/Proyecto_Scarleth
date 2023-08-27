using Microsoft.EntityFrameworkCore;
using app.config;
using app.seeders;

namespace app.Models
{
    public class ConexionContext : DbContext
    {
        private dbString DbString;

        public ConexionContext()
        {
            this.DbString = new dbString();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //conect to sql server with connection string from appsettings.json
            options.UseSqlServer(this.DbString.retornar());
        }

        //Dbset para integrar data a la base de datos
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Detalle_Vacuna> Detalle_Vacunas { get; set; }
        public DbSet<Detalle_Vacunacion> Detalle_Vacunacions { get; set; }
        public DbSet<Direccion> Direccions { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Asignacion> Asignacions { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Rol> Rols { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Vacuna> Vacunas { get; set; }
        public DbSet<Vacunacion> Vacunacions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }
    }
}