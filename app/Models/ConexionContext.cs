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
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Direccion> Direccions { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Asignacion> Asignacions { get; set; }
        public DbSet<Vacuna> Vacunas { get; set; }
        public DbSet<Vacunacion> Vacunacions { get; set; }
        public DbSet<Detalle_Vacuna> Detalle_Vacunas { get; set; }
        public DbSet<Detalle_Vacunacion> Detalle_Vacunacions { get; set; }
        public DbSet<Rol> Rols { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();

            //cargos unicos
            modelBuilder.Entity<Cargo>()
                .HasIndex(p => p.nombre)
                .IsUnique();

            modelBuilder.Entity<Genero>()
                .HasIndex(p => p.nombre)
                .IsUnique();

            modelBuilder.Entity<Direccion>()
                .HasIndex(p => p.nombre)
                .IsUnique();

            modelBuilder.Entity<Persona>()
                .HasIndex(p => p.cui)
                .IsUnique();

            modelBuilder.Entity<Asignacion>()
                .HasIndex(p => p.persona_id)
                .IsUnique();

            modelBuilder.Entity<Asignacion>()
                .HasIndex(p => p.numero_colegiado)
                .IsUnique();

            modelBuilder.Entity<Vacuna>()
                .HasIndex(p => p.nombre)
                .IsUnique();

            modelBuilder.Entity<Rol>()
                .HasIndex(p => p.nombre)
                .IsUnique();

            modelBuilder.Entity<Usuario>()
                .HasIndex(p => p.persona_id)
                .IsUnique();

            modelBuilder.Entity<Usuario>()
                .HasIndex(p => p.nombre_usuario)
                .IsUnique();

            modelBuilder.Entity<Usuario>()
                .HasIndex(p => p.correo)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }
    }
}